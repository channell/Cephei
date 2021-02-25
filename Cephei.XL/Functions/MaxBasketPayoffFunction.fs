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
module MaxBasketPayoffFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_MaxBasketPayoff_accumulate", Description="Create a MaxBasketPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MaxBasketPayoff_accumulate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MaxBasketPayoff",Description = "MaxBasketPayoff")>] 
         maxbasketpayoff : obj)
        ([<ExcelArgument(Name="a",Description = "Vector")>] 
         a : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MaxBasketPayoff = Helper.toModelReference<MaxBasketPayoff> maxbasketpayoff "MaxBasketPayoff"  
                let _a = Helper.toCell<Vector> a "a" 
                let builder (current : ICell) = ((MaxBasketPayoffModel.Cast _MaxBasketPayoff.cell).Accumulate
                                                            _a.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MaxBasketPayoff.source + ".Accumulate") 

                                               [| _a.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MaxBasketPayoff.cell
                                ;  _a.cell
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
    [<ExcelFunction(Name="_MaxBasketPayoff", Description="Create a MaxBasketPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MaxBasketPayoff_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="p",Description = "Payoff")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _p = Helper.toCell<Payoff> p "p" 
                let builder (current : ICell) = (Fun.MaxBasketPayoff 
                                                            _p.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MaxBasketPayoff>) l

                let source () = Helper.sourceFold "Fun.MaxBasketPayoff" 
                                               [| _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _p.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MaxBasketPayoff> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MaxBasketPayoff_basePayoff", Description="Create a MaxBasketPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MaxBasketPayoff_basePayoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MaxBasketPayoff",Description = "MaxBasketPayoff")>] 
         maxbasketpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MaxBasketPayoff = Helper.toModelReference<MaxBasketPayoff> maxbasketpayoff "MaxBasketPayoff"  
                let builder (current : ICell) = ((MaxBasketPayoffModel.Cast _MaxBasketPayoff.cell).BasePayoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source () = Helper.sourceFold (_MaxBasketPayoff.source + ".BasePayoff") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MaxBasketPayoff.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MaxBasketPayoff> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MaxBasketPayoff_description", Description="Create a MaxBasketPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MaxBasketPayoff_description
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MaxBasketPayoff",Description = "MaxBasketPayoff")>] 
         maxbasketpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MaxBasketPayoff = Helper.toModelReference<MaxBasketPayoff> maxbasketpayoff "MaxBasketPayoff"  
                let builder (current : ICell) = ((MaxBasketPayoffModel.Cast _MaxBasketPayoff.cell).Description
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MaxBasketPayoff.source + ".Description") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MaxBasketPayoff.cell
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
    [<ExcelFunction(Name="_MaxBasketPayoff_name", Description="Create a MaxBasketPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MaxBasketPayoff_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MaxBasketPayoff",Description = "MaxBasketPayoff")>] 
         maxbasketpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MaxBasketPayoff = Helper.toModelReference<MaxBasketPayoff> maxbasketpayoff "MaxBasketPayoff"  
                let builder (current : ICell) = ((MaxBasketPayoffModel.Cast _MaxBasketPayoff.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MaxBasketPayoff.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MaxBasketPayoff.cell
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
    [<ExcelFunction(Name="_MaxBasketPayoff_value1", Description="Create a MaxBasketPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MaxBasketPayoff_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MaxBasketPayoff",Description = "MaxBasketPayoff")>] 
         maxbasketpayoff : obj)
        ([<ExcelArgument(Name="a",Description = "Vector")>] 
         a : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MaxBasketPayoff = Helper.toModelReference<MaxBasketPayoff> maxbasketpayoff "MaxBasketPayoff"  
                let _a = Helper.toCell<Vector> a "a" 
                let builder (current : ICell) = ((MaxBasketPayoffModel.Cast _MaxBasketPayoff.cell).Value1
                                                            _a.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MaxBasketPayoff.source + ".Value1") 

                                               [| _a.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MaxBasketPayoff.cell
                                ;  _a.cell
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
    [<ExcelFunction(Name="_MaxBasketPayoff_value", Description="Create a MaxBasketPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MaxBasketPayoff_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MaxBasketPayoff",Description = "MaxBasketPayoff")>] 
         maxbasketpayoff : obj)
        ([<ExcelArgument(Name="price",Description = "double")>] 
         price : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MaxBasketPayoff = Helper.toModelReference<MaxBasketPayoff> maxbasketpayoff "MaxBasketPayoff"  
                let _price = Helper.toCell<double> price "price" 
                let builder (current : ICell) = ((MaxBasketPayoffModel.Cast _MaxBasketPayoff.cell).Value
                                                            _price.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MaxBasketPayoff.source + ".Value") 

                                               [| _price.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MaxBasketPayoff.cell
                                ;  _price.cell
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
    [<ExcelFunction(Name="_MaxBasketPayoff_accept", Description="Create a MaxBasketPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MaxBasketPayoff_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MaxBasketPayoff",Description = "MaxBasketPayoff")>] 
         maxbasketpayoff : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MaxBasketPayoff = Helper.toModelReference<MaxBasketPayoff> maxbasketpayoff "MaxBasketPayoff"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = ((MaxBasketPayoffModel.Cast _MaxBasketPayoff.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : MaxBasketPayoff) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MaxBasketPayoff.source + ".Accept") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MaxBasketPayoff.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_MaxBasketPayoff_Range", Description="Create a range of MaxBasketPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MaxBasketPayoff_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MaxBasketPayoff> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<MaxBasketPayoff> (c)) :> ICell
                let format (i : Cephei.Cell.List<MaxBasketPayoff>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<MaxBasketPayoff>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
