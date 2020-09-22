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
  The ISO three-letter code is IRR; the numeric code is 364. It has no subdivisions.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module IRRCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_IRRCurrency", Description="Create a IRRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IRRCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.IRRCurrency () 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IRRCurrency>) l

                let source = Helper.sourceFold "Fun.IRRCurrency" 
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
    [<ExcelFunction(Name="_IRRCurrency_code", Description="Create a IRRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IRRCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IRRCurrency",Description = "Reference to IRRCurrency")>] 
         irrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IRRCurrency = Helper.toCell<IRRCurrency> irrcurrency "IRRCurrency" true 
                let builder () = withMnemonic mnemonic ((_IRRCurrency.cell :?> IRRCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IRRCurrency.source + ".Code") 
                                               [| _IRRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IRRCurrency.cell
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
    [<ExcelFunction(Name="_IRRCurrency_empty", Description="Create a IRRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IRRCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IRRCurrency",Description = "Reference to IRRCurrency")>] 
         irrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IRRCurrency = Helper.toCell<IRRCurrency> irrcurrency "IRRCurrency" true 
                let builder () = withMnemonic mnemonic ((_IRRCurrency.cell :?> IRRCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IRRCurrency.source + ".Empty") 
                                               [| _IRRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IRRCurrency.cell
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
    [<ExcelFunction(Name="_IRRCurrency_Equals", Description="Create a IRRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IRRCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IRRCurrency",Description = "Reference to IRRCurrency")>] 
         irrcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IRRCurrency = Helper.toCell<IRRCurrency> irrcurrency "IRRCurrency" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_IRRCurrency.cell :?> IRRCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IRRCurrency.source + ".Equals") 
                                               [| _IRRCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IRRCurrency.cell
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
    [<ExcelFunction(Name="_IRRCurrency_format", Description="Create a IRRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IRRCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IRRCurrency",Description = "Reference to IRRCurrency")>] 
         irrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IRRCurrency = Helper.toCell<IRRCurrency> irrcurrency "IRRCurrency" true 
                let builder () = withMnemonic mnemonic ((_IRRCurrency.cell :?> IRRCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IRRCurrency.source + ".Format") 
                                               [| _IRRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IRRCurrency.cell
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
    [<ExcelFunction(Name="_IRRCurrency_fractionsPerUnit", Description="Create a IRRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IRRCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IRRCurrency",Description = "Reference to IRRCurrency")>] 
         irrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IRRCurrency = Helper.toCell<IRRCurrency> irrcurrency "IRRCurrency" true 
                let builder () = withMnemonic mnemonic ((_IRRCurrency.cell :?> IRRCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_IRRCurrency.source + ".FractionsPerUnit") 
                                               [| _IRRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IRRCurrency.cell
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
    [<ExcelFunction(Name="_IRRCurrency_fractionSymbol", Description="Create a IRRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IRRCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IRRCurrency",Description = "Reference to IRRCurrency")>] 
         irrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IRRCurrency = Helper.toCell<IRRCurrency> irrcurrency "IRRCurrency" true 
                let builder () = withMnemonic mnemonic ((_IRRCurrency.cell :?> IRRCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IRRCurrency.source + ".FractionSymbol") 
                                               [| _IRRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IRRCurrency.cell
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
    [<ExcelFunction(Name="_IRRCurrency_name", Description="Create a IRRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IRRCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IRRCurrency",Description = "Reference to IRRCurrency")>] 
         irrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IRRCurrency = Helper.toCell<IRRCurrency> irrcurrency "IRRCurrency" true 
                let builder () = withMnemonic mnemonic ((_IRRCurrency.cell :?> IRRCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IRRCurrency.source + ".Name") 
                                               [| _IRRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IRRCurrency.cell
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
    [<ExcelFunction(Name="_IRRCurrency_numericCode", Description="Create a IRRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IRRCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IRRCurrency",Description = "Reference to IRRCurrency")>] 
         irrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IRRCurrency = Helper.toCell<IRRCurrency> irrcurrency "IRRCurrency" true 
                let builder () = withMnemonic mnemonic ((_IRRCurrency.cell :?> IRRCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_IRRCurrency.source + ".NumericCode") 
                                               [| _IRRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IRRCurrency.cell
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
    [<ExcelFunction(Name="_IRRCurrency_rounding", Description="Create a IRRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IRRCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IRRCurrency",Description = "Reference to IRRCurrency")>] 
         irrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IRRCurrency = Helper.toCell<IRRCurrency> irrcurrency "IRRCurrency" true 
                let builder () = withMnemonic mnemonic ((_IRRCurrency.cell :?> IRRCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_IRRCurrency.source + ".Rounding") 
                                               [| _IRRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IRRCurrency.cell
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
    [<ExcelFunction(Name="_IRRCurrency_symbol", Description="Create a IRRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IRRCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IRRCurrency",Description = "Reference to IRRCurrency")>] 
         irrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IRRCurrency = Helper.toCell<IRRCurrency> irrcurrency "IRRCurrency" true 
                let builder () = withMnemonic mnemonic ((_IRRCurrency.cell :?> IRRCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IRRCurrency.source + ".Symbol") 
                                               [| _IRRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IRRCurrency.cell
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
    [<ExcelFunction(Name="_IRRCurrency_ToString", Description="Create a IRRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IRRCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IRRCurrency",Description = "Reference to IRRCurrency")>] 
         irrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IRRCurrency = Helper.toCell<IRRCurrency> irrcurrency "IRRCurrency" true 
                let builder () = withMnemonic mnemonic ((_IRRCurrency.cell :?> IRRCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IRRCurrency.source + ".ToString") 
                                               [| _IRRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IRRCurrency.cell
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
    [<ExcelFunction(Name="_IRRCurrency_triangulationCurrency", Description="Create a IRRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IRRCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IRRCurrency",Description = "Reference to IRRCurrency")>] 
         irrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IRRCurrency = Helper.toCell<IRRCurrency> irrcurrency "IRRCurrency" true 
                let builder () = withMnemonic mnemonic ((_IRRCurrency.cell :?> IRRCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_IRRCurrency.source + ".TriangulationCurrency") 
                                               [| _IRRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IRRCurrency.cell
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
    [<ExcelFunction(Name="_IRRCurrency_Range", Description="Create a range of IRRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IRRCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the IRRCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<IRRCurrency> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<IRRCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<IRRCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<IRRCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
