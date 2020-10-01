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
  The payoff can be at exercise (the default) or at expiry
  </summary> *)
[<AutoSerializable(true)>]
module EarlyExerciseFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EarlyExercise", Description="Create a EarlyExercise",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EarlyExercise_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="payoffAtExpiry",Description = "Reference to payoffAtExpiry")>] 
         payoffAtExpiry : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<Exercise.Type> Type "Type" 
                let _payoffAtExpiry = Helper.toCell<bool> payoffAtExpiry "payoffAtExpiry" 
                let builder () = withMnemonic mnemonic (Fun.EarlyExercise 
                                                            _Type.cell 
                                                            _payoffAtExpiry.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EarlyExercise>) l

                let source = Helper.sourceFold "Fun.EarlyExercise" 
                                               [| _Type.source
                                               ;  _payoffAtExpiry.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _payoffAtExpiry.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EarlyExercise> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EarlyExercise_payoffAtExpiry", Description="Create a EarlyExercise",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EarlyExercise_payoffAtExpiry
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EarlyExercise",Description = "Reference to EarlyExercise")>] 
         earlyexercise : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EarlyExercise = Helper.toCell<EarlyExercise> earlyexercise "EarlyExercise"  
                let builder () = withMnemonic mnemonic ((_EarlyExercise.cell :?> EarlyExerciseModel).PayoffAtExpiry
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EarlyExercise.source + ".PayoffAtExpiry") 
                                               [| _EarlyExercise.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EarlyExercise.cell
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
        inspectors
    *)
    [<ExcelFunction(Name="_EarlyExercise_date", Description="Create a EarlyExercise",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EarlyExercise_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EarlyExercise",Description = "Reference to EarlyExercise")>] 
         earlyexercise : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EarlyExercise = Helper.toCell<EarlyExercise> earlyexercise "EarlyExercise"  
                let _index = Helper.toCell<int> index "index" 
                let builder () = withMnemonic mnemonic ((_EarlyExercise.cell :?> EarlyExerciseModel).Date
                                                            _index.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EarlyExercise.source + ".Date") 
                                               [| _EarlyExercise.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EarlyExercise.cell
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
    [<ExcelFunction(Name="_EarlyExercise_dates", Description="Create a EarlyExercise",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EarlyExercise_dates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EarlyExercise",Description = "Reference to EarlyExercise")>] 
         earlyexercise : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EarlyExercise = Helper.toCell<EarlyExercise> earlyexercise "EarlyExercise"  
                let builder () = withMnemonic mnemonic ((_EarlyExercise.cell :?> EarlyExerciseModel).Dates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_EarlyExercise.source + ".Dates") 
                                               [| _EarlyExercise.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EarlyExercise.cell
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
        
    *)
    [<ExcelFunction(Name="_EarlyExercise_lastDate", Description="Create a EarlyExercise",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EarlyExercise_lastDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EarlyExercise",Description = "Reference to EarlyExercise")>] 
         earlyexercise : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EarlyExercise = Helper.toCell<EarlyExercise> earlyexercise "EarlyExercise"  
                let builder () = withMnemonic mnemonic ((_EarlyExercise.cell :?> EarlyExerciseModel).LastDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EarlyExercise.source + ".LastDate") 
                                               [| _EarlyExercise.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EarlyExercise.cell
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
    [<ExcelFunction(Name="_EarlyExercise_type", Description="Create a EarlyExercise",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EarlyExercise_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EarlyExercise",Description = "Reference to EarlyExercise")>] 
         earlyexercise : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EarlyExercise = Helper.toCell<EarlyExercise> earlyexercise "EarlyExercise"  
                let builder () = withMnemonic mnemonic ((_EarlyExercise.cell :?> EarlyExerciseModel).Type
                                                       ) :> ICell
                let format (o : Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EarlyExercise.source + ".TYPE") 
                                               [| _EarlyExercise.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EarlyExercise.cell
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
    [<ExcelFunction(Name="_EarlyExercise_Range", Description="Create a range of EarlyExercise",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EarlyExercise_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the EarlyExercise")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EarlyExercise> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<EarlyExercise>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<EarlyExercise>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<EarlyExercise>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
