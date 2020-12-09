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
(*!! generic
(* <summary>

  </summary> *)
[<AutoSerializable(true)>]
module PairFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Pair_first", Description="Create a Pair",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Pair_first
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Pair",Description = "Pair")>] 
         pair : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Pair = Helper.toCell<Pair> pair "Pair"  
                let builder (current : ICell) = withMnemonic mnemonic ((PairModel.Cast _Pair.cell).First
                                                       ) :> ICell
                let format (o : TFirst) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Pair.source + ".First") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Pair.cell
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
    [<ExcelFunction(Name="_Pair", Description="Create a Pair",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Pair_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="first",Description = "'TFirst")>] 
         first : obj)
        ([<ExcelArgument(Name="second",Description = "'TSecond")>] 
         second : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _first = Helper.toCell<'TFirst> first "first" 
                let _second = Helper.toCell<'TSecond> second "second" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Pair 
                                                            _first.cell 
                                                            _second.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Pair>) l

                let source () = Helper.sourceFold "Fun.Pair" 
                                               [| _first.source
                                               ;  _second.source
                                               |]
                let hash = Helper.hashFold 
                                [| _first.cell
                                ;  _second.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Pair> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Pair1", Description="Create a Pair",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Pair_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.Pair1 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Pair>) l

                let source () = Helper.sourceFold "Fun.Pair1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Pair> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Pair_second", Description="Create a Pair",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Pair_second
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Pair",Description = "Pair")>] 
         pair : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Pair = Helper.toCell<Pair> pair "Pair"  
                let builder (current : ICell) = withMnemonic mnemonic ((PairModel.Cast _Pair.cell).Second
                                                       ) :> ICell
                let format (o : TSecond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Pair.source + ".Second") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Pair.cell
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
    [<ExcelFunction(Name="_Pair_set", Description="Create a Pair",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Pair_set
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Pair",Description = "Pair")>] 
         pair : obj)
        ([<ExcelArgument(Name="first",Description = "'TFirst")>] 
         first : obj)
        ([<ExcelArgument(Name="second",Description = "'TSecond")>] 
         second : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Pair = Helper.toCell<Pair> pair "Pair"  
                let _first = Helper.toCell<'TFirst> first "first" 
                let _second = Helper.toCell<'TSecond> second "second" 
                let builder (current : ICell) = withMnemonic mnemonic ((PairModel.Cast _Pair.cell).Set
                                                            _first.cell 
                                                            _second.cell 
                                                       ) :> ICell
                let format (o : Pair) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Pair.source + ".Set") 

                                               [| _first.source
                                               ;  _second.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Pair.cell
                                ;  _first.cell
                                ;  _second.cell
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
    [<ExcelFunction(Name="_Pair_Range", Description="Create a range of Pair",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Pair_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Pair> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<Pair> (c)) :> ICell
                let format (i : Generic.List<ICell<Pair>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<Pair>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
