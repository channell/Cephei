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
  purely virtual base class for market observables
  </summary> *)
[<AutoSerializable(true)>]
module QuoteFunction =

    (*
        ! returns true if the Quote holds a valid value, true by default
    *)
    [<ExcelFunction(Name="_Quote_isValid", Description="Create a Quote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Quote_isValid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Quote",Description = "Reference to Quote")>] 
         quote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Quote = Helper.toCell<Quote> quote "Quote"  
                let builder () = withMnemonic mnemonic ((QuoteModel.Cast _Quote.cell).IsValid
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Quote.source + ".IsValid") 
                                               [| _Quote.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Quote.cell
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
    [<ExcelFunction(Name="_Quote_registerWith", Description="Create a Quote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Quote_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Quote",Description = "Reference to Quote")>] 
         quote : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Quote = Helper.toCell<Quote> quote "Quote"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((QuoteModel.Cast _Quote.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Quote) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Quote.source + ".RegisterWith") 
                                               [| _Quote.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Quote.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_Quote_unregisterWith", Description="Create a Quote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Quote_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Quote",Description = "Reference to Quote")>] 
         quote : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Quote = Helper.toCell<Quote> quote "Quote"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((QuoteModel.Cast _Quote.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Quote) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Quote.source + ".UnregisterWith") 
                                               [| _Quote.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Quote.cell
                                ;  _handler.cell
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
        ! returns the current value, 0 by default
    *)
    [<ExcelFunction(Name="_Quote_value", Description="Create a Quote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Quote_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Quote",Description = "Reference to Quote")>] 
         quote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Quote = Helper.toCell<Quote> quote "Quote"  
                let builder () = withMnemonic mnemonic ((QuoteModel.Cast _Quote.cell).Value
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Quote.source + ".Value") 
                                               [| _Quote.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Quote.cell
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
    [<ExcelFunction(Name="_Quote_Range", Description="Create a range of Quote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Quote_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Quote")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Quote> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Quote>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Quote>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Quote>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
