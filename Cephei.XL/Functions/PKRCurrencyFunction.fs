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
  The ISO three-letter code is PKR; the numeric code is 586. It is divided in 100 paisa.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module PKRCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_PKRCurrency", Description="Create a PKRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PKRCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.PKRCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PKRCurrency>) l

                let source () = Helper.sourceFold "Fun.PKRCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PKRCurrency> format
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
    [<ExcelFunction(Name="_PKRCurrency_code", Description="Create a PKRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PKRCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PKRCurrency",Description = "PKRCurrency")>] 
         pkrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PKRCurrency = Helper.toModelReference<PKRCurrency> pkrcurrency "PKRCurrency"  
                let builder (current : ICell) = ((PKRCurrencyModel.Cast _PKRCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PKRCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PKRCurrency.cell
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
    [<ExcelFunction(Name="_PKRCurrency_empty", Description="Create a PKRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PKRCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PKRCurrency",Description = "PKRCurrency")>] 
         pkrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PKRCurrency = Helper.toModelReference<PKRCurrency> pkrcurrency "PKRCurrency"  
                let builder (current : ICell) = ((PKRCurrencyModel.Cast _PKRCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PKRCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PKRCurrency.cell
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
    [<ExcelFunction(Name="_PKRCurrency_Equals", Description="Create a PKRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PKRCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PKRCurrency",Description = "PKRCurrency")>] 
         pkrcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PKRCurrency = Helper.toModelReference<PKRCurrency> pkrcurrency "PKRCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = ((PKRCurrencyModel.Cast _PKRCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PKRCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PKRCurrency.cell
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
    [<ExcelFunction(Name="_PKRCurrency_format", Description="Create a PKRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PKRCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PKRCurrency",Description = "PKRCurrency")>] 
         pkrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PKRCurrency = Helper.toModelReference<PKRCurrency> pkrcurrency "PKRCurrency"  
                let builder (current : ICell) = ((PKRCurrencyModel.Cast _PKRCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PKRCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PKRCurrency.cell
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
    [<ExcelFunction(Name="_PKRCurrency_fractionsPerUnit", Description="Create a PKRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PKRCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PKRCurrency",Description = "PKRCurrency")>] 
         pkrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PKRCurrency = Helper.toModelReference<PKRCurrency> pkrcurrency "PKRCurrency"  
                let builder (current : ICell) = ((PKRCurrencyModel.Cast _PKRCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PKRCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PKRCurrency.cell
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
    [<ExcelFunction(Name="_PKRCurrency_fractionSymbol", Description="Create a PKRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PKRCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PKRCurrency",Description = "PKRCurrency")>] 
         pkrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PKRCurrency = Helper.toModelReference<PKRCurrency> pkrcurrency "PKRCurrency"  
                let builder (current : ICell) = ((PKRCurrencyModel.Cast _PKRCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PKRCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PKRCurrency.cell
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
    [<ExcelFunction(Name="_PKRCurrency_name", Description="Create a PKRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PKRCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PKRCurrency",Description = "PKRCurrency")>] 
         pkrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PKRCurrency = Helper.toModelReference<PKRCurrency> pkrcurrency "PKRCurrency"  
                let builder (current : ICell) = ((PKRCurrencyModel.Cast _PKRCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PKRCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PKRCurrency.cell
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
    [<ExcelFunction(Name="_PKRCurrency_numericCode", Description="Create a PKRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PKRCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PKRCurrency",Description = "PKRCurrency")>] 
         pkrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PKRCurrency = Helper.toModelReference<PKRCurrency> pkrcurrency "PKRCurrency"  
                let builder (current : ICell) = ((PKRCurrencyModel.Cast _PKRCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PKRCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PKRCurrency.cell
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
    [<ExcelFunction(Name="_PKRCurrency_rounding", Description="Create a PKRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PKRCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PKRCurrency",Description = "PKRCurrency")>] 
         pkrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PKRCurrency = Helper.toModelReference<PKRCurrency> pkrcurrency "PKRCurrency"  
                let builder (current : ICell) = ((PKRCurrencyModel.Cast _PKRCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_PKRCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PKRCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PKRCurrency> format
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
    [<ExcelFunction(Name="_PKRCurrency_symbol", Description="Create a PKRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PKRCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PKRCurrency",Description = "PKRCurrency")>] 
         pkrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PKRCurrency = Helper.toModelReference<PKRCurrency> pkrcurrency "PKRCurrency"  
                let builder (current : ICell) = ((PKRCurrencyModel.Cast _PKRCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PKRCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PKRCurrency.cell
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
    [<ExcelFunction(Name="_PKRCurrency_ToString", Description="Create a PKRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PKRCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PKRCurrency",Description = "PKRCurrency")>] 
         pkrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PKRCurrency = Helper.toModelReference<PKRCurrency> pkrcurrency "PKRCurrency"  
                let builder (current : ICell) = ((PKRCurrencyModel.Cast _PKRCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PKRCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PKRCurrency.cell
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
    [<ExcelFunction(Name="_PKRCurrency_triangulationCurrency", Description="Create a PKRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PKRCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PKRCurrency",Description = "PKRCurrency")>] 
         pkrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PKRCurrency = Helper.toModelReference<PKRCurrency> pkrcurrency "PKRCurrency"  
                let builder (current : ICell) = ((PKRCurrencyModel.Cast _PKRCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_PKRCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PKRCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PKRCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_PKRCurrency_Range", Description="Create a range of PKRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PKRCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PKRCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<PKRCurrency> (c)) :> ICell
                let format (i : Cephei.Cell.List<PKRCurrency>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<PKRCurrency>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
