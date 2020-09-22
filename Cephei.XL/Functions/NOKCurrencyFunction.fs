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
module NOKCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_NOKCurrency", Description="Create a NOKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NOKCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.NOKCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NOKCurrency>) l

                let source = Helper.sourceFold "Fun.NOKCurrency" 
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
    [<ExcelFunction(Name="_NOKCurrency_code", Description="Create a NOKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NOKCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NOKCurrency",Description = "Reference to NOKCurrency")>] 
         nokcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NOKCurrency = Helper.toCell<NOKCurrency> nokcurrency "NOKCurrency" true 
                let builder () = withMnemonic mnemonic ((_NOKCurrency.cell :?> NOKCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NOKCurrency.source + ".Code") 
                                               [| _NOKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NOKCurrency.cell
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
    [<ExcelFunction(Name="_NOKCurrency_empty", Description="Create a NOKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NOKCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NOKCurrency",Description = "Reference to NOKCurrency")>] 
         nokcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NOKCurrency = Helper.toCell<NOKCurrency> nokcurrency "NOKCurrency" true 
                let builder () = withMnemonic mnemonic ((_NOKCurrency.cell :?> NOKCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NOKCurrency.source + ".Empty") 
                                               [| _NOKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NOKCurrency.cell
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
    [<ExcelFunction(Name="_NOKCurrency_Equals", Description="Create a NOKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NOKCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NOKCurrency",Description = "Reference to NOKCurrency")>] 
         nokcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NOKCurrency = Helper.toCell<NOKCurrency> nokcurrency "NOKCurrency" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_NOKCurrency.cell :?> NOKCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NOKCurrency.source + ".Equals") 
                                               [| _NOKCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NOKCurrency.cell
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
    [<ExcelFunction(Name="_NOKCurrency_format", Description="Create a NOKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NOKCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NOKCurrency",Description = "Reference to NOKCurrency")>] 
         nokcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NOKCurrency = Helper.toCell<NOKCurrency> nokcurrency "NOKCurrency" true 
                let builder () = withMnemonic mnemonic ((_NOKCurrency.cell :?> NOKCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NOKCurrency.source + ".Format") 
                                               [| _NOKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NOKCurrency.cell
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
    [<ExcelFunction(Name="_NOKCurrency_fractionsPerUnit", Description="Create a NOKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NOKCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NOKCurrency",Description = "Reference to NOKCurrency")>] 
         nokcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NOKCurrency = Helper.toCell<NOKCurrency> nokcurrency "NOKCurrency" true 
                let builder () = withMnemonic mnemonic ((_NOKCurrency.cell :?> NOKCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_NOKCurrency.source + ".FractionsPerUnit") 
                                               [| _NOKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NOKCurrency.cell
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
    [<ExcelFunction(Name="_NOKCurrency_fractionSymbol", Description="Create a NOKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NOKCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NOKCurrency",Description = "Reference to NOKCurrency")>] 
         nokcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NOKCurrency = Helper.toCell<NOKCurrency> nokcurrency "NOKCurrency" true 
                let builder () = withMnemonic mnemonic ((_NOKCurrency.cell :?> NOKCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NOKCurrency.source + ".FractionSymbol") 
                                               [| _NOKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NOKCurrency.cell
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
    [<ExcelFunction(Name="_NOKCurrency_name", Description="Create a NOKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NOKCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NOKCurrency",Description = "Reference to NOKCurrency")>] 
         nokcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NOKCurrency = Helper.toCell<NOKCurrency> nokcurrency "NOKCurrency" true 
                let builder () = withMnemonic mnemonic ((_NOKCurrency.cell :?> NOKCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NOKCurrency.source + ".Name") 
                                               [| _NOKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NOKCurrency.cell
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
    [<ExcelFunction(Name="_NOKCurrency_numericCode", Description="Create a NOKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NOKCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NOKCurrency",Description = "Reference to NOKCurrency")>] 
         nokcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NOKCurrency = Helper.toCell<NOKCurrency> nokcurrency "NOKCurrency" true 
                let builder () = withMnemonic mnemonic ((_NOKCurrency.cell :?> NOKCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_NOKCurrency.source + ".NumericCode") 
                                               [| _NOKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NOKCurrency.cell
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
    [<ExcelFunction(Name="_NOKCurrency_rounding", Description="Create a NOKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NOKCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NOKCurrency",Description = "Reference to NOKCurrency")>] 
         nokcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NOKCurrency = Helper.toCell<NOKCurrency> nokcurrency "NOKCurrency" true 
                let builder () = withMnemonic mnemonic ((_NOKCurrency.cell :?> NOKCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_NOKCurrency.source + ".Rounding") 
                                               [| _NOKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NOKCurrency.cell
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
    [<ExcelFunction(Name="_NOKCurrency_symbol", Description="Create a NOKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NOKCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NOKCurrency",Description = "Reference to NOKCurrency")>] 
         nokcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NOKCurrency = Helper.toCell<NOKCurrency> nokcurrency "NOKCurrency" true 
                let builder () = withMnemonic mnemonic ((_NOKCurrency.cell :?> NOKCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NOKCurrency.source + ".Symbol") 
                                               [| _NOKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NOKCurrency.cell
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
    [<ExcelFunction(Name="_NOKCurrency_ToString", Description="Create a NOKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NOKCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NOKCurrency",Description = "Reference to NOKCurrency")>] 
         nokcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NOKCurrency = Helper.toCell<NOKCurrency> nokcurrency "NOKCurrency" true 
                let builder () = withMnemonic mnemonic ((_NOKCurrency.cell :?> NOKCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NOKCurrency.source + ".ToString") 
                                               [| _NOKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NOKCurrency.cell
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
    [<ExcelFunction(Name="_NOKCurrency_triangulationCurrency", Description="Create a NOKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NOKCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NOKCurrency",Description = "Reference to NOKCurrency")>] 
         nokcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NOKCurrency = Helper.toCell<NOKCurrency> nokcurrency "NOKCurrency" true 
                let builder () = withMnemonic mnemonic ((_NOKCurrency.cell :?> NOKCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_NOKCurrency.source + ".TriangulationCurrency") 
                                               [| _NOKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NOKCurrency.cell
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
    [<ExcelFunction(Name="_NOKCurrency_Range", Description="Create a range of NOKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NOKCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the NOKCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<NOKCurrency> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<NOKCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<NOKCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<NOKCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
