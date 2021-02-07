﻿(*
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
module MTLCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_MTLCurrency", Description="Create a MTLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MTLCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.MTLCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MTLCurrency>) l

                let source () = Helper.sourceFold "Fun.MTLCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MTLCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! currency name, e.g, "U.S. Dollar"
    *)
    [<ExcelFunction(Name="_MTLCurrency_code", Description="Create a MTLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MTLCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MTLCurrency",Description = "MTLCurrency")>] 
         mtlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MTLCurrency = Helper.toCell<MTLCurrency> mtlcurrency "MTLCurrency"  
                let builder (current : ICell) = ((MTLCurrencyModel.Cast _MTLCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MTLCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MTLCurrency.cell
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
        ! Other information ! is this a usable instance?
    *)
    [<ExcelFunction(Name="_MTLCurrency_empty", Description="Create a MTLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MTLCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MTLCurrency",Description = "MTLCurrency")>] 
         mtlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MTLCurrency = Helper.toCell<MTLCurrency> mtlcurrency "MTLCurrency"  
                let builder (current : ICell) = ((MTLCurrencyModel.Cast _MTLCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MTLCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MTLCurrency.cell
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
    [<ExcelFunction(Name="_MTLCurrency_Equals", Description="Create a MTLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MTLCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MTLCurrency",Description = "MTLCurrency")>] 
         mtlcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MTLCurrency = Helper.toCell<MTLCurrency> mtlcurrency "MTLCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = ((MTLCurrencyModel.Cast _MTLCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MTLCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MTLCurrency.cell
                                ;  _o.cell
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
        ! currency used for triangulated exchange when required output format The format will be fed three positional parameters, namely, value, code, and symbol, in this order.
    *)
    [<ExcelFunction(Name="_MTLCurrency_format", Description="Create a MTLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MTLCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MTLCurrency",Description = "MTLCurrency")>] 
         mtlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MTLCurrency = Helper.toCell<MTLCurrency> mtlcurrency "MTLCurrency"  
                let builder (current : ICell) = ((MTLCurrencyModel.Cast _MTLCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MTLCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MTLCurrency.cell
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
        ! fraction symbol, e.g, "Â¢"
    *)
    [<ExcelFunction(Name="_MTLCurrency_fractionsPerUnit", Description="Create a MTLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MTLCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MTLCurrency",Description = "MTLCurrency")>] 
         mtlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MTLCurrency = Helper.toCell<MTLCurrency> mtlcurrency "MTLCurrency"  
                let builder (current : ICell) = ((MTLCurrencyModel.Cast _MTLCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MTLCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MTLCurrency.cell
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
        ! symbol, e.g, "$"
    *)
    [<ExcelFunction(Name="_MTLCurrency_fractionSymbol", Description="Create a MTLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MTLCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MTLCurrency",Description = "MTLCurrency")>] 
         mtlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MTLCurrency = Helper.toCell<MTLCurrency> mtlcurrency "MTLCurrency"  
                let builder (current : ICell) = ((MTLCurrencyModel.Cast _MTLCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MTLCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MTLCurrency.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_MTLCurrency_name", Description="Create a MTLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MTLCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MTLCurrency",Description = "MTLCurrency")>] 
         mtlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MTLCurrency = Helper.toCell<MTLCurrency> mtlcurrency "MTLCurrency"  
                let builder (current : ICell) = ((MTLCurrencyModel.Cast _MTLCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MTLCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MTLCurrency.cell
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
        ! ISO 4217 three-letter code, e.g, "USD"
    *)
    [<ExcelFunction(Name="_MTLCurrency_numericCode", Description="Create a MTLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MTLCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MTLCurrency",Description = "MTLCurrency")>] 
         mtlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MTLCurrency = Helper.toCell<MTLCurrency> mtlcurrency "MTLCurrency"  
                let builder (current : ICell) = ((MTLCurrencyModel.Cast _MTLCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MTLCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MTLCurrency.cell
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
        ! number of fractionary parts in a unit, e.g, 100
    *)
    [<ExcelFunction(Name="_MTLCurrency_rounding", Description="Create a MTLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MTLCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MTLCurrency",Description = "MTLCurrency")>] 
         mtlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MTLCurrency = Helper.toCell<MTLCurrency> mtlcurrency "MTLCurrency"  
                let builder (current : ICell) = ((MTLCurrencyModel.Cast _MTLCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_MTLCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MTLCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MTLCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! ISO 4217 numeric code, e.g, "840"
    *)
    [<ExcelFunction(Name="_MTLCurrency_symbol", Description="Create a MTLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MTLCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MTLCurrency",Description = "MTLCurrency")>] 
         mtlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MTLCurrency = Helper.toCell<MTLCurrency> mtlcurrency "MTLCurrency"  
                let builder (current : ICell) = ((MTLCurrencyModel.Cast _MTLCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MTLCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MTLCurrency.cell
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
    [<ExcelFunction(Name="_MTLCurrency_ToString", Description="Create a MTLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MTLCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MTLCurrency",Description = "MTLCurrency")>] 
         mtlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MTLCurrency = Helper.toCell<MTLCurrency> mtlcurrency "MTLCurrency"  
                let builder (current : ICell) = ((MTLCurrencyModel.Cast _MTLCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MTLCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MTLCurrency.cell
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
        ! rounding convention
    *)
    [<ExcelFunction(Name="_MTLCurrency_triangulationCurrency", Description="Create a MTLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MTLCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MTLCurrency",Description = "MTLCurrency")>] 
         mtlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MTLCurrency = Helper.toCell<MTLCurrency> mtlcurrency "MTLCurrency"  
                let builder (current : ICell) = ((MTLCurrencyModel.Cast _MTLCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_MTLCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MTLCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MTLCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_MTLCurrency_Range", Description="Create a range of MTLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MTLCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MTLCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<MTLCurrency> (c)) :> ICell
                let format (i : Cephei.Cell.List<MTLCurrency>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<MTLCurrency>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
