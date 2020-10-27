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
module AverageBasketPayoffFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AverageBasketPayoff_accumulate", Description="Create a AverageBasketPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBasketPayoff_accumulate
        ([<ExcelArgument(Name="Mnemonic",Description = "AverageBasketPayoff")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBasketPayoff",Description = "AverageBasketPayoff")>] 
         averagebasketpayoff : obj)
        ([<ExcelArgument(Name="a",Description = "Vector")>] 
         a : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBasketPayoff = Helper.toCell<AverageBasketPayoff> averagebasketpayoff "AverageBasketPayoff"  
                let _a = Helper.toCell<Vector> a "a" 
                let builder (current : ICell) = withMnemonic mnemonic ((AverageBasketPayoffModel.Cast _AverageBasketPayoff.cell).Accumulate
                                                            _a.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AverageBasketPayoff.source + ".Accumulate") 

                                               [| _a.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBasketPayoff.cell
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
    [<ExcelFunction(Name="_AverageBasketPayoff1", Description="Create a AverageBasketPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBasketPayoff_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "AverageBasketPayoff")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="p",Description = "Payoff")>] 
         p : obj)
        ([<ExcelArgument(Name="n",Description = "int")>] 
         n : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _p = Helper.toCell<Payoff> p "p" 
                let _n = Helper.toCell<int> n "n" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.AverageBasketPayoff1
                                                            _p.cell 
                                                            _n.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AverageBasketPayoff>) l

                let source () = Helper.sourceFold "Fun.AverageBasketPayoff1" 
                                               [| _p.source
                                               ;  _n.source
                                               |]
                let hash = Helper.hashFold 
                                [| _p.cell
                                ;  _n.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AverageBasketPayoff> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AverageBasketPayoff", Description="Create a AverageBasketPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBasketPayoff_create
        ([<ExcelArgument(Name="Mnemonic",Description = "AverageBasketPayoff")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="p",Description = "Payoff")>] 
         p : obj)
        ([<ExcelArgument(Name="a",Description = "Vector")>] 
         a : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _p = Helper.toCell<Payoff> p "p" 
                let _a = Helper.toCell<Vector> a "a" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.AverageBasketPayoff
                                                            _p.cell 
                                                            _a.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AverageBasketPayoff>) l

                let source () = Helper.sourceFold "Fun.AverageBasketPayoff" 
                                               [| _p.source
                                               ;  _a.source
                                               |]
                let hash = Helper.hashFold 
                                [| _p.cell
                                ;  _a.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AverageBasketPayoff> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AverageBasketPayoff_basePayoff", Description="Create a AverageBasketPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBasketPayoff_basePayoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Payoff")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBasketPayoff",Description = "AverageBasketPayoff")>] 
         averagebasketpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBasketPayoff = Helper.toCell<AverageBasketPayoff> averagebasketpayoff "AverageBasketPayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((AverageBasketPayoffModel.Cast _AverageBasketPayoff.cell).BasePayoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source () = Helper.sourceFold (_AverageBasketPayoff.source + ".BasePayoff") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AverageBasketPayoff.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AverageBasketPayoff> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AverageBasketPayoff_description", Description="Create a AverageBasketPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBasketPayoff_description
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBasketPayoff",Description = "AverageBasketPayoff")>] 
         averagebasketpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBasketPayoff = Helper.toCell<AverageBasketPayoff> averagebasketpayoff "AverageBasketPayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((AverageBasketPayoffModel.Cast _AverageBasketPayoff.cell).Description
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AverageBasketPayoff.source + ".Description") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AverageBasketPayoff.cell
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
    [<ExcelFunction(Name="_AverageBasketPayoff_name", Description="Create a AverageBasketPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBasketPayoff_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBasketPayoff",Description = "AverageBasketPayoff")>] 
         averagebasketpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBasketPayoff = Helper.toCell<AverageBasketPayoff> averagebasketpayoff "AverageBasketPayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((AverageBasketPayoffModel.Cast _AverageBasketPayoff.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AverageBasketPayoff.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AverageBasketPayoff.cell
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
    [<ExcelFunction(Name="_AverageBasketPayoff_value1", Description="Create a AverageBasketPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBasketPayoff_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBasketPayoff",Description = "AverageBasketPayoff")>] 
         averagebasketpayoff : obj)
        ([<ExcelArgument(Name="a",Description = "Vector")>] 
         a : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBasketPayoff = Helper.toCell<AverageBasketPayoff> averagebasketpayoff "AverageBasketPayoff"  
                let _a = Helper.toCell<Vector> a "a" 
                let builder (current : ICell) = withMnemonic mnemonic ((AverageBasketPayoffModel.Cast _AverageBasketPayoff.cell).Value1
                                                            _a.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AverageBasketPayoff.source + ".Value1") 

                                               [| _a.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBasketPayoff.cell
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
    [<ExcelFunction(Name="_AverageBasketPayoff_value", Description="Create a AverageBasketPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBasketPayoff_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBasketPayoff",Description = "AverageBasketPayoff")>] 
         averagebasketpayoff : obj)
        ([<ExcelArgument(Name="price",Description = "double")>] 
         price : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBasketPayoff = Helper.toCell<AverageBasketPayoff> averagebasketpayoff "AverageBasketPayoff"  
                let _price = Helper.toCell<double> price "price" 
                let builder (current : ICell) = withMnemonic mnemonic ((AverageBasketPayoffModel.Cast _AverageBasketPayoff.cell).Value
                                                            _price.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AverageBasketPayoff.source + ".Value") 

                                               [| _price.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBasketPayoff.cell
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
    [<ExcelFunction(Name="_AverageBasketPayoff_accept", Description="Create a AverageBasketPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBasketPayoff_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBasketPayoff",Description = "AverageBasketPayoff")>] 
         averagebasketpayoff : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBasketPayoff = Helper.toCell<AverageBasketPayoff> averagebasketpayoff "AverageBasketPayoff"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((AverageBasketPayoffModel.Cast _AverageBasketPayoff.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : AverageBasketPayoff) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AverageBasketPayoff.source + ".Accept") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBasketPayoff.cell
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
    [<ExcelFunction(Name="_AverageBasketPayoff_Range", Description="Create a range of AverageBasketPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBasketPayoff_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AverageBasketPayoff> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AverageBasketPayoff>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<AverageBasketPayoff>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<AverageBasketPayoff>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
