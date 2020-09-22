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
module CZKCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CZKCurrency", Description="Create a CZKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CZKCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.CZKCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CZKCurrency>) l

                let source = Helper.sourceFold "Fun.CZKCurrency" 
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
    [<ExcelFunction(Name="_CZKCurrency_code", Description="Create a CZKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CZKCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CZKCurrency",Description = "Reference to CZKCurrency")>] 
         czkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CZKCurrency = Helper.toCell<CZKCurrency> czkcurrency "CZKCurrency" true 
                let builder () = withMnemonic mnemonic ((_CZKCurrency.cell :?> CZKCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CZKCurrency.source + ".Code") 
                                               [| _CZKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CZKCurrency.cell
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
    [<ExcelFunction(Name="_CZKCurrency_empty", Description="Create a CZKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CZKCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CZKCurrency",Description = "Reference to CZKCurrency")>] 
         czkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CZKCurrency = Helper.toCell<CZKCurrency> czkcurrency "CZKCurrency" true 
                let builder () = withMnemonic mnemonic ((_CZKCurrency.cell :?> CZKCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CZKCurrency.source + ".Empty") 
                                               [| _CZKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CZKCurrency.cell
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
    [<ExcelFunction(Name="_CZKCurrency_Equals", Description="Create a CZKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CZKCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CZKCurrency",Description = "Reference to CZKCurrency")>] 
         czkcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CZKCurrency = Helper.toCell<CZKCurrency> czkcurrency "CZKCurrency" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_CZKCurrency.cell :?> CZKCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CZKCurrency.source + ".Equals") 
                                               [| _CZKCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CZKCurrency.cell
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
    [<ExcelFunction(Name="_CZKCurrency_format", Description="Create a CZKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CZKCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CZKCurrency",Description = "Reference to CZKCurrency")>] 
         czkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CZKCurrency = Helper.toCell<CZKCurrency> czkcurrency "CZKCurrency" true 
                let builder () = withMnemonic mnemonic ((_CZKCurrency.cell :?> CZKCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CZKCurrency.source + ".Format") 
                                               [| _CZKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CZKCurrency.cell
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
    [<ExcelFunction(Name="_CZKCurrency_fractionsPerUnit", Description="Create a CZKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CZKCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CZKCurrency",Description = "Reference to CZKCurrency")>] 
         czkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CZKCurrency = Helper.toCell<CZKCurrency> czkcurrency "CZKCurrency" true 
                let builder () = withMnemonic mnemonic ((_CZKCurrency.cell :?> CZKCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CZKCurrency.source + ".FractionsPerUnit") 
                                               [| _CZKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CZKCurrency.cell
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
    [<ExcelFunction(Name="_CZKCurrency_fractionSymbol", Description="Create a CZKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CZKCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CZKCurrency",Description = "Reference to CZKCurrency")>] 
         czkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CZKCurrency = Helper.toCell<CZKCurrency> czkcurrency "CZKCurrency" true 
                let builder () = withMnemonic mnemonic ((_CZKCurrency.cell :?> CZKCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CZKCurrency.source + ".FractionSymbol") 
                                               [| _CZKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CZKCurrency.cell
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
    [<ExcelFunction(Name="_CZKCurrency_name", Description="Create a CZKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CZKCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CZKCurrency",Description = "Reference to CZKCurrency")>] 
         czkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CZKCurrency = Helper.toCell<CZKCurrency> czkcurrency "CZKCurrency" true 
                let builder () = withMnemonic mnemonic ((_CZKCurrency.cell :?> CZKCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CZKCurrency.source + ".Name") 
                                               [| _CZKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CZKCurrency.cell
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
    [<ExcelFunction(Name="_CZKCurrency_numericCode", Description="Create a CZKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CZKCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CZKCurrency",Description = "Reference to CZKCurrency")>] 
         czkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CZKCurrency = Helper.toCell<CZKCurrency> czkcurrency "CZKCurrency" true 
                let builder () = withMnemonic mnemonic ((_CZKCurrency.cell :?> CZKCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CZKCurrency.source + ".NumericCode") 
                                               [| _CZKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CZKCurrency.cell
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
    [<ExcelFunction(Name="_CZKCurrency_rounding", Description="Create a CZKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CZKCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CZKCurrency",Description = "Reference to CZKCurrency")>] 
         czkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CZKCurrency = Helper.toCell<CZKCurrency> czkcurrency "CZKCurrency" true 
                let builder () = withMnemonic mnemonic ((_CZKCurrency.cell :?> CZKCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_CZKCurrency.source + ".Rounding") 
                                               [| _CZKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CZKCurrency.cell
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
    [<ExcelFunction(Name="_CZKCurrency_symbol", Description="Create a CZKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CZKCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CZKCurrency",Description = "Reference to CZKCurrency")>] 
         czkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CZKCurrency = Helper.toCell<CZKCurrency> czkcurrency "CZKCurrency" true 
                let builder () = withMnemonic mnemonic ((_CZKCurrency.cell :?> CZKCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CZKCurrency.source + ".Symbol") 
                                               [| _CZKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CZKCurrency.cell
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
    [<ExcelFunction(Name="_CZKCurrency_ToString", Description="Create a CZKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CZKCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CZKCurrency",Description = "Reference to CZKCurrency")>] 
         czkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CZKCurrency = Helper.toCell<CZKCurrency> czkcurrency "CZKCurrency" true 
                let builder () = withMnemonic mnemonic ((_CZKCurrency.cell :?> CZKCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CZKCurrency.source + ".ToString") 
                                               [| _CZKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CZKCurrency.cell
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
    [<ExcelFunction(Name="_CZKCurrency_triangulationCurrency", Description="Create a CZKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CZKCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CZKCurrency",Description = "Reference to CZKCurrency")>] 
         czkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CZKCurrency = Helper.toCell<CZKCurrency> czkcurrency "CZKCurrency" true 
                let builder () = withMnemonic mnemonic ((_CZKCurrency.cell :?> CZKCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_CZKCurrency.source + ".TriangulationCurrency") 
                                               [| _CZKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CZKCurrency.cell
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
    [<ExcelFunction(Name="_CZKCurrency_Range", Description="Create a range of CZKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CZKCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CZKCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CZKCurrency> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CZKCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CZKCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CZKCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
