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
module EURCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EURCurrency", Description="Create a EURCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.EURCurrency 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EURCurrency>) l

                let source = Helper.sourceFold "Fun.EURCurrency" 
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
    [<ExcelFunction(Name="_EURCurrency_code", Description="Create a EURCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURCurrency",Description = "Reference to EURCurrency")>] 
         eurcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURCurrency = Helper.toCell<EURCurrency> eurcurrency "EURCurrency" true 
                let builder () = withMnemonic mnemonic ((_EURCurrency.cell :?> EURCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURCurrency.source + ".Code") 
                                               [| _EURCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURCurrency.cell
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
    [<ExcelFunction(Name="_EURCurrency_empty", Description="Create a EURCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURCurrency",Description = "Reference to EURCurrency")>] 
         eurcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURCurrency = Helper.toCell<EURCurrency> eurcurrency "EURCurrency" true 
                let builder () = withMnemonic mnemonic ((_EURCurrency.cell :?> EURCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURCurrency.source + ".Empty") 
                                               [| _EURCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURCurrency.cell
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
    [<ExcelFunction(Name="_EURCurrency_Equals", Description="Create a EURCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURCurrency",Description = "Reference to EURCurrency")>] 
         eurcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURCurrency = Helper.toCell<EURCurrency> eurcurrency "EURCurrency" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_EURCurrency.cell :?> EURCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURCurrency.source + ".Equals") 
                                               [| _EURCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURCurrency.cell
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
    [<ExcelFunction(Name="_EURCurrency_format", Description="Create a EURCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURCurrency",Description = "Reference to EURCurrency")>] 
         eurcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURCurrency = Helper.toCell<EURCurrency> eurcurrency "EURCurrency" true 
                let builder () = withMnemonic mnemonic ((_EURCurrency.cell :?> EURCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURCurrency.source + ".Format") 
                                               [| _EURCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURCurrency.cell
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
    [<ExcelFunction(Name="_EURCurrency_fractionsPerUnit", Description="Create a EURCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURCurrency",Description = "Reference to EURCurrency")>] 
         eurcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURCurrency = Helper.toCell<EURCurrency> eurcurrency "EURCurrency" true 
                let builder () = withMnemonic mnemonic ((_EURCurrency.cell :?> EURCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURCurrency.source + ".FractionsPerUnit") 
                                               [| _EURCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURCurrency.cell
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
    [<ExcelFunction(Name="_EURCurrency_fractionSymbol", Description="Create a EURCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURCurrency",Description = "Reference to EURCurrency")>] 
         eurcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURCurrency = Helper.toCell<EURCurrency> eurcurrency "EURCurrency" true 
                let builder () = withMnemonic mnemonic ((_EURCurrency.cell :?> EURCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURCurrency.source + ".FractionSymbol") 
                                               [| _EURCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURCurrency.cell
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
    [<ExcelFunction(Name="_EURCurrency_name", Description="Create a EURCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURCurrency",Description = "Reference to EURCurrency")>] 
         eurcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURCurrency = Helper.toCell<EURCurrency> eurcurrency "EURCurrency" true 
                let builder () = withMnemonic mnemonic ((_EURCurrency.cell :?> EURCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURCurrency.source + ".Name") 
                                               [| _EURCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURCurrency.cell
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
    [<ExcelFunction(Name="_EURCurrency_numericCode", Description="Create a EURCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURCurrency",Description = "Reference to EURCurrency")>] 
         eurcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURCurrency = Helper.toCell<EURCurrency> eurcurrency "EURCurrency" true 
                let builder () = withMnemonic mnemonic ((_EURCurrency.cell :?> EURCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURCurrency.source + ".NumericCode") 
                                               [| _EURCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURCurrency.cell
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
    [<ExcelFunction(Name="_EURCurrency_rounding", Description="Create a EURCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURCurrency",Description = "Reference to EURCurrency")>] 
         eurcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURCurrency = Helper.toCell<EURCurrency> eurcurrency "EURCurrency" true 
                let builder () = withMnemonic mnemonic ((_EURCurrency.cell :?> EURCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_EURCurrency.source + ".Rounding") 
                                               [| _EURCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURCurrency.cell
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
    [<ExcelFunction(Name="_EURCurrency_symbol", Description="Create a EURCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURCurrency",Description = "Reference to EURCurrency")>] 
         eurcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURCurrency = Helper.toCell<EURCurrency> eurcurrency "EURCurrency" true 
                let builder () = withMnemonic mnemonic ((_EURCurrency.cell :?> EURCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURCurrency.source + ".Symbol") 
                                               [| _EURCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURCurrency.cell
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
    [<ExcelFunction(Name="_EURCurrency_ToString", Description="Create a EURCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURCurrency",Description = "Reference to EURCurrency")>] 
         eurcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURCurrency = Helper.toCell<EURCurrency> eurcurrency "EURCurrency" true 
                let builder () = withMnemonic mnemonic ((_EURCurrency.cell :?> EURCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURCurrency.source + ".ToString") 
                                               [| _EURCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURCurrency.cell
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
    [<ExcelFunction(Name="_EURCurrency_triangulationCurrency", Description="Create a EURCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURCurrency",Description = "Reference to EURCurrency")>] 
         eurcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURCurrency = Helper.toCell<EURCurrency> eurcurrency "EURCurrency" true 
                let builder () = withMnemonic mnemonic ((_EURCurrency.cell :?> EURCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_EURCurrency.source + ".TriangulationCurrency") 
                                               [| _EURCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURCurrency.cell
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
    [<ExcelFunction(Name="_EURCurrency_Range", Description="Create a range of EURCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the EURCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EURCurrency> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<EURCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<EURCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<EURCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
