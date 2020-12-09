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
  Abstract base class for option payoffs
  </summary> *)
[<AutoSerializable(true)>]
module PayoffFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Payoff_accept", Description="Create a Payoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Payoff_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Payoff",Description = "Payoff")>] 
         payoff : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Payoff = Helper.toCell<Payoff> payoff "Payoff"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((PayoffModel.Cast _Payoff.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : Payoff) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Payoff.source + ".Accept") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Payoff.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_Payoff_description", Description="Create a Payoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Payoff_description
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Payoff",Description = "Payoff")>] 
         payoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Payoff = Helper.toCell<Payoff> payoff "Payoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((PayoffModel.Cast _Payoff.cell).Description
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Payoff.source + ".Description") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Payoff.cell
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
        ! \warning This method is used for output and comparison between payoffs. It is <b>not</b> meant to be used for writing switch-on-type code.
    *)
    [<ExcelFunction(Name="_Payoff_name", Description="Create a Payoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Payoff_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Payoff",Description = "Payoff")>] 
         payoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Payoff = Helper.toCell<Payoff> payoff "Payoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((PayoffModel.Cast _Payoff.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Payoff.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Payoff.cell
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
    [<ExcelFunction(Name="_Payoff_value", Description="Create a Payoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Payoff_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Payoff",Description = "Payoff")>] 
         payoff : obj)
        ([<ExcelArgument(Name="price",Description = "double")>] 
         price : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Payoff = Helper.toCell<Payoff> payoff "Payoff"  
                let _price = Helper.toCell<double> price "price" 
                let builder (current : ICell) = withMnemonic mnemonic ((PayoffModel.Cast _Payoff.cell).Value
                                                            _price.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Payoff.source + ".Value") 

                                               [| _price.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Payoff.cell
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
    [<ExcelFunction(Name="_Payoff_Range", Description="Create a range of Payoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Payoff_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Payoff> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<Payoff> (c)) :> ICell
                let format (i : Generic.List<ICell<Payoff>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<Payoff>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
