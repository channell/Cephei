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

  </summary> *)
[<AutoSerializable(true)>]
module ESPCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ESPCurrency", Description="Create a ESPCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ESPCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.ESPCurrency 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ESPCurrency>) l

                let source = Helper.sourceFold "Fun.ESPCurrency" 
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
    [<ExcelFunction(Name="_ESPCurrency_code", Description="Create a ESPCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ESPCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ESPCurrency",Description = "Reference to ESPCurrency")>] 
         espcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ESPCurrency = Helper.toCell<ESPCurrency> espcurrency "ESPCurrency" true 
                let builder () = withMnemonic mnemonic ((_ESPCurrency.cell :?> ESPCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ESPCurrency.source + ".Code") 
                                               [| _ESPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ESPCurrency.cell
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
    [<ExcelFunction(Name="_ESPCurrency_empty", Description="Create a ESPCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ESPCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ESPCurrency",Description = "Reference to ESPCurrency")>] 
         espcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ESPCurrency = Helper.toCell<ESPCurrency> espcurrency "ESPCurrency" true 
                let builder () = withMnemonic mnemonic ((_ESPCurrency.cell :?> ESPCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ESPCurrency.source + ".Empty") 
                                               [| _ESPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ESPCurrency.cell
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
    [<ExcelFunction(Name="_ESPCurrency_Equals", Description="Create a ESPCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ESPCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ESPCurrency",Description = "Reference to ESPCurrency")>] 
         espcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ESPCurrency = Helper.toCell<ESPCurrency> espcurrency "ESPCurrency" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_ESPCurrency.cell :?> ESPCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ESPCurrency.source + ".Equals") 
                                               [| _ESPCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ESPCurrency.cell
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
    [<ExcelFunction(Name="_ESPCurrency_format", Description="Create a ESPCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ESPCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ESPCurrency",Description = "Reference to ESPCurrency")>] 
         espcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ESPCurrency = Helper.toCell<ESPCurrency> espcurrency "ESPCurrency" true 
                let builder () = withMnemonic mnemonic ((_ESPCurrency.cell :?> ESPCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ESPCurrency.source + ".Format") 
                                               [| _ESPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ESPCurrency.cell
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
    [<ExcelFunction(Name="_ESPCurrency_fractionsPerUnit", Description="Create a ESPCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ESPCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ESPCurrency",Description = "Reference to ESPCurrency")>] 
         espcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ESPCurrency = Helper.toCell<ESPCurrency> espcurrency "ESPCurrency" true 
                let builder () = withMnemonic mnemonic ((_ESPCurrency.cell :?> ESPCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ESPCurrency.source + ".FractionsPerUnit") 
                                               [| _ESPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ESPCurrency.cell
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
    [<ExcelFunction(Name="_ESPCurrency_fractionSymbol", Description="Create a ESPCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ESPCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ESPCurrency",Description = "Reference to ESPCurrency")>] 
         espcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ESPCurrency = Helper.toCell<ESPCurrency> espcurrency "ESPCurrency" true 
                let builder () = withMnemonic mnemonic ((_ESPCurrency.cell :?> ESPCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ESPCurrency.source + ".FractionSymbol") 
                                               [| _ESPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ESPCurrency.cell
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
    [<ExcelFunction(Name="_ESPCurrency_name", Description="Create a ESPCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ESPCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ESPCurrency",Description = "Reference to ESPCurrency")>] 
         espcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ESPCurrency = Helper.toCell<ESPCurrency> espcurrency "ESPCurrency" true 
                let builder () = withMnemonic mnemonic ((_ESPCurrency.cell :?> ESPCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ESPCurrency.source + ".Name") 
                                               [| _ESPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ESPCurrency.cell
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
    [<ExcelFunction(Name="_ESPCurrency_numericCode", Description="Create a ESPCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ESPCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ESPCurrency",Description = "Reference to ESPCurrency")>] 
         espcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ESPCurrency = Helper.toCell<ESPCurrency> espcurrency "ESPCurrency" true 
                let builder () = withMnemonic mnemonic ((_ESPCurrency.cell :?> ESPCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ESPCurrency.source + ".NumericCode") 
                                               [| _ESPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ESPCurrency.cell
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
    [<ExcelFunction(Name="_ESPCurrency_rounding", Description="Create a ESPCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ESPCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ESPCurrency",Description = "Reference to ESPCurrency")>] 
         espcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ESPCurrency = Helper.toCell<ESPCurrency> espcurrency "ESPCurrency" true 
                let builder () = withMnemonic mnemonic ((_ESPCurrency.cell :?> ESPCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_ESPCurrency.source + ".Rounding") 
                                               [| _ESPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ESPCurrency.cell
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
    [<ExcelFunction(Name="_ESPCurrency_symbol", Description="Create a ESPCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ESPCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ESPCurrency",Description = "Reference to ESPCurrency")>] 
         espcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ESPCurrency = Helper.toCell<ESPCurrency> espcurrency "ESPCurrency" true 
                let builder () = withMnemonic mnemonic ((_ESPCurrency.cell :?> ESPCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ESPCurrency.source + ".Symbol") 
                                               [| _ESPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ESPCurrency.cell
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
    [<ExcelFunction(Name="_ESPCurrency_ToString", Description="Create a ESPCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ESPCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ESPCurrency",Description = "Reference to ESPCurrency")>] 
         espcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ESPCurrency = Helper.toCell<ESPCurrency> espcurrency "ESPCurrency" true 
                let builder () = withMnemonic mnemonic ((_ESPCurrency.cell :?> ESPCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ESPCurrency.source + ".ToString") 
                                               [| _ESPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ESPCurrency.cell
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
    [<ExcelFunction(Name="_ESPCurrency_triangulationCurrency", Description="Create a ESPCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ESPCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ESPCurrency",Description = "Reference to ESPCurrency")>] 
         espcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ESPCurrency = Helper.toCell<ESPCurrency> espcurrency "ESPCurrency" true 
                let builder () = withMnemonic mnemonic ((_ESPCurrency.cell :?> ESPCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_ESPCurrency.source + ".TriangulationCurrency") 
                                               [| _ESPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ESPCurrency.cell
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
    [<ExcelFunction(Name="_ESPCurrency_Range", Description="Create a range of ESPCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ESPCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ESPCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ESPCurrency> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ESPCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ESPCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ESPCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
