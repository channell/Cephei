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
  The ISO three-letter code is IDR; the numeric code is 360. It is divided in 100 sen.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module IDRCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_IDRCurrency", Description="Create a IDRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IDRCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.IDRCurrency 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IDRCurrency>) l

                let source = Helper.sourceFold "Fun.IDRCurrency" 
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
    [<ExcelFunction(Name="_IDRCurrency_code", Description="Create a IDRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IDRCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IDRCurrency",Description = "Reference to IDRCurrency")>] 
         idrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IDRCurrency = Helper.toCell<IDRCurrency> idrcurrency "IDRCurrency" true 
                let builder () = withMnemonic mnemonic ((_IDRCurrency.cell :?> IDRCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IDRCurrency.source + ".Code") 
                                               [| _IDRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IDRCurrency.cell
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
    [<ExcelFunction(Name="_IDRCurrency_empty", Description="Create a IDRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IDRCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IDRCurrency",Description = "Reference to IDRCurrency")>] 
         idrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IDRCurrency = Helper.toCell<IDRCurrency> idrcurrency "IDRCurrency" true 
                let builder () = withMnemonic mnemonic ((_IDRCurrency.cell :?> IDRCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IDRCurrency.source + ".Empty") 
                                               [| _IDRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IDRCurrency.cell
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
    [<ExcelFunction(Name="_IDRCurrency_Equals", Description="Create a IDRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IDRCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IDRCurrency",Description = "Reference to IDRCurrency")>] 
         idrcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IDRCurrency = Helper.toCell<IDRCurrency> idrcurrency "IDRCurrency" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_IDRCurrency.cell :?> IDRCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IDRCurrency.source + ".Equals") 
                                               [| _IDRCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IDRCurrency.cell
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
    [<ExcelFunction(Name="_IDRCurrency_format", Description="Create a IDRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IDRCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IDRCurrency",Description = "Reference to IDRCurrency")>] 
         idrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IDRCurrency = Helper.toCell<IDRCurrency> idrcurrency "IDRCurrency" true 
                let builder () = withMnemonic mnemonic ((_IDRCurrency.cell :?> IDRCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IDRCurrency.source + ".Format") 
                                               [| _IDRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IDRCurrency.cell
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
    [<ExcelFunction(Name="_IDRCurrency_fractionsPerUnit", Description="Create a IDRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IDRCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IDRCurrency",Description = "Reference to IDRCurrency")>] 
         idrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IDRCurrency = Helper.toCell<IDRCurrency> idrcurrency "IDRCurrency" true 
                let builder () = withMnemonic mnemonic ((_IDRCurrency.cell :?> IDRCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_IDRCurrency.source + ".FractionsPerUnit") 
                                               [| _IDRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IDRCurrency.cell
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
    [<ExcelFunction(Name="_IDRCurrency_fractionSymbol", Description="Create a IDRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IDRCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IDRCurrency",Description = "Reference to IDRCurrency")>] 
         idrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IDRCurrency = Helper.toCell<IDRCurrency> idrcurrency "IDRCurrency" true 
                let builder () = withMnemonic mnemonic ((_IDRCurrency.cell :?> IDRCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IDRCurrency.source + ".FractionSymbol") 
                                               [| _IDRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IDRCurrency.cell
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
    [<ExcelFunction(Name="_IDRCurrency_name", Description="Create a IDRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IDRCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IDRCurrency",Description = "Reference to IDRCurrency")>] 
         idrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IDRCurrency = Helper.toCell<IDRCurrency> idrcurrency "IDRCurrency" true 
                let builder () = withMnemonic mnemonic ((_IDRCurrency.cell :?> IDRCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IDRCurrency.source + ".Name") 
                                               [| _IDRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IDRCurrency.cell
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
    [<ExcelFunction(Name="_IDRCurrency_numericCode", Description="Create a IDRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IDRCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IDRCurrency",Description = "Reference to IDRCurrency")>] 
         idrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IDRCurrency = Helper.toCell<IDRCurrency> idrcurrency "IDRCurrency" true 
                let builder () = withMnemonic mnemonic ((_IDRCurrency.cell :?> IDRCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_IDRCurrency.source + ".NumericCode") 
                                               [| _IDRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IDRCurrency.cell
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
    [<ExcelFunction(Name="_IDRCurrency_rounding", Description="Create a IDRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IDRCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IDRCurrency",Description = "Reference to IDRCurrency")>] 
         idrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IDRCurrency = Helper.toCell<IDRCurrency> idrcurrency "IDRCurrency" true 
                let builder () = withMnemonic mnemonic ((_IDRCurrency.cell :?> IDRCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_IDRCurrency.source + ".Rounding") 
                                               [| _IDRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IDRCurrency.cell
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
    [<ExcelFunction(Name="_IDRCurrency_symbol", Description="Create a IDRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IDRCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IDRCurrency",Description = "Reference to IDRCurrency")>] 
         idrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IDRCurrency = Helper.toCell<IDRCurrency> idrcurrency "IDRCurrency" true 
                let builder () = withMnemonic mnemonic ((_IDRCurrency.cell :?> IDRCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IDRCurrency.source + ".Symbol") 
                                               [| _IDRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IDRCurrency.cell
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
    [<ExcelFunction(Name="_IDRCurrency_ToString", Description="Create a IDRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IDRCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IDRCurrency",Description = "Reference to IDRCurrency")>] 
         idrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IDRCurrency = Helper.toCell<IDRCurrency> idrcurrency "IDRCurrency" true 
                let builder () = withMnemonic mnemonic ((_IDRCurrency.cell :?> IDRCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IDRCurrency.source + ".ToString") 
                                               [| _IDRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IDRCurrency.cell
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
    [<ExcelFunction(Name="_IDRCurrency_triangulationCurrency", Description="Create a IDRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IDRCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IDRCurrency",Description = "Reference to IDRCurrency")>] 
         idrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IDRCurrency = Helper.toCell<IDRCurrency> idrcurrency "IDRCurrency" true 
                let builder () = withMnemonic mnemonic ((_IDRCurrency.cell :?> IDRCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_IDRCurrency.source + ".TriangulationCurrency") 
                                               [| _IDRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IDRCurrency.cell
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
    [<ExcelFunction(Name="_IDRCurrency_Range", Description="Create a range of IDRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IDRCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the IDRCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<IDRCurrency> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<IDRCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<IDRCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<IDRCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
