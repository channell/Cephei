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
  U.S. dollar   The ISO three-letter code is USD; the numeric code is 840. It is divided in 100 cents.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module USDCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_USDCurrency", Description="Create a USDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.USDCurrency 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<USDCurrency>) l

                let source = Helper.sourceFold "Fun.USDCurrency" 
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
    [<ExcelFunction(Name="_USDCurrency_code", Description="Create a USDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDCurrency",Description = "Reference to USDCurrency")>] 
         usdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDCurrency = Helper.toCell<USDCurrency> usdcurrency "USDCurrency" true 
                let builder () = withMnemonic mnemonic ((_USDCurrency.cell :?> USDCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_USDCurrency.source + ".Code") 
                                               [| _USDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDCurrency.cell
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
    [<ExcelFunction(Name="_USDCurrency_empty", Description="Create a USDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDCurrency",Description = "Reference to USDCurrency")>] 
         usdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDCurrency = Helper.toCell<USDCurrency> usdcurrency "USDCurrency" true 
                let builder () = withMnemonic mnemonic ((_USDCurrency.cell :?> USDCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_USDCurrency.source + ".Empty") 
                                               [| _USDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDCurrency.cell
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
    [<ExcelFunction(Name="_USDCurrency_Equals", Description="Create a USDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDCurrency",Description = "Reference to USDCurrency")>] 
         usdcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDCurrency = Helper.toCell<USDCurrency> usdcurrency "USDCurrency" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_USDCurrency.cell :?> USDCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_USDCurrency.source + ".Equals") 
                                               [| _USDCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDCurrency.cell
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
    [<ExcelFunction(Name="_USDCurrency_format", Description="Create a USDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDCurrency",Description = "Reference to USDCurrency")>] 
         usdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDCurrency = Helper.toCell<USDCurrency> usdcurrency "USDCurrency" true 
                let builder () = withMnemonic mnemonic ((_USDCurrency.cell :?> USDCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_USDCurrency.source + ".Format") 
                                               [| _USDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDCurrency.cell
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
    [<ExcelFunction(Name="_USDCurrency_fractionsPerUnit", Description="Create a USDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDCurrency",Description = "Reference to USDCurrency")>] 
         usdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDCurrency = Helper.toCell<USDCurrency> usdcurrency "USDCurrency" true 
                let builder () = withMnemonic mnemonic ((_USDCurrency.cell :?> USDCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_USDCurrency.source + ".FractionsPerUnit") 
                                               [| _USDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDCurrency.cell
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
    [<ExcelFunction(Name="_USDCurrency_fractionSymbol", Description="Create a USDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDCurrency",Description = "Reference to USDCurrency")>] 
         usdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDCurrency = Helper.toCell<USDCurrency> usdcurrency "USDCurrency" true 
                let builder () = withMnemonic mnemonic ((_USDCurrency.cell :?> USDCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_USDCurrency.source + ".FractionSymbol") 
                                               [| _USDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDCurrency.cell
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
    [<ExcelFunction(Name="_USDCurrency_name", Description="Create a USDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDCurrency",Description = "Reference to USDCurrency")>] 
         usdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDCurrency = Helper.toCell<USDCurrency> usdcurrency "USDCurrency" true 
                let builder () = withMnemonic mnemonic ((_USDCurrency.cell :?> USDCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_USDCurrency.source + ".Name") 
                                               [| _USDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDCurrency.cell
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
    [<ExcelFunction(Name="_USDCurrency_numericCode", Description="Create a USDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDCurrency",Description = "Reference to USDCurrency")>] 
         usdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDCurrency = Helper.toCell<USDCurrency> usdcurrency "USDCurrency" true 
                let builder () = withMnemonic mnemonic ((_USDCurrency.cell :?> USDCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_USDCurrency.source + ".NumericCode") 
                                               [| _USDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDCurrency.cell
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
    [<ExcelFunction(Name="_USDCurrency_rounding", Description="Create a USDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDCurrency",Description = "Reference to USDCurrency")>] 
         usdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDCurrency = Helper.toCell<USDCurrency> usdcurrency "USDCurrency" true 
                let builder () = withMnemonic mnemonic ((_USDCurrency.cell :?> USDCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_USDCurrency.source + ".Rounding") 
                                               [| _USDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDCurrency.cell
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
    [<ExcelFunction(Name="_USDCurrency_symbol", Description="Create a USDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDCurrency",Description = "Reference to USDCurrency")>] 
         usdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDCurrency = Helper.toCell<USDCurrency> usdcurrency "USDCurrency" true 
                let builder () = withMnemonic mnemonic ((_USDCurrency.cell :?> USDCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_USDCurrency.source + ".Symbol") 
                                               [| _USDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDCurrency.cell
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
    [<ExcelFunction(Name="_USDCurrency_ToString", Description="Create a USDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDCurrency",Description = "Reference to USDCurrency")>] 
         usdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDCurrency = Helper.toCell<USDCurrency> usdcurrency "USDCurrency" true 
                let builder () = withMnemonic mnemonic ((_USDCurrency.cell :?> USDCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_USDCurrency.source + ".ToString") 
                                               [| _USDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDCurrency.cell
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
    [<ExcelFunction(Name="_USDCurrency_triangulationCurrency", Description="Create a USDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDCurrency",Description = "Reference to USDCurrency")>] 
         usdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDCurrency = Helper.toCell<USDCurrency> usdcurrency "USDCurrency" true 
                let builder () = withMnemonic mnemonic ((_USDCurrency.cell :?> USDCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_USDCurrency.source + ".TriangulationCurrency") 
                                               [| _USDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDCurrency.cell
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
    [<ExcelFunction(Name="_USDCurrency_Range", Description="Create a range of USDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the USDCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<USDCurrency> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<USDCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<USDCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<USDCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
