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
  An American option can be exercised at any time between two predefined dates; the first date might be omitted, in which case the option can be exercised at any time before the expiry.  check that everywhere the American condition is applied from earliestDate and not earlier
  </summary> *)
[<AutoSerializable(true)>]
module AmericanExerciseFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AmericanExercise", Description="Create a AmericanExercise",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmericanExercise_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="latest",Description = "Reference to latest")>] 
         latest : obj)
        ([<ExcelArgument(Name="payoffAtExpiry",Description = "Reference to payoffAtExpiry")>] 
         payoffAtExpiry : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _latest = Helper.toCell<Date> latest "latest" true
                let _payoffAtExpiry = Helper.toCell<bool> payoffAtExpiry "payoffAtExpiry" true
                let builder () = withMnemonic mnemonic (Fun.AmericanExercise 
                                                            _latest.cell 
                                                            _payoffAtExpiry.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AmericanExercise>) l

                let source = Helper.sourceFold "Fun.AmericanExercise" 
                                               [| _latest.source
                                               ;  _payoffAtExpiry.source
                                               |]
                let hash = Helper.hashFold 
                                [| _latest.cell
                                ;  _payoffAtExpiry.cell
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
    [<ExcelFunction(Name="_AmericanExercise1", Description="Create a AmericanExercise",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmericanExercise_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="earliestDate",Description = "Reference to earliestDate")>] 
         earliestDate : obj)
        ([<ExcelArgument(Name="latestDate",Description = "Reference to latestDate")>] 
         latestDate : obj)
        ([<ExcelArgument(Name="payoffAtExpiry",Description = "Reference to payoffAtExpiry")>] 
         payoffAtExpiry : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _earliestDate = Helper.toCell<Date> earliestDate "earliestDate" true
                let _latestDate = Helper.toCell<Date> latestDate "latestDate" true
                let _payoffAtExpiry = Helper.toCell<bool> payoffAtExpiry "payoffAtExpiry" true
                let builder () = withMnemonic mnemonic (Fun.AmericanExercise1 
                                                            _earliestDate.cell 
                                                            _latestDate.cell 
                                                            _payoffAtExpiry.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AmericanExercise>) l

                let source = Helper.sourceFold "Fun.AmericanExercise1" 
                                               [| _earliestDate.source
                                               ;  _latestDate.source
                                               ;  _payoffAtExpiry.source
                                               |]
                let hash = Helper.hashFold 
                                [| _earliestDate.cell
                                ;  _latestDate.cell
                                ;  _payoffAtExpiry.cell
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
    [<ExcelFunction(Name="_AmericanExercise_payoffAtExpiry", Description="Create a AmericanExercise",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmericanExercise_payoffAtExpiry
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmericanExercise",Description = "Reference to AmericanExercise")>] 
         americanexercise : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmericanExercise = Helper.toCell<AmericanExercise> americanexercise "AmericanExercise" true 
                let builder () = withMnemonic mnemonic ((_AmericanExercise.cell :?> AmericanExerciseModel).PayoffAtExpiry
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AmericanExercise.source + ".PayoffAtExpiry") 
                                               [| _AmericanExercise.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmericanExercise.cell
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
    [<ExcelFunction(Name="_AmericanExercise_date", Description="Create a AmericanExercise",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmericanExercise_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmericanExercise",Description = "Reference to AmericanExercise")>] 
         americanexercise : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmericanExercise = Helper.toCell<AmericanExercise> americanexercise "AmericanExercise" true 
                let _index = Helper.toCell<int> index "index" true
                let builder () = withMnemonic mnemonic ((_AmericanExercise.cell :?> AmericanExerciseModel).Date
                                                            _index.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmericanExercise.source + ".Date") 
                                               [| _AmericanExercise.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmericanExercise.cell
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
    [<ExcelFunction(Name="_AmericanExercise_dates", Description="Create a AmericanExercise",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmericanExercise_dates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmericanExercise",Description = "Reference to AmericanExercise")>] 
         americanexercise : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmericanExercise = Helper.toCell<AmericanExercise> americanexercise "AmericanExercise" true 
                let builder () = withMnemonic mnemonic ((_AmericanExercise.cell :?> AmericanExerciseModel).Dates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_AmericanExercise.source + ".Dates") 
                                               [| _AmericanExercise.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmericanExercise.cell
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
    [<ExcelFunction(Name="_AmericanExercise_lastDate", Description="Create a AmericanExercise",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmericanExercise_lastDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmericanExercise",Description = "Reference to AmericanExercise")>] 
         americanexercise : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmericanExercise = Helper.toCell<AmericanExercise> americanexercise "AmericanExercise" true 
                let builder () = withMnemonic mnemonic ((_AmericanExercise.cell :?> AmericanExerciseModel).LastDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmericanExercise.source + ".LastDate") 
                                               [| _AmericanExercise.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmericanExercise.cell
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
    [<ExcelFunction(Name="_AmericanExercise_type", Description="Create a AmericanExercise",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmericanExercise_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmericanExercise",Description = "Reference to AmericanExercise")>] 
         americanexercise : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmericanExercise = Helper.toCell<AmericanExercise> americanexercise "AmericanExercise" true 
                let builder () = withMnemonic mnemonic ((_AmericanExercise.cell :?> AmericanExerciseModel).Type
                                                       ) :> ICell
                let format (o : Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AmericanExercise.source + ".TYPE") 
                                               [| _AmericanExercise.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmericanExercise.cell
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
    [<ExcelFunction(Name="_AmericanExercise_Range", Description="Create a range of AmericanExercise",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmericanExercise_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the AmericanExercise")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AmericanExercise> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AmericanExercise>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<AmericanExercise>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<AmericanExercise>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
