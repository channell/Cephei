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
  The ISO three-letter code is RUB; the numeric code is 643. It is divided in 100 kopeyki.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module RUBCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_RUBCurrency", Description="Create a RUBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RUBCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.RUBCurrency 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RUBCurrency>) l

                let source = Helper.sourceFold "Fun.RUBCurrency" 
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
    [<ExcelFunction(Name="_RUBCurrency_code", Description="Create a RUBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RUBCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RUBCurrency",Description = "Reference to RUBCurrency")>] 
         rubcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RUBCurrency = Helper.toCell<RUBCurrency> rubcurrency "RUBCurrency" true 
                let builder () = withMnemonic mnemonic ((_RUBCurrency.cell :?> RUBCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RUBCurrency.source + ".Code") 
                                               [| _RUBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RUBCurrency.cell
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
    [<ExcelFunction(Name="_RUBCurrency_empty", Description="Create a RUBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RUBCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RUBCurrency",Description = "Reference to RUBCurrency")>] 
         rubcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RUBCurrency = Helper.toCell<RUBCurrency> rubcurrency "RUBCurrency" true 
                let builder () = withMnemonic mnemonic ((_RUBCurrency.cell :?> RUBCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RUBCurrency.source + ".Empty") 
                                               [| _RUBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RUBCurrency.cell
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
    [<ExcelFunction(Name="_RUBCurrency_Equals", Description="Create a RUBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RUBCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RUBCurrency",Description = "Reference to RUBCurrency")>] 
         rubcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RUBCurrency = Helper.toCell<RUBCurrency> rubcurrency "RUBCurrency" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_RUBCurrency.cell :?> RUBCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RUBCurrency.source + ".Equals") 
                                               [| _RUBCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RUBCurrency.cell
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
    [<ExcelFunction(Name="_RUBCurrency_format", Description="Create a RUBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RUBCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RUBCurrency",Description = "Reference to RUBCurrency")>] 
         rubcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RUBCurrency = Helper.toCell<RUBCurrency> rubcurrency "RUBCurrency" true 
                let builder () = withMnemonic mnemonic ((_RUBCurrency.cell :?> RUBCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RUBCurrency.source + ".Format") 
                                               [| _RUBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RUBCurrency.cell
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
    [<ExcelFunction(Name="_RUBCurrency_fractionsPerUnit", Description="Create a RUBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RUBCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RUBCurrency",Description = "Reference to RUBCurrency")>] 
         rubcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RUBCurrency = Helper.toCell<RUBCurrency> rubcurrency "RUBCurrency" true 
                let builder () = withMnemonic mnemonic ((_RUBCurrency.cell :?> RUBCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_RUBCurrency.source + ".FractionsPerUnit") 
                                               [| _RUBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RUBCurrency.cell
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
    [<ExcelFunction(Name="_RUBCurrency_fractionSymbol", Description="Create a RUBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RUBCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RUBCurrency",Description = "Reference to RUBCurrency")>] 
         rubcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RUBCurrency = Helper.toCell<RUBCurrency> rubcurrency "RUBCurrency" true 
                let builder () = withMnemonic mnemonic ((_RUBCurrency.cell :?> RUBCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RUBCurrency.source + ".FractionSymbol") 
                                               [| _RUBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RUBCurrency.cell
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
    [<ExcelFunction(Name="_RUBCurrency_name", Description="Create a RUBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RUBCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RUBCurrency",Description = "Reference to RUBCurrency")>] 
         rubcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RUBCurrency = Helper.toCell<RUBCurrency> rubcurrency "RUBCurrency" true 
                let builder () = withMnemonic mnemonic ((_RUBCurrency.cell :?> RUBCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RUBCurrency.source + ".Name") 
                                               [| _RUBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RUBCurrency.cell
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
    [<ExcelFunction(Name="_RUBCurrency_numericCode", Description="Create a RUBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RUBCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RUBCurrency",Description = "Reference to RUBCurrency")>] 
         rubcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RUBCurrency = Helper.toCell<RUBCurrency> rubcurrency "RUBCurrency" true 
                let builder () = withMnemonic mnemonic ((_RUBCurrency.cell :?> RUBCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_RUBCurrency.source + ".NumericCode") 
                                               [| _RUBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RUBCurrency.cell
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
    [<ExcelFunction(Name="_RUBCurrency_rounding", Description="Create a RUBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RUBCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RUBCurrency",Description = "Reference to RUBCurrency")>] 
         rubcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RUBCurrency = Helper.toCell<RUBCurrency> rubcurrency "RUBCurrency" true 
                let builder () = withMnemonic mnemonic ((_RUBCurrency.cell :?> RUBCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_RUBCurrency.source + ".Rounding") 
                                               [| _RUBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RUBCurrency.cell
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
    [<ExcelFunction(Name="_RUBCurrency_symbol", Description="Create a RUBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RUBCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RUBCurrency",Description = "Reference to RUBCurrency")>] 
         rubcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RUBCurrency = Helper.toCell<RUBCurrency> rubcurrency "RUBCurrency" true 
                let builder () = withMnemonic mnemonic ((_RUBCurrency.cell :?> RUBCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RUBCurrency.source + ".Symbol") 
                                               [| _RUBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RUBCurrency.cell
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
    [<ExcelFunction(Name="_RUBCurrency_ToString", Description="Create a RUBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RUBCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RUBCurrency",Description = "Reference to RUBCurrency")>] 
         rubcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RUBCurrency = Helper.toCell<RUBCurrency> rubcurrency "RUBCurrency" true 
                let builder () = withMnemonic mnemonic ((_RUBCurrency.cell :?> RUBCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RUBCurrency.source + ".ToString") 
                                               [| _RUBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RUBCurrency.cell
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
    [<ExcelFunction(Name="_RUBCurrency_triangulationCurrency", Description="Create a RUBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RUBCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RUBCurrency",Description = "Reference to RUBCurrency")>] 
         rubcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RUBCurrency = Helper.toCell<RUBCurrency> rubcurrency "RUBCurrency" true 
                let builder () = withMnemonic mnemonic ((_RUBCurrency.cell :?> RUBCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_RUBCurrency.source + ".TriangulationCurrency") 
                                               [| _RUBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RUBCurrency.cell
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
    [<ExcelFunction(Name="_RUBCurrency_Range", Description="Create a range of RUBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RUBCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the RUBCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<RUBCurrency> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<RUBCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<RUBCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<RUBCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
