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
  The ISO three-letter code is SAR; the numeric code is 682. It is divided in 100 halalat.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module SARCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SARCurrency", Description="Create a SARCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SARCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.SARCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SARCurrency>) l

                let source () = Helper.sourceFold "Fun.SARCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SARCurrency> format
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
    [<ExcelFunction(Name="_SARCurrency_code", Description="Create a SARCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SARCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SARCurrency",Description = "SARCurrency")>] 
         sarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SARCurrency = Helper.toModelReference<SARCurrency> sarcurrency "SARCurrency"  
                let builder (current : ICell) = ((SARCurrencyModel.Cast _SARCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SARCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SARCurrency.cell
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
    [<ExcelFunction(Name="_SARCurrency_empty", Description="Create a SARCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SARCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SARCurrency",Description = "SARCurrency")>] 
         sarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SARCurrency = Helper.toModelReference<SARCurrency> sarcurrency "SARCurrency"  
                let builder (current : ICell) = ((SARCurrencyModel.Cast _SARCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SARCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SARCurrency.cell
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
    [<ExcelFunction(Name="_SARCurrency_Equals", Description="Create a SARCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SARCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SARCurrency",Description = "SARCurrency")>] 
         sarcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SARCurrency = Helper.toModelReference<SARCurrency> sarcurrency "SARCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = ((SARCurrencyModel.Cast _SARCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SARCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SARCurrency.cell
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
    [<ExcelFunction(Name="_SARCurrency_format", Description="Create a SARCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SARCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SARCurrency",Description = "SARCurrency")>] 
         sarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SARCurrency = Helper.toModelReference<SARCurrency> sarcurrency "SARCurrency"  
                let builder (current : ICell) = ((SARCurrencyModel.Cast _SARCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SARCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SARCurrency.cell
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
    [<ExcelFunction(Name="_SARCurrency_fractionsPerUnit", Description="Create a SARCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SARCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SARCurrency",Description = "SARCurrency")>] 
         sarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SARCurrency = Helper.toModelReference<SARCurrency> sarcurrency "SARCurrency"  
                let builder (current : ICell) = ((SARCurrencyModel.Cast _SARCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SARCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SARCurrency.cell
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
    [<ExcelFunction(Name="_SARCurrency_fractionSymbol", Description="Create a SARCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SARCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SARCurrency",Description = "SARCurrency")>] 
         sarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SARCurrency = Helper.toModelReference<SARCurrency> sarcurrency "SARCurrency"  
                let builder (current : ICell) = ((SARCurrencyModel.Cast _SARCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SARCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SARCurrency.cell
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
    [<ExcelFunction(Name="_SARCurrency_name", Description="Create a SARCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SARCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SARCurrency",Description = "SARCurrency")>] 
         sarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SARCurrency = Helper.toModelReference<SARCurrency> sarcurrency "SARCurrency"  
                let builder (current : ICell) = ((SARCurrencyModel.Cast _SARCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SARCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SARCurrency.cell
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
    [<ExcelFunction(Name="_SARCurrency_numericCode", Description="Create a SARCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SARCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SARCurrency",Description = "SARCurrency")>] 
         sarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SARCurrency = Helper.toModelReference<SARCurrency> sarcurrency "SARCurrency"  
                let builder (current : ICell) = ((SARCurrencyModel.Cast _SARCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SARCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SARCurrency.cell
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
    [<ExcelFunction(Name="_SARCurrency_rounding", Description="Create a SARCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SARCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SARCurrency",Description = "SARCurrency")>] 
         sarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SARCurrency = Helper.toModelReference<SARCurrency> sarcurrency "SARCurrency"  
                let builder (current : ICell) = ((SARCurrencyModel.Cast _SARCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_SARCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SARCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SARCurrency> format
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
    [<ExcelFunction(Name="_SARCurrency_symbol", Description="Create a SARCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SARCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SARCurrency",Description = "SARCurrency")>] 
         sarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SARCurrency = Helper.toModelReference<SARCurrency> sarcurrency "SARCurrency"  
                let builder (current : ICell) = ((SARCurrencyModel.Cast _SARCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SARCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SARCurrency.cell
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
    [<ExcelFunction(Name="_SARCurrency_ToString", Description="Create a SARCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SARCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SARCurrency",Description = "SARCurrency")>] 
         sarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SARCurrency = Helper.toModelReference<SARCurrency> sarcurrency "SARCurrency"  
                let builder (current : ICell) = ((SARCurrencyModel.Cast _SARCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SARCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SARCurrency.cell
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
    [<ExcelFunction(Name="_SARCurrency_triangulationCurrency", Description="Create a SARCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SARCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SARCurrency",Description = "SARCurrency")>] 
         sarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SARCurrency = Helper.toModelReference<SARCurrency> sarcurrency "SARCurrency"  
                let builder (current : ICell) = ((SARCurrencyModel.Cast _SARCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_SARCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SARCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SARCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_SARCurrency_Range", Description="Create a range of SARCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SARCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SARCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<SARCurrency> (c)) :> ICell
                let format (i : Cephei.Cell.List<SARCurrency>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<SARCurrency>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
