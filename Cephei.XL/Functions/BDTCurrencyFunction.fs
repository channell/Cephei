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
  The ISO three-letter code is BDT; the numeric code is 50. It is divided in 100 paisa. currencies
  </summary> *)
[<AutoSerializable(true)>]
module BDTCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BDTCurrency", Description="Create a BDTCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BDTCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.BDTCurrency 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BDTCurrency>) l

                let source = Helper.sourceFold "Fun.BDTCurrency" 
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
    [<ExcelFunction(Name="_BDTCurrency_code", Description="Create a BDTCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BDTCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BDTCurrency",Description = "Reference to BDTCurrency")>] 
         bdtcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BDTCurrency = Helper.toCell<BDTCurrency> bdtcurrency "BDTCurrency" true 
                let builder () = withMnemonic mnemonic ((_BDTCurrency.cell :?> BDTCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BDTCurrency.source + ".Code") 
                                               [| _BDTCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BDTCurrency.cell
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
    [<ExcelFunction(Name="_BDTCurrency_empty", Description="Create a BDTCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BDTCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BDTCurrency",Description = "Reference to BDTCurrency")>] 
         bdtcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BDTCurrency = Helper.toCell<BDTCurrency> bdtcurrency "BDTCurrency" true 
                let builder () = withMnemonic mnemonic ((_BDTCurrency.cell :?> BDTCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BDTCurrency.source + ".Empty") 
                                               [| _BDTCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BDTCurrency.cell
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
    [<ExcelFunction(Name="_BDTCurrency_Equals", Description="Create a BDTCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BDTCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BDTCurrency",Description = "Reference to BDTCurrency")>] 
         bdtcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BDTCurrency = Helper.toCell<BDTCurrency> bdtcurrency "BDTCurrency" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_BDTCurrency.cell :?> BDTCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BDTCurrency.source + ".Equals") 
                                               [| _BDTCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BDTCurrency.cell
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
    [<ExcelFunction(Name="_BDTCurrency_format", Description="Create a BDTCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BDTCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BDTCurrency",Description = "Reference to BDTCurrency")>] 
         bdtcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BDTCurrency = Helper.toCell<BDTCurrency> bdtcurrency "BDTCurrency" true 
                let builder () = withMnemonic mnemonic ((_BDTCurrency.cell :?> BDTCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BDTCurrency.source + ".Format") 
                                               [| _BDTCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BDTCurrency.cell
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
    [<ExcelFunction(Name="_BDTCurrency_fractionsPerUnit", Description="Create a BDTCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BDTCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BDTCurrency",Description = "Reference to BDTCurrency")>] 
         bdtcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BDTCurrency = Helper.toCell<BDTCurrency> bdtcurrency "BDTCurrency" true 
                let builder () = withMnemonic mnemonic ((_BDTCurrency.cell :?> BDTCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_BDTCurrency.source + ".FractionsPerUnit") 
                                               [| _BDTCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BDTCurrency.cell
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
    [<ExcelFunction(Name="_BDTCurrency_fractionSymbol", Description="Create a BDTCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BDTCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BDTCurrency",Description = "Reference to BDTCurrency")>] 
         bdtcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BDTCurrency = Helper.toCell<BDTCurrency> bdtcurrency "BDTCurrency" true 
                let builder () = withMnemonic mnemonic ((_BDTCurrency.cell :?> BDTCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BDTCurrency.source + ".FractionSymbol") 
                                               [| _BDTCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BDTCurrency.cell
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
    [<ExcelFunction(Name="_BDTCurrency_name", Description="Create a BDTCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BDTCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BDTCurrency",Description = "Reference to BDTCurrency")>] 
         bdtcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BDTCurrency = Helper.toCell<BDTCurrency> bdtcurrency "BDTCurrency" true 
                let builder () = withMnemonic mnemonic ((_BDTCurrency.cell :?> BDTCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BDTCurrency.source + ".Name") 
                                               [| _BDTCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BDTCurrency.cell
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
    [<ExcelFunction(Name="_BDTCurrency_numericCode", Description="Create a BDTCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BDTCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BDTCurrency",Description = "Reference to BDTCurrency")>] 
         bdtcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BDTCurrency = Helper.toCell<BDTCurrency> bdtcurrency "BDTCurrency" true 
                let builder () = withMnemonic mnemonic ((_BDTCurrency.cell :?> BDTCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_BDTCurrency.source + ".NumericCode") 
                                               [| _BDTCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BDTCurrency.cell
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
    [<ExcelFunction(Name="_BDTCurrency_rounding", Description="Create a BDTCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BDTCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BDTCurrency",Description = "Reference to BDTCurrency")>] 
         bdtcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BDTCurrency = Helper.toCell<BDTCurrency> bdtcurrency "BDTCurrency" true 
                let builder () = withMnemonic mnemonic ((_BDTCurrency.cell :?> BDTCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_BDTCurrency.source + ".Rounding") 
                                               [| _BDTCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BDTCurrency.cell
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
    [<ExcelFunction(Name="_BDTCurrency_symbol", Description="Create a BDTCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BDTCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BDTCurrency",Description = "Reference to BDTCurrency")>] 
         bdtcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BDTCurrency = Helper.toCell<BDTCurrency> bdtcurrency "BDTCurrency" true 
                let builder () = withMnemonic mnemonic ((_BDTCurrency.cell :?> BDTCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BDTCurrency.source + ".Symbol") 
                                               [| _BDTCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BDTCurrency.cell
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
    [<ExcelFunction(Name="_BDTCurrency_ToString", Description="Create a BDTCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BDTCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BDTCurrency",Description = "Reference to BDTCurrency")>] 
         bdtcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BDTCurrency = Helper.toCell<BDTCurrency> bdtcurrency "BDTCurrency" true 
                let builder () = withMnemonic mnemonic ((_BDTCurrency.cell :?> BDTCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BDTCurrency.source + ".ToString") 
                                               [| _BDTCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BDTCurrency.cell
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
    [<ExcelFunction(Name="_BDTCurrency_triangulationCurrency", Description="Create a BDTCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BDTCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BDTCurrency",Description = "Reference to BDTCurrency")>] 
         bdtcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BDTCurrency = Helper.toCell<BDTCurrency> bdtcurrency "BDTCurrency" true 
                let builder () = withMnemonic mnemonic ((_BDTCurrency.cell :?> BDTCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_BDTCurrency.source + ".TriangulationCurrency") 
                                               [| _BDTCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BDTCurrency.cell
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
    [<ExcelFunction(Name="_BDTCurrency_Range", Description="Create a range of BDTCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BDTCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BDTCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BDTCurrency> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BDTCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BDTCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BDTCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
