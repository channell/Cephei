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
module SpreadBasketPayoffFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SpreadBasketPayoff_accumulate", Description="Create a SpreadBasketPayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadBasketPayoff_accumulate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadBasketPayoff",Description = "Reference to SpreadBasketPayoff")>] 
         spreadbasketpayoff : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadBasketPayoff = Helper.toCell<SpreadBasketPayoff> spreadbasketpayoff "SpreadBasketPayoff"  
                let _a = Helper.toCell<Vector> a "a" 
                let builder () = withMnemonic mnemonic ((_SpreadBasketPayoff.cell :?> SpreadBasketPayoffModel).Accumulate
                                                            _a.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadBasketPayoff.source + ".Accumulate") 
                                               [| _SpreadBasketPayoff.source
                                               ;  _a.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadBasketPayoff.cell
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
    [<ExcelFunction(Name="_SpreadBasketPayoff", Description="Create a SpreadBasketPayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadBasketPayoff_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _p = Helper.toCell<Payoff> p "p" 
                let builder () = withMnemonic mnemonic (Fun.SpreadBasketPayoff 
                                                            _p.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SpreadBasketPayoff>) l

                let source = Helper.sourceFold "Fun.SpreadBasketPayoff" 
                                               [| _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _p.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SpreadBasketPayoff> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SpreadBasketPayoff_basePayoff", Description="Create a SpreadBasketPayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadBasketPayoff_basePayoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadBasketPayoff",Description = "Reference to SpreadBasketPayoff")>] 
         spreadbasketpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadBasketPayoff = Helper.toCell<SpreadBasketPayoff> spreadbasketpayoff "SpreadBasketPayoff"  
                let builder () = withMnemonic mnemonic ((_SpreadBasketPayoff.cell :?> SpreadBasketPayoffModel).BasePayoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source = Helper.sourceFold (_SpreadBasketPayoff.source + ".BasePayoff") 
                                               [| _SpreadBasketPayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadBasketPayoff.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SpreadBasketPayoff> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SpreadBasketPayoff_description", Description="Create a SpreadBasketPayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadBasketPayoff_description
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadBasketPayoff",Description = "Reference to SpreadBasketPayoff")>] 
         spreadbasketpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadBasketPayoff = Helper.toCell<SpreadBasketPayoff> spreadbasketpayoff "SpreadBasketPayoff"  
                let builder () = withMnemonic mnemonic ((_SpreadBasketPayoff.cell :?> SpreadBasketPayoffModel).Description
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SpreadBasketPayoff.source + ".Description") 
                                               [| _SpreadBasketPayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadBasketPayoff.cell
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
    [<ExcelFunction(Name="_SpreadBasketPayoff_name", Description="Create a SpreadBasketPayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadBasketPayoff_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadBasketPayoff",Description = "Reference to SpreadBasketPayoff")>] 
         spreadbasketpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadBasketPayoff = Helper.toCell<SpreadBasketPayoff> spreadbasketpayoff "SpreadBasketPayoff"  
                let builder () = withMnemonic mnemonic ((_SpreadBasketPayoff.cell :?> SpreadBasketPayoffModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SpreadBasketPayoff.source + ".Name") 
                                               [| _SpreadBasketPayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadBasketPayoff.cell
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
    [<ExcelFunction(Name="_SpreadBasketPayoff_value1", Description="Create a SpreadBasketPayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadBasketPayoff_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadBasketPayoff",Description = "Reference to SpreadBasketPayoff")>] 
         spreadbasketpayoff : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadBasketPayoff = Helper.toCell<SpreadBasketPayoff> spreadbasketpayoff "SpreadBasketPayoff"  
                let _a = Helper.toCell<Vector> a "a" 
                let builder () = withMnemonic mnemonic ((_SpreadBasketPayoff.cell :?> SpreadBasketPayoffModel).Value1
                                                            _a.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadBasketPayoff.source + ".Value1") 
                                               [| _SpreadBasketPayoff.source
                                               ;  _a.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadBasketPayoff.cell
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
    [<ExcelFunction(Name="_SpreadBasketPayoff_value", Description="Create a SpreadBasketPayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadBasketPayoff_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadBasketPayoff",Description = "Reference to SpreadBasketPayoff")>] 
         spreadbasketpayoff : obj)
        ([<ExcelArgument(Name="price",Description = "Reference to price")>] 
         price : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadBasketPayoff = Helper.toCell<SpreadBasketPayoff> spreadbasketpayoff "SpreadBasketPayoff"  
                let _price = Helper.toCell<double> price "price" 
                let builder () = withMnemonic mnemonic ((_SpreadBasketPayoff.cell :?> SpreadBasketPayoffModel).Value
                                                            _price.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SpreadBasketPayoff.source + ".Value") 
                                               [| _SpreadBasketPayoff.source
                                               ;  _price.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadBasketPayoff.cell
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
    [<ExcelFunction(Name="_SpreadBasketPayoff_accept", Description="Create a SpreadBasketPayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadBasketPayoff_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadBasketPayoff",Description = "Reference to SpreadBasketPayoff")>] 
         spreadbasketpayoff : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadBasketPayoff = Helper.toCell<SpreadBasketPayoff> spreadbasketpayoff "SpreadBasketPayoff"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder () = withMnemonic mnemonic ((_SpreadBasketPayoff.cell :?> SpreadBasketPayoffModel).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : SpreadBasketPayoff) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SpreadBasketPayoff.source + ".Accept") 
                                               [| _SpreadBasketPayoff.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadBasketPayoff.cell
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
    [<ExcelFunction(Name="_SpreadBasketPayoff_Range", Description="Create a range of SpreadBasketPayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SpreadBasketPayoff_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SpreadBasketPayoff")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SpreadBasketPayoff> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SpreadBasketPayoff>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SpreadBasketPayoff>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SpreadBasketPayoff>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
