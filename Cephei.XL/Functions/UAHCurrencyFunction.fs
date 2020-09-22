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
  The ISO three-letter code is UAH; the numeric code is 980. It is divided in 100 kopiykas.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module UAHCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_UAHCurrency", Description="Create a UAHCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UAHCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.UAHCurrency 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<UAHCurrency>) l

                let source = Helper.sourceFold "Fun.UAHCurrency" 
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
    [<ExcelFunction(Name="_UAHCurrency_code", Description="Create a UAHCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UAHCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UAHCurrency",Description = "Reference to UAHCurrency")>] 
         uahcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UAHCurrency = Helper.toCell<UAHCurrency> uahcurrency "UAHCurrency" true 
                let builder () = withMnemonic mnemonic ((_UAHCurrency.cell :?> UAHCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UAHCurrency.source + ".Code") 
                                               [| _UAHCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UAHCurrency.cell
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
    [<ExcelFunction(Name="_UAHCurrency_empty", Description="Create a UAHCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UAHCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UAHCurrency",Description = "Reference to UAHCurrency")>] 
         uahcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UAHCurrency = Helper.toCell<UAHCurrency> uahcurrency "UAHCurrency" true 
                let builder () = withMnemonic mnemonic ((_UAHCurrency.cell :?> UAHCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UAHCurrency.source + ".Empty") 
                                               [| _UAHCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UAHCurrency.cell
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
    [<ExcelFunction(Name="_UAHCurrency_Equals", Description="Create a UAHCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UAHCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UAHCurrency",Description = "Reference to UAHCurrency")>] 
         uahcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UAHCurrency = Helper.toCell<UAHCurrency> uahcurrency "UAHCurrency" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_UAHCurrency.cell :?> UAHCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UAHCurrency.source + ".Equals") 
                                               [| _UAHCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UAHCurrency.cell
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
    [<ExcelFunction(Name="_UAHCurrency_format", Description="Create a UAHCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UAHCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UAHCurrency",Description = "Reference to UAHCurrency")>] 
         uahcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UAHCurrency = Helper.toCell<UAHCurrency> uahcurrency "UAHCurrency" true 
                let builder () = withMnemonic mnemonic ((_UAHCurrency.cell :?> UAHCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UAHCurrency.source + ".Format") 
                                               [| _UAHCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UAHCurrency.cell
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
    [<ExcelFunction(Name="_UAHCurrency_fractionsPerUnit", Description="Create a UAHCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UAHCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UAHCurrency",Description = "Reference to UAHCurrency")>] 
         uahcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UAHCurrency = Helper.toCell<UAHCurrency> uahcurrency "UAHCurrency" true 
                let builder () = withMnemonic mnemonic ((_UAHCurrency.cell :?> UAHCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_UAHCurrency.source + ".FractionsPerUnit") 
                                               [| _UAHCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UAHCurrency.cell
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
    [<ExcelFunction(Name="_UAHCurrency_fractionSymbol", Description="Create a UAHCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UAHCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UAHCurrency",Description = "Reference to UAHCurrency")>] 
         uahcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UAHCurrency = Helper.toCell<UAHCurrency> uahcurrency "UAHCurrency" true 
                let builder () = withMnemonic mnemonic ((_UAHCurrency.cell :?> UAHCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UAHCurrency.source + ".FractionSymbol") 
                                               [| _UAHCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UAHCurrency.cell
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
    [<ExcelFunction(Name="_UAHCurrency_name", Description="Create a UAHCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UAHCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UAHCurrency",Description = "Reference to UAHCurrency")>] 
         uahcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UAHCurrency = Helper.toCell<UAHCurrency> uahcurrency "UAHCurrency" true 
                let builder () = withMnemonic mnemonic ((_UAHCurrency.cell :?> UAHCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UAHCurrency.source + ".Name") 
                                               [| _UAHCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UAHCurrency.cell
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
    [<ExcelFunction(Name="_UAHCurrency_numericCode", Description="Create a UAHCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UAHCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UAHCurrency",Description = "Reference to UAHCurrency")>] 
         uahcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UAHCurrency = Helper.toCell<UAHCurrency> uahcurrency "UAHCurrency" true 
                let builder () = withMnemonic mnemonic ((_UAHCurrency.cell :?> UAHCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_UAHCurrency.source + ".NumericCode") 
                                               [| _UAHCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UAHCurrency.cell
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
    [<ExcelFunction(Name="_UAHCurrency_rounding", Description="Create a UAHCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UAHCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UAHCurrency",Description = "Reference to UAHCurrency")>] 
         uahcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UAHCurrency = Helper.toCell<UAHCurrency> uahcurrency "UAHCurrency" true 
                let builder () = withMnemonic mnemonic ((_UAHCurrency.cell :?> UAHCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_UAHCurrency.source + ".Rounding") 
                                               [| _UAHCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UAHCurrency.cell
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
    [<ExcelFunction(Name="_UAHCurrency_symbol", Description="Create a UAHCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UAHCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UAHCurrency",Description = "Reference to UAHCurrency")>] 
         uahcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UAHCurrency = Helper.toCell<UAHCurrency> uahcurrency "UAHCurrency" true 
                let builder () = withMnemonic mnemonic ((_UAHCurrency.cell :?> UAHCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UAHCurrency.source + ".Symbol") 
                                               [| _UAHCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UAHCurrency.cell
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
    [<ExcelFunction(Name="_UAHCurrency_ToString", Description="Create a UAHCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UAHCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UAHCurrency",Description = "Reference to UAHCurrency")>] 
         uahcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UAHCurrency = Helper.toCell<UAHCurrency> uahcurrency "UAHCurrency" true 
                let builder () = withMnemonic mnemonic ((_UAHCurrency.cell :?> UAHCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UAHCurrency.source + ".ToString") 
                                               [| _UAHCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UAHCurrency.cell
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
    [<ExcelFunction(Name="_UAHCurrency_triangulationCurrency", Description="Create a UAHCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UAHCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UAHCurrency",Description = "Reference to UAHCurrency")>] 
         uahcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UAHCurrency = Helper.toCell<UAHCurrency> uahcurrency "UAHCurrency" true 
                let builder () = withMnemonic mnemonic ((_UAHCurrency.cell :?> UAHCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_UAHCurrency.source + ".TriangulationCurrency") 
                                               [| _UAHCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UAHCurrency.cell
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
    [<ExcelFunction(Name="_UAHCurrency_Range", Description="Create a range of UAHCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UAHCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the UAHCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<UAHCurrency> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<UAHCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<UAHCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<UAHCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
