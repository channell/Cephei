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
  A Bermudan option can only be exercised at a set of fixed dates.
  </summary> *)
[<AutoSerializable(true)>]
module BermudanExerciseFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BermudanExercise", Description="Create a BermudanExercise",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BermudanExercise_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dates",Description = "Reference to dates")>] 
         dates : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dates = Helper.toCell<Generic.List<Date>> dates "dates" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BermudanExercise 
                                                            _dates.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BermudanExercise>) l

                let source () = Helper.sourceFold "Fun.BermudanExercise" 
                                               [| _dates.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dates.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BermudanExercise> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BermudanExercise1", Description="Create a BermudanExercise",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BermudanExercise_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dates",Description = "Reference to dates")>] 
         dates : obj)
        ([<ExcelArgument(Name="payoffAtExpiry",Description = "Reference to payoffAtExpiry")>] 
         payoffAtExpiry : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dates = Helper.toCell<Generic.List<Date>> dates "dates" 
                let _payoffAtExpiry = Helper.toCell<bool> payoffAtExpiry "payoffAtExpiry" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BermudanExercise1 
                                                            _dates.cell 
                                                            _payoffAtExpiry.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BermudanExercise>) l

                let source () = Helper.sourceFold "Fun.BermudanExercise1" 
                                               [| _dates.source
                                               ;  _payoffAtExpiry.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dates.cell
                                ;  _payoffAtExpiry.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BermudanExercise> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BermudanExercise_payoffAtExpiry", Description="Create a BermudanExercise",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BermudanExercise_payoffAtExpiry
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BermudanExercise",Description = "Reference to BermudanExercise")>] 
         bermudanexercise : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BermudanExercise = Helper.toCell<BermudanExercise> bermudanexercise "BermudanExercise"  
                let builder (current : ICell) = withMnemonic mnemonic ((BermudanExerciseModel.Cast _BermudanExercise.cell).PayoffAtExpiry
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BermudanExercise.source + ".PayoffAtExpiry") 
                                               [| _BermudanExercise.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BermudanExercise.cell
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
        inspectors
    *)
    [<ExcelFunction(Name="_BermudanExercise_date", Description="Create a BermudanExercise",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BermudanExercise_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BermudanExercise",Description = "Reference to BermudanExercise")>] 
         bermudanexercise : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BermudanExercise = Helper.toCell<BermudanExercise> bermudanexercise "BermudanExercise"  
                let _index = Helper.toCell<int> index "index" 
                let builder (current : ICell) = withMnemonic mnemonic ((BermudanExerciseModel.Cast _BermudanExercise.cell).Date
                                                            _index.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_BermudanExercise.source + ".Date") 
                                               [| _BermudanExercise.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BermudanExercise.cell
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
    [<ExcelFunction(Name="_BermudanExercise_dates", Description="Create a BermudanExercise",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BermudanExercise_dates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BermudanExercise",Description = "Reference to BermudanExercise")>] 
         bermudanexercise : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BermudanExercise = Helper.toCell<BermudanExercise> bermudanexercise "BermudanExercise"  
                let builder (current : ICell) = withMnemonic mnemonic ((BermudanExerciseModel.Cast _BermudanExercise.cell).Dates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_BermudanExercise.source + ".Dates") 
                                               [| _BermudanExercise.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BermudanExercise.cell
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
    [<ExcelFunction(Name="_BermudanExercise_lastDate", Description="Create a BermudanExercise",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BermudanExercise_lastDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BermudanExercise",Description = "Reference to BermudanExercise")>] 
         bermudanexercise : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BermudanExercise = Helper.toCell<BermudanExercise> bermudanexercise "BermudanExercise"  
                let builder (current : ICell) = withMnemonic mnemonic ((BermudanExerciseModel.Cast _BermudanExercise.cell).LastDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_BermudanExercise.source + ".LastDate") 
                                               [| _BermudanExercise.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BermudanExercise.cell
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
    [<ExcelFunction(Name="_BermudanExercise_type", Description="Create a BermudanExercise",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BermudanExercise_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BermudanExercise",Description = "Reference to BermudanExercise")>] 
         bermudanexercise : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BermudanExercise = Helper.toCell<BermudanExercise> bermudanexercise "BermudanExercise"  
                let builder (current : ICell) = withMnemonic mnemonic ((BermudanExerciseModel.Cast _BermudanExercise.cell).Type
                                                       ) :> ICell
                let format (o : Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BermudanExercise.source + ".TYPE") 
                                               [| _BermudanExercise.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BermudanExercise.cell
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
    [<ExcelFunction(Name="_BermudanExercise_Range", Description="Create a range of BermudanExercise",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BermudanExercise_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BermudanExercise")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BermudanExercise> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BermudanExercise>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<BermudanExercise>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<BermudanExercise>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
