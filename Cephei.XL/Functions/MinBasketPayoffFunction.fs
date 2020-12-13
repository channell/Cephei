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
    [<ExcelFunction(Name="_MinBasketPayoff_accumulate", Description="Create a MinBasketPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MinBasketPayoff_accumulate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MinBasketPayoff",Description = "MinBasketPayoff")>] 
         minbasketpayoff : obj)
        ([<ExcelArgument(Name="a",Description = "Vector")>] 
         a : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MinBasketPayoff = Helper.toCell<MinBasketPayoff> minbasketpayoff "MinBasketPayoff"  
                let _a = Helper.toCell<Vector> a "a" 
                let builder (current : ICell) = withMnemonic mnemonic ((MinBasketPayoffModel.Cast _MinBasketPayoff.cell).Accumulate
                                                            _a.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MinBasketPayoff.source + ".Accumulate") 

                                               [| _a.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MinBasketPayoff.cell
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
    [<ExcelFunction(Name="_MinBasketPayoff", Description="Create a MinBasketPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MinBasketPayoff_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="p",Description = "Payoff")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _p = Helper.toCell<Payoff> p "p" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.MinBasketPayoff 
                                                            _p.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MinBasketPayoff>) l

                let source () = Helper.sourceFold "Fun.MinBasketPayoff" 
                                               [| _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _p.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MinBasketPayoff> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MinBasketPayoff_basePayoff", Description="Create a MinBasketPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MinBasketPayoff_basePayoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MinBasketPayoff",Description = "MinBasketPayoff")>] 
         minbasketpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MinBasketPayoff = Helper.toCell<MinBasketPayoff> minbasketpayoff "MinBasketPayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((MinBasketPayoffModel.Cast _MinBasketPayoff.cell).BasePayoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source () = Helper.sourceFold (_MinBasketPayoff.source + ".BasePayoff") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MinBasketPayoff.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MinBasketPayoff> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MinBasketPayoff_description", Description="Create a MinBasketPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MinBasketPayoff_description
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MinBasketPayoff",Description = "MinBasketPayoff")>] 
         minbasketpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MinBasketPayoff = Helper.toCell<MinBasketPayoff> minbasketpayoff "MinBasketPayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((MinBasketPayoffModel.Cast _MinBasketPayoff.cell).Description
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MinBasketPayoff.source + ".Description") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MinBasketPayoff.cell
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
    [<ExcelFunction(Name="_MinBasketPayoff_name", Description="Create a MinBasketPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MinBasketPayoff_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MinBasketPayoff",Description = "MinBasketPayoff")>] 
         minbasketpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MinBasketPayoff = Helper.toCell<MinBasketPayoff> minbasketpayoff "MinBasketPayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((MinBasketPayoffModel.Cast _MinBasketPayoff.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MinBasketPayoff.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MinBasketPayoff.cell
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
    [<ExcelFunction(Name="_MinBasketPayoff_value1", Description="Create a MinBasketPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MinBasketPayoff_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MinBasketPayoff",Description = "MinBasketPayoff")>] 
         minbasketpayoff : obj)
        ([<ExcelArgument(Name="a",Description = "Vector")>] 
         a : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MinBasketPayoff = Helper.toCell<MinBasketPayoff> minbasketpayoff "MinBasketPayoff"  
                let _a = Helper.toCell<Vector> a "a" 
                let builder (current : ICell) = withMnemonic mnemonic ((MinBasketPayoffModel.Cast _MinBasketPayoff.cell).Value1
                                                            _a.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MinBasketPayoff.source + ".Value1") 

                                               [| _a.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MinBasketPayoff.cell
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
    [<ExcelFunction(Name="_MinBasketPayoff_value", Description="Create a MinBasketPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MinBasketPayoff_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MinBasketPayoff",Description = "MinBasketPayoff")>] 
         minbasketpayoff : obj)
        ([<ExcelArgument(Name="price",Description = "double")>] 
         price : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MinBasketPayoff = Helper.toCell<MinBasketPayoff> minbasketpayoff "MinBasketPayoff"  
                let _price = Helper.toCell<double> price "price" 
                let builder (current : ICell) = withMnemonic mnemonic ((MinBasketPayoffModel.Cast _MinBasketPayoff.cell).Value
                                                            _price.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MinBasketPayoff.source + ".Value") 

                                               [| _price.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MinBasketPayoff.cell
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
    [<ExcelFunction(Name="_MinBasketPayoff_accept", Description="Create a MinBasketPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MinBasketPayoff_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MinBasketPayoff",Description = "MinBasketPayoff")>] 
         minbasketpayoff : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MinBasketPayoff = Helper.toCell<MinBasketPayoff> minbasketpayoff "MinBasketPayoff"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((MinBasketPayoffModel.Cast _MinBasketPayoff.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : MinBasketPayoff) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MinBasketPayoff.source + ".Accept") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MinBasketPayoff.cell
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
    [<ExcelFunction(Name="_MinBasketPayoff_Range", Description="Create a range of MinBasketPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MinBasketPayoff_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MinBasketPayoff> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<MinBasketPayoff> (c)) :> ICell
                let format (i : Cephei.Cell.List<MinBasketPayoff>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<MinBasketPayoff>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
