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
  %Payoff with strike expressed as percentage
  </summary> *)
[<AutoSerializable(true)>]
module PercentageStrikePayoffFunction =

    (*
        Payoff interface
    *)
    [<ExcelFunction(Name="_PercentageStrikePayoff_name", Description="Create a PercentageStrikePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PercentageStrikePayoff_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PercentageStrikePayoff",Description = "PercentageStrikePayoff")>] 
         percentagestrikepayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PercentageStrikePayoff = Helper.toCell<PercentageStrikePayoff> percentagestrikepayoff "PercentageStrikePayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((PercentageStrikePayoffModel.Cast _PercentageStrikePayoff.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PercentageStrikePayoff.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PercentageStrikePayoff.cell
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
    [<ExcelFunction(Name="_PercentageStrikePayoff", Description="Create a PercentageStrikePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PercentageStrikePayoff_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Option.Type: Put, Call")>] 
         Type : obj)
        ([<ExcelArgument(Name="moneyness",Description = "double")>] 
         moneyness : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _moneyness = Helper.toCell<double> moneyness "moneyness" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.PercentageStrikePayoff 
                                                            _Type.cell 
                                                            _moneyness.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PercentageStrikePayoff>) l

                let source () = Helper.sourceFold "Fun.PercentageStrikePayoff" 
                                               [| _Type.source
                                               ;  _moneyness.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _moneyness.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PercentageStrikePayoff> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PercentageStrikePayoff_value", Description="Create a PercentageStrikePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PercentageStrikePayoff_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PercentageStrikePayoff",Description = "PercentageStrikePayoff")>] 
         percentagestrikepayoff : obj)
        ([<ExcelArgument(Name="price",Description = "double")>] 
         price : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PercentageStrikePayoff = Helper.toCell<PercentageStrikePayoff> percentagestrikepayoff "PercentageStrikePayoff"  
                let _price = Helper.toCell<double> price "price" 
                let builder (current : ICell) = withMnemonic mnemonic ((PercentageStrikePayoffModel.Cast _PercentageStrikePayoff.cell).Value
                                                            _price.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PercentageStrikePayoff.source + ".Value") 

                                               [| _price.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PercentageStrikePayoff.cell
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
        Payoff interface
    *)
    [<ExcelFunction(Name="_PercentageStrikePayoff_description", Description="Create a PercentageStrikePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PercentageStrikePayoff_description
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PercentageStrikePayoff",Description = "PercentageStrikePayoff")>] 
         percentagestrikepayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PercentageStrikePayoff = Helper.toCell<PercentageStrikePayoff> percentagestrikepayoff "PercentageStrikePayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((PercentageStrikePayoffModel.Cast _PercentageStrikePayoff.cell).Description
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PercentageStrikePayoff.source + ".Description") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PercentageStrikePayoff.cell
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
    [<ExcelFunction(Name="_PercentageStrikePayoff_strike", Description="Create a PercentageStrikePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PercentageStrikePayoff_strike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PercentageStrikePayoff",Description = "PercentageStrikePayoff")>] 
         percentagestrikepayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PercentageStrikePayoff = Helper.toCell<PercentageStrikePayoff> percentagestrikepayoff "PercentageStrikePayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((PercentageStrikePayoffModel.Cast _PercentageStrikePayoff.cell).Strike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PercentageStrikePayoff.source + ".Strike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PercentageStrikePayoff.cell
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
    [<ExcelFunction(Name="_PercentageStrikePayoff_optionType", Description="Create a PercentageStrikePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PercentageStrikePayoff_optionType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PercentageStrikePayoff",Description = "PercentageStrikePayoff")>] 
         percentagestrikepayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PercentageStrikePayoff = Helper.toCell<PercentageStrikePayoff> percentagestrikepayoff "PercentageStrikePayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((PercentageStrikePayoffModel.Cast _PercentageStrikePayoff.cell).OptionType
                                                       ) :> ICell
                let format (o : Option.Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PercentageStrikePayoff.source + ".OptionType") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PercentageStrikePayoff.cell
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
    [<ExcelFunction(Name="_PercentageStrikePayoff_accept", Description="Create a PercentageStrikePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PercentageStrikePayoff_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PercentageStrikePayoff",Description = "PercentageStrikePayoff")>] 
         percentagestrikepayoff : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PercentageStrikePayoff = Helper.toCell<PercentageStrikePayoff> percentagestrikepayoff "PercentageStrikePayoff"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((PercentageStrikePayoffModel.Cast _PercentageStrikePayoff.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : PercentageStrikePayoff) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PercentageStrikePayoff.source + ".Accept") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PercentageStrikePayoff.cell
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
    [<ExcelFunction(Name="_PercentageStrikePayoff_Range", Description="Create a range of PercentageStrikePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PercentageStrikePayoff_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PercentageStrikePayoff> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<PercentageStrikePayoff>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<PercentageStrikePayoff>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<PercentageStrikePayoff>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
