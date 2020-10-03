﻿(*
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
    [<ExcelFunction(Name="_Pair_first", Description="Create a Pair",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Pair_first
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Pair",Description = "Reference to Pair")>] 
         pair : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Pair = Helper.toCell<Pair> pair "Pair"  
                let builder () = withMnemonic mnemonic ((_Pair.cell :?> PairModel).First
                                                       ) :> ICell
                let format (o : TFirst) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Pair.source + ".First") 
                                               [| _Pair.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Pair.cell
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
    [<ExcelFunction(Name="_Pair", Description="Create a Pair",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Pair_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="first",Description = "Reference to first")>] 
         first : obj)
        ([<ExcelArgument(Name="second",Description = "Reference to second")>] 
         second : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _first = Helper.toCell<'TFirst> first "first" 
                let _second = Helper.toCell<'TSecond> second "second" 
                let builder () = withMnemonic mnemonic (Fun.Pair 
                                                            _first.cell 
                                                            _second.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Pair>) l

                let source = Helper.sourceFold "Fun.Pair" 
                                               [| _first.source
                                               ;  _second.source
                                               |]
                let hash = Helper.hashFold 
                                [| _first.cell
                                ;  _second.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_Pair1", Description="Create a Pair",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Pair_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Pair1 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Pair>) l

                let source = Helper.sourceFold "Fun.Pair1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_Pair_second", Description="Create a Pair",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Pair_second
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Pair",Description = "Reference to Pair")>] 
         pair : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Pair = Helper.toCell<Pair> pair "Pair"  
                let builder () = withMnemonic mnemonic ((_Pair.cell :?> PairModel).Second
                                                       ) :> ICell
                let format (o : TSecond) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Pair.source + ".Second") 
                                               [| _Pair.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Pair.cell
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
    [<ExcelFunction(Name="_Pair_set", Description="Create a Pair",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Pair_set
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Pair",Description = "Reference to Pair")>] 
         pair : obj)
        ([<ExcelArgument(Name="first",Description = "Reference to first")>] 
         first : obj)
        ([<ExcelArgument(Name="second",Description = "Reference to second")>] 
         second : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Pair = Helper.toCell<Pair> pair "Pair"  
                let _first = Helper.toCell<'TFirst> first "first" 
                let _second = Helper.toCell<'TSecond> second "second" 
                let builder () = withMnemonic mnemonic ((_Pair.cell :?> PairModel).Set
                                                            _first.cell 
                                                            _second.cell 
                                                       ) :> ICell
                let format (o : Pair) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Pair.source + ".Set") 
                                               [| _Pair.source
                                               ;  _first.source
                                               ;  _second.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Pair.cell
                                ;  _first.cell
                                ;  _second.cell
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
    [<ExcelFunction(Name="_Pair_Range", Description="Create a range of Pair",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Pair_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Pair")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Pair> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Pair>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Pair>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Pair>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)