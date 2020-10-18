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
  A European option can only be exercised at one (expiry) date.
  </summary> *)
[<AutoSerializable(true)>]
module EuropeanExerciseFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EuropeanExercise", Description="Create a EuropeanExercise",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuropeanExercise_create
        ([<ExcelArgument(Name="Mnemonic",Description = "EuropeanExercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.EuropeanExercise 
                                                            _date.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EuropeanExercise>) l

                let source () = Helper.sourceFold "Fun.EuropeanExercise" 
                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _date.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EuropeanExercise> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        inspectors
    *)
    [<ExcelFunction(Name="_EuropeanExercise_date", Description="Create a EuropeanExercise",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuropeanExercise_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuropeanExercise",Description = "EuropeanExercise")>] 
         europeanexercise : obj)
        ([<ExcelArgument(Name="index",Description = "int")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuropeanExercise = Helper.toCell<EuropeanExercise> europeanexercise "EuropeanExercise"  
                let _index = Helper.toCell<int> index "index" 
                let builder (current : ICell) = withMnemonic mnemonic ((EuropeanExerciseModel.Cast _EuropeanExercise.cell).Date
                                                            _index.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_EuropeanExercise.source + ".Date") 
                                               [| _EuropeanExercise.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuropeanExercise.cell
                                ;  _index.cell
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
    [<ExcelFunction(Name="_EuropeanExercise_dates", Description="Create a EuropeanExercise",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuropeanExercise_dates
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuropeanExercise",Description = "EuropeanExercise")>] 
         europeanexercise : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuropeanExercise = Helper.toCell<EuropeanExercise> europeanexercise "EuropeanExercise"  
                let builder (current : ICell) = withMnemonic mnemonic ((EuropeanExerciseModel.Cast _EuropeanExercise.cell).Dates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_EuropeanExercise.source + ".Dates") 
                                               [| _EuropeanExercise.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuropeanExercise.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
        
    *)
    [<ExcelFunction(Name="_EuropeanExercise_lastDate", Description="Create a EuropeanExercise",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuropeanExercise_lastDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuropeanExercise",Description = "EuropeanExercise")>] 
         europeanexercise : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuropeanExercise = Helper.toCell<EuropeanExercise> europeanexercise "EuropeanExercise"  
                let builder (current : ICell) = withMnemonic mnemonic ((EuropeanExerciseModel.Cast _EuropeanExercise.cell).LastDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_EuropeanExercise.source + ".LastDate") 
                                               [| _EuropeanExercise.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuropeanExercise.cell
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
    [<ExcelFunction(Name="_EuropeanExercise_type", Description="Create a EuropeanExercise",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuropeanExercise_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuropeanExercise",Description = "EuropeanExercise")>] 
         europeanexercise : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuropeanExercise = Helper.toCell<EuropeanExercise> europeanexercise "EuropeanExercise"  
                let builder (current : ICell) = withMnemonic mnemonic ((EuropeanExerciseModel.Cast _EuropeanExercise.cell).Type
                                                       ) :> ICell
                let format (o : Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuropeanExercise.source + ".TYPE") 
                                               [| _EuropeanExercise.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuropeanExercise.cell
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
    [<ExcelFunction(Name="_EuropeanExercise_Range", Description="Create a range of EuropeanExercise",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuropeanExercise_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EuropeanExercise> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<EuropeanExercise>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<EuropeanExercise>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<EuropeanExercise>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
