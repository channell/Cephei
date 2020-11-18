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
  Binary supershare payoff
  </summary> *)
[<AutoSerializable(true)>]
module SuperSharePayoffFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SuperSharePayoff_cashPayoff", Description="Create a SuperSharePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SuperSharePayoff_cashPayoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SuperSharePayoff",Description = "SuperSharePayoff")>] 
         supersharepayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SuperSharePayoff = Helper.toCell<SuperSharePayoff> supersharepayoff "SuperSharePayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((SuperSharePayoffModel.Cast _SuperSharePayoff.cell).CashPayoff
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SuperSharePayoff.source + ".CashPayoff") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SuperSharePayoff.cell
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
    [<ExcelFunction(Name="_SuperSharePayoff_description", Description="Create a SuperSharePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SuperSharePayoff_description
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SuperSharePayoff",Description = "SuperSharePayoff")>] 
         supersharepayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SuperSharePayoff = Helper.toCell<SuperSharePayoff> supersharepayoff "SuperSharePayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((SuperSharePayoffModel.Cast _SuperSharePayoff.cell).Description
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SuperSharePayoff.source + ".Description") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SuperSharePayoff.cell
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
        Payoff interface
    *)
    [<ExcelFunction(Name="_SuperSharePayoff_name", Description="Create a SuperSharePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SuperSharePayoff_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SuperSharePayoff",Description = "SuperSharePayoff")>] 
         supersharepayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SuperSharePayoff = Helper.toCell<SuperSharePayoff> supersharepayoff "SuperSharePayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((SuperSharePayoffModel.Cast _SuperSharePayoff.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SuperSharePayoff.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SuperSharePayoff.cell
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
    [<ExcelFunction(Name="_SuperSharePayoff_secondStrike", Description="Create a SuperSharePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SuperSharePayoff_secondStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SuperSharePayoff",Description = "SuperSharePayoff")>] 
         supersharepayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SuperSharePayoff = Helper.toCell<SuperSharePayoff> supersharepayoff "SuperSharePayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((SuperSharePayoffModel.Cast _SuperSharePayoff.cell).SecondStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SuperSharePayoff.source + ".SecondStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SuperSharePayoff.cell
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
    [<ExcelFunction(Name="_SuperSharePayoff", Description="Create a SuperSharePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SuperSharePayoff_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="secondStrike",Description = "double")>] 
         secondStrike : obj)
        ([<ExcelArgument(Name="cashPayoff",Description = "double")>] 
         cashPayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _strike = Helper.toCell<double> strike "strike" 
                let _secondStrike = Helper.toCell<double> secondStrike "secondStrike" 
                let _cashPayoff = Helper.toCell<double> cashPayoff "cashPayoff" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SuperSharePayoff 
                                                            _strike.cell 
                                                            _secondStrike.cell 
                                                            _cashPayoff.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SuperSharePayoff>) l

                let source () = Helper.sourceFold "Fun.SuperSharePayoff" 
                                               [| _strike.source
                                               ;  _secondStrike.source
                                               ;  _cashPayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _strike.cell
                                ;  _secondStrike.cell
                                ;  _cashPayoff.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SuperSharePayoff> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SuperSharePayoff_value", Description="Create a SuperSharePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SuperSharePayoff_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SuperSharePayoff",Description = "SuperSharePayoff")>] 
         supersharepayoff : obj)
        ([<ExcelArgument(Name="price",Description = "double")>] 
         price : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SuperSharePayoff = Helper.toCell<SuperSharePayoff> supersharepayoff "SuperSharePayoff"  
                let _price = Helper.toCell<double> price "price" 
                let builder (current : ICell) = withMnemonic mnemonic ((SuperSharePayoffModel.Cast _SuperSharePayoff.cell).Value
                                                            _price.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SuperSharePayoff.source + ".Value") 

                                               [| _price.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SuperSharePayoff.cell
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
    [<ExcelFunction(Name="_SuperSharePayoff_strike", Description="Create a SuperSharePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SuperSharePayoff_strike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SuperSharePayoff",Description = "SuperSharePayoff")>] 
         supersharepayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SuperSharePayoff = Helper.toCell<SuperSharePayoff> supersharepayoff "SuperSharePayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((SuperSharePayoffModel.Cast _SuperSharePayoff.cell).Strike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SuperSharePayoff.source + ".Strike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SuperSharePayoff.cell
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
    [<ExcelFunction(Name="_SuperSharePayoff_optionType", Description="Create a SuperSharePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SuperSharePayoff_optionType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SuperSharePayoff",Description = "SuperSharePayoff")>] 
         supersharepayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SuperSharePayoff = Helper.toCell<SuperSharePayoff> supersharepayoff "SuperSharePayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((SuperSharePayoffModel.Cast _SuperSharePayoff.cell).OptionType
                                                       ) :> ICell
                let format (o : Option.Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SuperSharePayoff.source + ".OptionType") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SuperSharePayoff.cell
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
    [<ExcelFunction(Name="_SuperSharePayoff_accept", Description="Create a SuperSharePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SuperSharePayoff_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SuperSharePayoff",Description = "SuperSharePayoff")>] 
         supersharepayoff : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SuperSharePayoff = Helper.toCell<SuperSharePayoff> supersharepayoff "SuperSharePayoff"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((SuperSharePayoffModel.Cast _SuperSharePayoff.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : SuperSharePayoff) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SuperSharePayoff.source + ".Accept") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SuperSharePayoff.cell
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
    [<ExcelFunction(Name="_SuperSharePayoff_Range", Description="Create a range of SuperSharePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SuperSharePayoff_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SuperSharePayoff> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<SuperSharePayoff> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<SuperSharePayoff>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<SuperSharePayoff>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
