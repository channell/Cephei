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
module FRFCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FRFCurrency", Description="Create a FRFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FRFCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.FRFCurrency 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FRFCurrency>) l

                let source = Helper.sourceFold "Fun.FRFCurrency" 
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
    [<ExcelFunction(Name="_FRFCurrency_code", Description="Create a FRFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FRFCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRFCurrency",Description = "Reference to FRFCurrency")>] 
         frfcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRFCurrency = Helper.toCell<FRFCurrency> frfcurrency "FRFCurrency" true 
                let builder () = withMnemonic mnemonic ((_FRFCurrency.cell :?> FRFCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FRFCurrency.source + ".Code") 
                                               [| _FRFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FRFCurrency.cell
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
    [<ExcelFunction(Name="_FRFCurrency_empty", Description="Create a FRFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FRFCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRFCurrency",Description = "Reference to FRFCurrency")>] 
         frfcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRFCurrency = Helper.toCell<FRFCurrency> frfcurrency "FRFCurrency" true 
                let builder () = withMnemonic mnemonic ((_FRFCurrency.cell :?> FRFCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FRFCurrency.source + ".Empty") 
                                               [| _FRFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FRFCurrency.cell
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
    [<ExcelFunction(Name="_FRFCurrency_Equals", Description="Create a FRFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FRFCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRFCurrency",Description = "Reference to FRFCurrency")>] 
         frfcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRFCurrency = Helper.toCell<FRFCurrency> frfcurrency "FRFCurrency" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_FRFCurrency.cell :?> FRFCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FRFCurrency.source + ".Equals") 
                                               [| _FRFCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FRFCurrency.cell
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
    [<ExcelFunction(Name="_FRFCurrency_format", Description="Create a FRFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FRFCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRFCurrency",Description = "Reference to FRFCurrency")>] 
         frfcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRFCurrency = Helper.toCell<FRFCurrency> frfcurrency "FRFCurrency" true 
                let builder () = withMnemonic mnemonic ((_FRFCurrency.cell :?> FRFCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FRFCurrency.source + ".Format") 
                                               [| _FRFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FRFCurrency.cell
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
    [<ExcelFunction(Name="_FRFCurrency_fractionsPerUnit", Description="Create a FRFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FRFCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRFCurrency",Description = "Reference to FRFCurrency")>] 
         frfcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRFCurrency = Helper.toCell<FRFCurrency> frfcurrency "FRFCurrency" true 
                let builder () = withMnemonic mnemonic ((_FRFCurrency.cell :?> FRFCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_FRFCurrency.source + ".FractionsPerUnit") 
                                               [| _FRFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FRFCurrency.cell
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
    [<ExcelFunction(Name="_FRFCurrency_fractionSymbol", Description="Create a FRFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FRFCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRFCurrency",Description = "Reference to FRFCurrency")>] 
         frfcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRFCurrency = Helper.toCell<FRFCurrency> frfcurrency "FRFCurrency" true 
                let builder () = withMnemonic mnemonic ((_FRFCurrency.cell :?> FRFCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FRFCurrency.source + ".FractionSymbol") 
                                               [| _FRFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FRFCurrency.cell
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
    [<ExcelFunction(Name="_FRFCurrency_name", Description="Create a FRFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FRFCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRFCurrency",Description = "Reference to FRFCurrency")>] 
         frfcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRFCurrency = Helper.toCell<FRFCurrency> frfcurrency "FRFCurrency" true 
                let builder () = withMnemonic mnemonic ((_FRFCurrency.cell :?> FRFCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FRFCurrency.source + ".Name") 
                                               [| _FRFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FRFCurrency.cell
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
    [<ExcelFunction(Name="_FRFCurrency_numericCode", Description="Create a FRFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FRFCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRFCurrency",Description = "Reference to FRFCurrency")>] 
         frfcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRFCurrency = Helper.toCell<FRFCurrency> frfcurrency "FRFCurrency" true 
                let builder () = withMnemonic mnemonic ((_FRFCurrency.cell :?> FRFCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_FRFCurrency.source + ".NumericCode") 
                                               [| _FRFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FRFCurrency.cell
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
    [<ExcelFunction(Name="_FRFCurrency_rounding", Description="Create a FRFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FRFCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRFCurrency",Description = "Reference to FRFCurrency")>] 
         frfcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRFCurrency = Helper.toCell<FRFCurrency> frfcurrency "FRFCurrency" true 
                let builder () = withMnemonic mnemonic ((_FRFCurrency.cell :?> FRFCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_FRFCurrency.source + ".Rounding") 
                                               [| _FRFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FRFCurrency.cell
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
    [<ExcelFunction(Name="_FRFCurrency_symbol", Description="Create a FRFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FRFCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRFCurrency",Description = "Reference to FRFCurrency")>] 
         frfcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRFCurrency = Helper.toCell<FRFCurrency> frfcurrency "FRFCurrency" true 
                let builder () = withMnemonic mnemonic ((_FRFCurrency.cell :?> FRFCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FRFCurrency.source + ".Symbol") 
                                               [| _FRFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FRFCurrency.cell
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
    [<ExcelFunction(Name="_FRFCurrency_ToString", Description="Create a FRFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FRFCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRFCurrency",Description = "Reference to FRFCurrency")>] 
         frfcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRFCurrency = Helper.toCell<FRFCurrency> frfcurrency "FRFCurrency" true 
                let builder () = withMnemonic mnemonic ((_FRFCurrency.cell :?> FRFCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FRFCurrency.source + ".ToString") 
                                               [| _FRFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FRFCurrency.cell
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
    [<ExcelFunction(Name="_FRFCurrency_triangulationCurrency", Description="Create a FRFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FRFCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRFCurrency",Description = "Reference to FRFCurrency")>] 
         frfcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRFCurrency = Helper.toCell<FRFCurrency> frfcurrency "FRFCurrency" true 
                let builder () = withMnemonic mnemonic ((_FRFCurrency.cell :?> FRFCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_FRFCurrency.source + ".TriangulationCurrency") 
                                               [| _FRFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FRFCurrency.cell
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
    [<ExcelFunction(Name="_FRFCurrency_Range", Description="Create a range of FRFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FRFCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FRFCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FRFCurrency> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FRFCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FRFCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FRFCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
