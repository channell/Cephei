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
  This payoff is equivalent to being a) long a PlainVanillaPayoff at the first strike (same Call/Put type) and b) short a CashOrNothingPayoff at the first strike (same Call/Put type) with cash payoff equal to the difference between the second and the first strike. this payoff can be negative depending on the strikes
  </summary> *)
[<AutoSerializable(true)>]
module GapPayoffFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GapPayoff_description", Description="Create a GapPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GapPayoff_description
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GapPayoff",Description = "GapPayoff")>] 
         gappayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GapPayoff = Helper.toCell<GapPayoff> gappayoff "GapPayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((GapPayoffModel.Cast _GapPayoff.cell).Description
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GapPayoff.source + ".Description") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GapPayoff.cell
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
    [<ExcelFunction(Name="_GapPayoff", Description="Create a GapPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GapPayoff_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Option.Type: Put, Call")>] 
         Type : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="secondStrike",Description = "double")>] 
         secondStrike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _secondStrike = Helper.toCell<double> secondStrike "secondStrike" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.GapPayoff 
                                                            _Type.cell 
                                                            _strike.cell 
                                                            _secondStrike.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GapPayoff>) l

                let source () = Helper.sourceFold "Fun.GapPayoff" 
                                               [| _Type.source
                                               ;  _strike.source
                                               ;  _secondStrike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _strike.cell
                                ;  _secondStrike.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GapPayoff> format
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
    [<ExcelFunction(Name="_GapPayoff_name", Description="Create a GapPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GapPayoff_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GapPayoff",Description = "GapPayoff")>] 
         gappayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GapPayoff = Helper.toCell<GapPayoff> gappayoff "GapPayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((GapPayoffModel.Cast _GapPayoff.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GapPayoff.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GapPayoff.cell
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
    [<ExcelFunction(Name="_GapPayoff_secondStrike", Description="Create a GapPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GapPayoff_secondStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GapPayoff",Description = "GapPayoff")>] 
         gappayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GapPayoff = Helper.toCell<GapPayoff> gappayoff "GapPayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((GapPayoffModel.Cast _GapPayoff.cell).SecondStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GapPayoff.source + ".SecondStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GapPayoff.cell
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
    [<ExcelFunction(Name="_GapPayoff_value", Description="Create a GapPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GapPayoff_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GapPayoff",Description = "GapPayoff")>] 
         gappayoff : obj)
        ([<ExcelArgument(Name="price",Description = "double")>] 
         price : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GapPayoff = Helper.toCell<GapPayoff> gappayoff "GapPayoff"  
                let _price = Helper.toCell<double> price "price" 
                let builder (current : ICell) = withMnemonic mnemonic ((GapPayoffModel.Cast _GapPayoff.cell).Value
                                                            _price.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GapPayoff.source + ".Value") 

                                               [| _price.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GapPayoff.cell
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
    [<ExcelFunction(Name="_GapPayoff_strike", Description="Create a GapPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GapPayoff_strike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GapPayoff",Description = "GapPayoff")>] 
         gappayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GapPayoff = Helper.toCell<GapPayoff> gappayoff "GapPayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((GapPayoffModel.Cast _GapPayoff.cell).Strike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GapPayoff.source + ".Strike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GapPayoff.cell
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
    [<ExcelFunction(Name="_GapPayoff_optionType", Description="Create a GapPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GapPayoff_optionType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GapPayoff",Description = "GapPayoff")>] 
         gappayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GapPayoff = Helper.toCell<GapPayoff> gappayoff "GapPayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((GapPayoffModel.Cast _GapPayoff.cell).OptionType
                                                       ) :> ICell
                let format (o : Option.Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GapPayoff.source + ".OptionType") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GapPayoff.cell
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
    [<ExcelFunction(Name="_GapPayoff_accept", Description="Create a GapPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GapPayoff_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GapPayoff",Description = "GapPayoff")>] 
         gappayoff : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GapPayoff = Helper.toCell<GapPayoff> gappayoff "GapPayoff"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((GapPayoffModel.Cast _GapPayoff.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : GapPayoff) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GapPayoff.source + ".Accept") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GapPayoff.cell
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
    [<ExcelFunction(Name="_GapPayoff_Range", Description="Create a range of GapPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GapPayoff_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GapPayoff> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<GapPayoff> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<GapPayoff>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<GapPayoff>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
