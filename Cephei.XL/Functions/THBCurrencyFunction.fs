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
  The ISO three-letter code is THB; the numeric code is 764. It is divided in 100 stang.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module THBCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_THBCurrency", Description="Create a THBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let THBCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.THBCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<THBCurrency>) l

                let source = Helper.sourceFold "Fun.THBCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
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
    [<ExcelFunction(Name="_THBCurrency_code", Description="Create a THBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let THBCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="THBCurrency",Description = "Reference to THBCurrency")>] 
         thbcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _THBCurrency = Helper.toCell<THBCurrency> thbcurrency "THBCurrency" true 
                let builder () = withMnemonic mnemonic ((_THBCurrency.cell :?> THBCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_THBCurrency.source + ".Code") 
                                               [| _THBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _THBCurrency.cell
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
        ! Other information ! is this a usable instance?
    *)
    [<ExcelFunction(Name="_THBCurrency_empty", Description="Create a THBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let THBCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="THBCurrency",Description = "Reference to THBCurrency")>] 
         thbcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _THBCurrency = Helper.toCell<THBCurrency> thbcurrency "THBCurrency" true 
                let builder () = withMnemonic mnemonic ((_THBCurrency.cell :?> THBCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_THBCurrency.source + ".Empty") 
                                               [| _THBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _THBCurrency.cell
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
    [<ExcelFunction(Name="_THBCurrency_Equals", Description="Create a THBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let THBCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="THBCurrency",Description = "Reference to THBCurrency")>] 
         thbcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _THBCurrency = Helper.toCell<THBCurrency> thbcurrency "THBCurrency" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_THBCurrency.cell :?> THBCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_THBCurrency.source + ".Equals") 
                                               [| _THBCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _THBCurrency.cell
                                ;  _o.cell
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
        ! currency used for triangulated exchange when required output format The format will be fed three positional parameters, namely, value, code, and symbol, in this order.
    *)
    [<ExcelFunction(Name="_THBCurrency_format", Description="Create a THBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let THBCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="THBCurrency",Description = "Reference to THBCurrency")>] 
         thbcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _THBCurrency = Helper.toCell<THBCurrency> thbcurrency "THBCurrency" true 
                let builder () = withMnemonic mnemonic ((_THBCurrency.cell :?> THBCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_THBCurrency.source + ".Format") 
                                               [| _THBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _THBCurrency.cell
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
        ! fraction symbol, e.g, "Â¢"
    *)
    [<ExcelFunction(Name="_THBCurrency_fractionsPerUnit", Description="Create a THBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let THBCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="THBCurrency",Description = "Reference to THBCurrency")>] 
         thbcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _THBCurrency = Helper.toCell<THBCurrency> thbcurrency "THBCurrency" true 
                let builder () = withMnemonic mnemonic ((_THBCurrency.cell :?> THBCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_THBCurrency.source + ".FractionsPerUnit") 
                                               [| _THBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _THBCurrency.cell
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
        ! symbol, e.g, "$"
    *)
    [<ExcelFunction(Name="_THBCurrency_fractionSymbol", Description="Create a THBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let THBCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="THBCurrency",Description = "Reference to THBCurrency")>] 
         thbcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _THBCurrency = Helper.toCell<THBCurrency> thbcurrency "THBCurrency" true 
                let builder () = withMnemonic mnemonic ((_THBCurrency.cell :?> THBCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_THBCurrency.source + ".FractionSymbol") 
                                               [| _THBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _THBCurrency.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_THBCurrency_name", Description="Create a THBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let THBCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="THBCurrency",Description = "Reference to THBCurrency")>] 
         thbcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _THBCurrency = Helper.toCell<THBCurrency> thbcurrency "THBCurrency" true 
                let builder () = withMnemonic mnemonic ((_THBCurrency.cell :?> THBCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_THBCurrency.source + ".Name") 
                                               [| _THBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _THBCurrency.cell
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
        ! ISO 4217 three-letter code, e.g, "USD"
    *)
    [<ExcelFunction(Name="_THBCurrency_numericCode", Description="Create a THBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let THBCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="THBCurrency",Description = "Reference to THBCurrency")>] 
         thbcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _THBCurrency = Helper.toCell<THBCurrency> thbcurrency "THBCurrency" true 
                let builder () = withMnemonic mnemonic ((_THBCurrency.cell :?> THBCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_THBCurrency.source + ".NumericCode") 
                                               [| _THBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _THBCurrency.cell
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
        ! number of fractionary parts in a unit, e.g, 100
    *)
    [<ExcelFunction(Name="_THBCurrency_rounding", Description="Create a THBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let THBCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="THBCurrency",Description = "Reference to THBCurrency")>] 
         thbcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _THBCurrency = Helper.toCell<THBCurrency> thbcurrency "THBCurrency" true 
                let builder () = withMnemonic mnemonic ((_THBCurrency.cell :?> THBCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_THBCurrency.source + ".Rounding") 
                                               [| _THBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _THBCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
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
    [<ExcelFunction(Name="_THBCurrency_symbol", Description="Create a THBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let THBCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="THBCurrency",Description = "Reference to THBCurrency")>] 
         thbcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _THBCurrency = Helper.toCell<THBCurrency> thbcurrency "THBCurrency" true 
                let builder () = withMnemonic mnemonic ((_THBCurrency.cell :?> THBCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_THBCurrency.source + ".Symbol") 
                                               [| _THBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _THBCurrency.cell
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
    [<ExcelFunction(Name="_THBCurrency_ToString", Description="Create a THBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let THBCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="THBCurrency",Description = "Reference to THBCurrency")>] 
         thbcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _THBCurrency = Helper.toCell<THBCurrency> thbcurrency "THBCurrency" true 
                let builder () = withMnemonic mnemonic ((_THBCurrency.cell :?> THBCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_THBCurrency.source + ".ToString") 
                                               [| _THBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _THBCurrency.cell
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
        ! rounding convention
    *)
    [<ExcelFunction(Name="_THBCurrency_triangulationCurrency", Description="Create a THBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let THBCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="THBCurrency",Description = "Reference to THBCurrency")>] 
         thbcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _THBCurrency = Helper.toCell<THBCurrency> thbcurrency "THBCurrency" true 
                let builder () = withMnemonic mnemonic ((_THBCurrency.cell :?> THBCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_THBCurrency.source + ".TriangulationCurrency") 
                                               [| _THBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _THBCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_THBCurrency_Range", Description="Create a range of THBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let THBCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the THBCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<THBCurrency> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<THBCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<THBCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<THBCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
