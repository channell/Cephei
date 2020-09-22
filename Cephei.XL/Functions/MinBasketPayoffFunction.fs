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
module MinBasketPayoffFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_MinBasketPayoff_accumulate", Description="Create a MinBasketPayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MinBasketPayoff_accumulate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MinBasketPayoff",Description = "Reference to MinBasketPayoff")>] 
         minbasketpayoff : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MinBasketPayoff = Helper.toCell<MinBasketPayoff> minbasketpayoff "MinBasketPayoff" true 
                let _a = Helper.toCell<Vector> a "a" true
                let builder () = withMnemonic mnemonic ((_MinBasketPayoff.cell :?> MinBasketPayoffModel).Accumulate
                                                            _a.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MinBasketPayoff.source + ".Accumulate") 
                                               [| _MinBasketPayoff.source
                                               ;  _a.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MinBasketPayoff.cell
                                ;  _a.cell
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
    [<ExcelFunction(Name="_MinBasketPayoff", Description="Create a MinBasketPayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MinBasketPayoff_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _p = Helper.toCell<Payoff> p "p" true
                let builder () = withMnemonic mnemonic (Fun.MinBasketPayoff 
                                                            _p.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MinBasketPayoff>) l

                let source = Helper.sourceFold "Fun.MinBasketPayoff" 
                                               [| _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _p.cell
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
    [<ExcelFunction(Name="_MinBasketPayoff_basePayoff", Description="Create a MinBasketPayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MinBasketPayoff_basePayoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MinBasketPayoff",Description = "Reference to MinBasketPayoff")>] 
         minbasketpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MinBasketPayoff = Helper.toCell<MinBasketPayoff> minbasketpayoff "MinBasketPayoff" true 
                let builder () = withMnemonic mnemonic ((_MinBasketPayoff.cell :?> MinBasketPayoffModel).BasePayoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source = Helper.sourceFold (_MinBasketPayoff.source + ".BasePayoff") 
                                               [| _MinBasketPayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MinBasketPayoff.cell
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
    [<ExcelFunction(Name="_MinBasketPayoff_description", Description="Create a MinBasketPayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MinBasketPayoff_description
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MinBasketPayoff",Description = "Reference to MinBasketPayoff")>] 
         minbasketpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MinBasketPayoff = Helper.toCell<MinBasketPayoff> minbasketpayoff "MinBasketPayoff" true 
                let builder () = withMnemonic mnemonic ((_MinBasketPayoff.cell :?> MinBasketPayoffModel).Description
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MinBasketPayoff.source + ".Description") 
                                               [| _MinBasketPayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MinBasketPayoff.cell
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
    [<ExcelFunction(Name="_MinBasketPayoff_name", Description="Create a MinBasketPayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MinBasketPayoff_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MinBasketPayoff",Description = "Reference to MinBasketPayoff")>] 
         minbasketpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MinBasketPayoff = Helper.toCell<MinBasketPayoff> minbasketpayoff "MinBasketPayoff" true 
                let builder () = withMnemonic mnemonic ((_MinBasketPayoff.cell :?> MinBasketPayoffModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MinBasketPayoff.source + ".Name") 
                                               [| _MinBasketPayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MinBasketPayoff.cell
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
    [<ExcelFunction(Name="_MinBasketPayoff_value1", Description="Create a MinBasketPayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MinBasketPayoff_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MinBasketPayoff",Description = "Reference to MinBasketPayoff")>] 
         minbasketpayoff : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MinBasketPayoff = Helper.toCell<MinBasketPayoff> minbasketpayoff "MinBasketPayoff" true 
                let _a = Helper.toCell<Vector> a "a" true
                let builder () = withMnemonic mnemonic ((_MinBasketPayoff.cell :?> MinBasketPayoffModel).Value1
                                                            _a.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MinBasketPayoff.source + ".Value1") 
                                               [| _MinBasketPayoff.source
                                               ;  _a.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MinBasketPayoff.cell
                                ;  _a.cell
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
    [<ExcelFunction(Name="_MinBasketPayoff_value", Description="Create a MinBasketPayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MinBasketPayoff_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MinBasketPayoff",Description = "Reference to MinBasketPayoff")>] 
         minbasketpayoff : obj)
        ([<ExcelArgument(Name="price",Description = "Reference to price")>] 
         price : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MinBasketPayoff = Helper.toCell<MinBasketPayoff> minbasketpayoff "MinBasketPayoff" true 
                let _price = Helper.toCell<double> price "price" true
                let builder () = withMnemonic mnemonic ((_MinBasketPayoff.cell :?> MinBasketPayoffModel).Value
                                                            _price.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MinBasketPayoff.source + ".Value") 
                                               [| _MinBasketPayoff.source
                                               ;  _price.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MinBasketPayoff.cell
                                ;  _price.cell
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
    [<ExcelFunction(Name="_MinBasketPayoff_accept", Description="Create a MinBasketPayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MinBasketPayoff_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MinBasketPayoff",Description = "Reference to MinBasketPayoff")>] 
         minbasketpayoff : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MinBasketPayoff = Helper.toCell<MinBasketPayoff> minbasketpayoff "MinBasketPayoff" true 
                let _v = Helper.toCell<IAcyclicVisitor> v "v" true
                let builder () = withMnemonic mnemonic ((_MinBasketPayoff.cell :?> MinBasketPayoffModel).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : MinBasketPayoff) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MinBasketPayoff.source + ".Accept") 
                                               [| _MinBasketPayoff.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MinBasketPayoff.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_MinBasketPayoff_Range", Description="Create a range of MinBasketPayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MinBasketPayoff_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the MinBasketPayoff")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MinBasketPayoff> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<MinBasketPayoff>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<MinBasketPayoff>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<MinBasketPayoff>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
