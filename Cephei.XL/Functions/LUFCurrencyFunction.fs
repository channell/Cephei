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
module LUFCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_LUFCurrency", Description="Create a LUFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LUFCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.LUFCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LUFCurrency>) l

                let source = Helper.sourceFold "Fun.LUFCurrency" 
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
    [<ExcelFunction(Name="_LUFCurrency_code", Description="Create a LUFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LUFCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LUFCurrency",Description = "Reference to LUFCurrency")>] 
         lufcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LUFCurrency = Helper.toCell<LUFCurrency> lufcurrency "LUFCurrency" true 
                let builder () = withMnemonic mnemonic ((_LUFCurrency.cell :?> LUFCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LUFCurrency.source + ".Code") 
                                               [| _LUFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LUFCurrency.cell
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
    [<ExcelFunction(Name="_LUFCurrency_empty", Description="Create a LUFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LUFCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LUFCurrency",Description = "Reference to LUFCurrency")>] 
         lufcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LUFCurrency = Helper.toCell<LUFCurrency> lufcurrency "LUFCurrency" true 
                let builder () = withMnemonic mnemonic ((_LUFCurrency.cell :?> LUFCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LUFCurrency.source + ".Empty") 
                                               [| _LUFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LUFCurrency.cell
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
    [<ExcelFunction(Name="_LUFCurrency_Equals", Description="Create a LUFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LUFCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LUFCurrency",Description = "Reference to LUFCurrency")>] 
         lufcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LUFCurrency = Helper.toCell<LUFCurrency> lufcurrency "LUFCurrency" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_LUFCurrency.cell :?> LUFCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LUFCurrency.source + ".Equals") 
                                               [| _LUFCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LUFCurrency.cell
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
    [<ExcelFunction(Name="_LUFCurrency_format", Description="Create a LUFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LUFCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LUFCurrency",Description = "Reference to LUFCurrency")>] 
         lufcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LUFCurrency = Helper.toCell<LUFCurrency> lufcurrency "LUFCurrency" true 
                let builder () = withMnemonic mnemonic ((_LUFCurrency.cell :?> LUFCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LUFCurrency.source + ".Format") 
                                               [| _LUFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LUFCurrency.cell
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
    [<ExcelFunction(Name="_LUFCurrency_fractionsPerUnit", Description="Create a LUFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LUFCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LUFCurrency",Description = "Reference to LUFCurrency")>] 
         lufcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LUFCurrency = Helper.toCell<LUFCurrency> lufcurrency "LUFCurrency" true 
                let builder () = withMnemonic mnemonic ((_LUFCurrency.cell :?> LUFCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_LUFCurrency.source + ".FractionsPerUnit") 
                                               [| _LUFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LUFCurrency.cell
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
    [<ExcelFunction(Name="_LUFCurrency_fractionSymbol", Description="Create a LUFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LUFCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LUFCurrency",Description = "Reference to LUFCurrency")>] 
         lufcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LUFCurrency = Helper.toCell<LUFCurrency> lufcurrency "LUFCurrency" true 
                let builder () = withMnemonic mnemonic ((_LUFCurrency.cell :?> LUFCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LUFCurrency.source + ".FractionSymbol") 
                                               [| _LUFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LUFCurrency.cell
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
    [<ExcelFunction(Name="_LUFCurrency_name", Description="Create a LUFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LUFCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LUFCurrency",Description = "Reference to LUFCurrency")>] 
         lufcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LUFCurrency = Helper.toCell<LUFCurrency> lufcurrency "LUFCurrency" true 
                let builder () = withMnemonic mnemonic ((_LUFCurrency.cell :?> LUFCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LUFCurrency.source + ".Name") 
                                               [| _LUFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LUFCurrency.cell
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
    [<ExcelFunction(Name="_LUFCurrency_numericCode", Description="Create a LUFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LUFCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LUFCurrency",Description = "Reference to LUFCurrency")>] 
         lufcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LUFCurrency = Helper.toCell<LUFCurrency> lufcurrency "LUFCurrency" true 
                let builder () = withMnemonic mnemonic ((_LUFCurrency.cell :?> LUFCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_LUFCurrency.source + ".NumericCode") 
                                               [| _LUFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LUFCurrency.cell
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
    [<ExcelFunction(Name="_LUFCurrency_rounding", Description="Create a LUFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LUFCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LUFCurrency",Description = "Reference to LUFCurrency")>] 
         lufcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LUFCurrency = Helper.toCell<LUFCurrency> lufcurrency "LUFCurrency" true 
                let builder () = withMnemonic mnemonic ((_LUFCurrency.cell :?> LUFCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_LUFCurrency.source + ".Rounding") 
                                               [| _LUFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LUFCurrency.cell
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
    [<ExcelFunction(Name="_LUFCurrency_symbol", Description="Create a LUFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LUFCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LUFCurrency",Description = "Reference to LUFCurrency")>] 
         lufcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LUFCurrency = Helper.toCell<LUFCurrency> lufcurrency "LUFCurrency" true 
                let builder () = withMnemonic mnemonic ((_LUFCurrency.cell :?> LUFCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LUFCurrency.source + ".Symbol") 
                                               [| _LUFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LUFCurrency.cell
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
    [<ExcelFunction(Name="_LUFCurrency_ToString", Description="Create a LUFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LUFCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LUFCurrency",Description = "Reference to LUFCurrency")>] 
         lufcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LUFCurrency = Helper.toCell<LUFCurrency> lufcurrency "LUFCurrency" true 
                let builder () = withMnemonic mnemonic ((_LUFCurrency.cell :?> LUFCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LUFCurrency.source + ".ToString") 
                                               [| _LUFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LUFCurrency.cell
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
    [<ExcelFunction(Name="_LUFCurrency_triangulationCurrency", Description="Create a LUFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LUFCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LUFCurrency",Description = "Reference to LUFCurrency")>] 
         lufcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LUFCurrency = Helper.toCell<LUFCurrency> lufcurrency "LUFCurrency" true 
                let builder () = withMnemonic mnemonic ((_LUFCurrency.cell :?> LUFCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_LUFCurrency.source + ".TriangulationCurrency") 
                                               [| _LUFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LUFCurrency.cell
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
    [<ExcelFunction(Name="_LUFCurrency_Range", Description="Create a range of LUFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LUFCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the LUFCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LUFCurrency> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<LUFCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<LUFCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<LUFCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
