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
module BGLCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BGLCurrency", Description="Create a BGLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BGLCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.BGLCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BGLCurrency>) l

                let source = Helper.sourceFold "Fun.BGLCurrency" 
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
    [<ExcelFunction(Name="_BGLCurrency_code", Description="Create a BGLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BGLCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BGLCurrency",Description = "Reference to BGLCurrency")>] 
         bglcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BGLCurrency = Helper.toCell<BGLCurrency> bglcurrency "BGLCurrency" true 
                let builder () = withMnemonic mnemonic ((_BGLCurrency.cell :?> BGLCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BGLCurrency.source + ".Code") 
                                               [| _BGLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BGLCurrency.cell
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
    [<ExcelFunction(Name="_BGLCurrency_empty", Description="Create a BGLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BGLCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BGLCurrency",Description = "Reference to BGLCurrency")>] 
         bglcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BGLCurrency = Helper.toCell<BGLCurrency> bglcurrency "BGLCurrency" true 
                let builder () = withMnemonic mnemonic ((_BGLCurrency.cell :?> BGLCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BGLCurrency.source + ".Empty") 
                                               [| _BGLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BGLCurrency.cell
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
    [<ExcelFunction(Name="_BGLCurrency_Equals", Description="Create a BGLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BGLCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BGLCurrency",Description = "Reference to BGLCurrency")>] 
         bglcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BGLCurrency = Helper.toCell<BGLCurrency> bglcurrency "BGLCurrency" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_BGLCurrency.cell :?> BGLCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BGLCurrency.source + ".Equals") 
                                               [| _BGLCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BGLCurrency.cell
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
    [<ExcelFunction(Name="_BGLCurrency_format", Description="Create a BGLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BGLCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BGLCurrency",Description = "Reference to BGLCurrency")>] 
         bglcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BGLCurrency = Helper.toCell<BGLCurrency> bglcurrency "BGLCurrency" true 
                let builder () = withMnemonic mnemonic ((_BGLCurrency.cell :?> BGLCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BGLCurrency.source + ".Format") 
                                               [| _BGLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BGLCurrency.cell
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
    [<ExcelFunction(Name="_BGLCurrency_fractionsPerUnit", Description="Create a BGLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BGLCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BGLCurrency",Description = "Reference to BGLCurrency")>] 
         bglcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BGLCurrency = Helper.toCell<BGLCurrency> bglcurrency "BGLCurrency" true 
                let builder () = withMnemonic mnemonic ((_BGLCurrency.cell :?> BGLCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_BGLCurrency.source + ".FractionsPerUnit") 
                                               [| _BGLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BGLCurrency.cell
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
    [<ExcelFunction(Name="_BGLCurrency_fractionSymbol", Description="Create a BGLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BGLCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BGLCurrency",Description = "Reference to BGLCurrency")>] 
         bglcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BGLCurrency = Helper.toCell<BGLCurrency> bglcurrency "BGLCurrency" true 
                let builder () = withMnemonic mnemonic ((_BGLCurrency.cell :?> BGLCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BGLCurrency.source + ".FractionSymbol") 
                                               [| _BGLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BGLCurrency.cell
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
    [<ExcelFunction(Name="_BGLCurrency_name", Description="Create a BGLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BGLCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BGLCurrency",Description = "Reference to BGLCurrency")>] 
         bglcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BGLCurrency = Helper.toCell<BGLCurrency> bglcurrency "BGLCurrency" true 
                let builder () = withMnemonic mnemonic ((_BGLCurrency.cell :?> BGLCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BGLCurrency.source + ".Name") 
                                               [| _BGLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BGLCurrency.cell
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
    [<ExcelFunction(Name="_BGLCurrency_numericCode", Description="Create a BGLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BGLCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BGLCurrency",Description = "Reference to BGLCurrency")>] 
         bglcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BGLCurrency = Helper.toCell<BGLCurrency> bglcurrency "BGLCurrency" true 
                let builder () = withMnemonic mnemonic ((_BGLCurrency.cell :?> BGLCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_BGLCurrency.source + ".NumericCode") 
                                               [| _BGLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BGLCurrency.cell
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
    [<ExcelFunction(Name="_BGLCurrency_rounding", Description="Create a BGLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BGLCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BGLCurrency",Description = "Reference to BGLCurrency")>] 
         bglcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BGLCurrency = Helper.toCell<BGLCurrency> bglcurrency "BGLCurrency" true 
                let builder () = withMnemonic mnemonic ((_BGLCurrency.cell :?> BGLCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_BGLCurrency.source + ".Rounding") 
                                               [| _BGLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BGLCurrency.cell
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
    [<ExcelFunction(Name="_BGLCurrency_symbol", Description="Create a BGLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BGLCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BGLCurrency",Description = "Reference to BGLCurrency")>] 
         bglcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BGLCurrency = Helper.toCell<BGLCurrency> bglcurrency "BGLCurrency" true 
                let builder () = withMnemonic mnemonic ((_BGLCurrency.cell :?> BGLCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BGLCurrency.source + ".Symbol") 
                                               [| _BGLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BGLCurrency.cell
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
    [<ExcelFunction(Name="_BGLCurrency_ToString", Description="Create a BGLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BGLCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BGLCurrency",Description = "Reference to BGLCurrency")>] 
         bglcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BGLCurrency = Helper.toCell<BGLCurrency> bglcurrency "BGLCurrency" true 
                let builder () = withMnemonic mnemonic ((_BGLCurrency.cell :?> BGLCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BGLCurrency.source + ".ToString") 
                                               [| _BGLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BGLCurrency.cell
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
    [<ExcelFunction(Name="_BGLCurrency_triangulationCurrency", Description="Create a BGLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BGLCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BGLCurrency",Description = "Reference to BGLCurrency")>] 
         bglcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BGLCurrency = Helper.toCell<BGLCurrency> bglcurrency "BGLCurrency" true 
                let builder () = withMnemonic mnemonic ((_BGLCurrency.cell :?> BGLCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_BGLCurrency.source + ".TriangulationCurrency") 
                                               [| _BGLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BGLCurrency.cell
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
    [<ExcelFunction(Name="_BGLCurrency_Range", Description="Create a range of BGLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BGLCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BGLCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BGLCurrency> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BGLCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BGLCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BGLCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
