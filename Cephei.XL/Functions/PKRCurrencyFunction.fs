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
  The ISO three-letter code is PKR; the numeric code is 586. It is divided in 100 paisa.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module PKRCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_PKRCurrency", Description="Create a PKRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PKRCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.PKRCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PKRCurrency>) l

                let source = Helper.sourceFold "Fun.PKRCurrency" 
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
    [<ExcelFunction(Name="_PKRCurrency_code", Description="Create a PKRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PKRCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PKRCurrency",Description = "Reference to PKRCurrency")>] 
         pkrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PKRCurrency = Helper.toCell<PKRCurrency> pkrcurrency "PKRCurrency" true 
                let builder () = withMnemonic mnemonic ((_PKRCurrency.cell :?> PKRCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PKRCurrency.source + ".Code") 
                                               [| _PKRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PKRCurrency.cell
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
    [<ExcelFunction(Name="_PKRCurrency_empty", Description="Create a PKRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PKRCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PKRCurrency",Description = "Reference to PKRCurrency")>] 
         pkrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PKRCurrency = Helper.toCell<PKRCurrency> pkrcurrency "PKRCurrency" true 
                let builder () = withMnemonic mnemonic ((_PKRCurrency.cell :?> PKRCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PKRCurrency.source + ".Empty") 
                                               [| _PKRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PKRCurrency.cell
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
    [<ExcelFunction(Name="_PKRCurrency_Equals", Description="Create a PKRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PKRCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PKRCurrency",Description = "Reference to PKRCurrency")>] 
         pkrcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PKRCurrency = Helper.toCell<PKRCurrency> pkrcurrency "PKRCurrency" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_PKRCurrency.cell :?> PKRCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PKRCurrency.source + ".Equals") 
                                               [| _PKRCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PKRCurrency.cell
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
    [<ExcelFunction(Name="_PKRCurrency_format", Description="Create a PKRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PKRCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PKRCurrency",Description = "Reference to PKRCurrency")>] 
         pkrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PKRCurrency = Helper.toCell<PKRCurrency> pkrcurrency "PKRCurrency" true 
                let builder () = withMnemonic mnemonic ((_PKRCurrency.cell :?> PKRCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PKRCurrency.source + ".Format") 
                                               [| _PKRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PKRCurrency.cell
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
    [<ExcelFunction(Name="_PKRCurrency_fractionsPerUnit", Description="Create a PKRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PKRCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PKRCurrency",Description = "Reference to PKRCurrency")>] 
         pkrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PKRCurrency = Helper.toCell<PKRCurrency> pkrcurrency "PKRCurrency" true 
                let builder () = withMnemonic mnemonic ((_PKRCurrency.cell :?> PKRCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_PKRCurrency.source + ".FractionsPerUnit") 
                                               [| _PKRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PKRCurrency.cell
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
    [<ExcelFunction(Name="_PKRCurrency_fractionSymbol", Description="Create a PKRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PKRCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PKRCurrency",Description = "Reference to PKRCurrency")>] 
         pkrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PKRCurrency = Helper.toCell<PKRCurrency> pkrcurrency "PKRCurrency" true 
                let builder () = withMnemonic mnemonic ((_PKRCurrency.cell :?> PKRCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PKRCurrency.source + ".FractionSymbol") 
                                               [| _PKRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PKRCurrency.cell
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
    [<ExcelFunction(Name="_PKRCurrency_name", Description="Create a PKRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PKRCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PKRCurrency",Description = "Reference to PKRCurrency")>] 
         pkrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PKRCurrency = Helper.toCell<PKRCurrency> pkrcurrency "PKRCurrency" true 
                let builder () = withMnemonic mnemonic ((_PKRCurrency.cell :?> PKRCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PKRCurrency.source + ".Name") 
                                               [| _PKRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PKRCurrency.cell
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
    [<ExcelFunction(Name="_PKRCurrency_numericCode", Description="Create a PKRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PKRCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PKRCurrency",Description = "Reference to PKRCurrency")>] 
         pkrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PKRCurrency = Helper.toCell<PKRCurrency> pkrcurrency "PKRCurrency" true 
                let builder () = withMnemonic mnemonic ((_PKRCurrency.cell :?> PKRCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_PKRCurrency.source + ".NumericCode") 
                                               [| _PKRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PKRCurrency.cell
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
    [<ExcelFunction(Name="_PKRCurrency_rounding", Description="Create a PKRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PKRCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PKRCurrency",Description = "Reference to PKRCurrency")>] 
         pkrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PKRCurrency = Helper.toCell<PKRCurrency> pkrcurrency "PKRCurrency" true 
                let builder () = withMnemonic mnemonic ((_PKRCurrency.cell :?> PKRCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_PKRCurrency.source + ".Rounding") 
                                               [| _PKRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PKRCurrency.cell
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
    [<ExcelFunction(Name="_PKRCurrency_symbol", Description="Create a PKRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PKRCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PKRCurrency",Description = "Reference to PKRCurrency")>] 
         pkrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PKRCurrency = Helper.toCell<PKRCurrency> pkrcurrency "PKRCurrency" true 
                let builder () = withMnemonic mnemonic ((_PKRCurrency.cell :?> PKRCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PKRCurrency.source + ".Symbol") 
                                               [| _PKRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PKRCurrency.cell
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
    [<ExcelFunction(Name="_PKRCurrency_ToString", Description="Create a PKRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PKRCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PKRCurrency",Description = "Reference to PKRCurrency")>] 
         pkrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PKRCurrency = Helper.toCell<PKRCurrency> pkrcurrency "PKRCurrency" true 
                let builder () = withMnemonic mnemonic ((_PKRCurrency.cell :?> PKRCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PKRCurrency.source + ".ToString") 
                                               [| _PKRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PKRCurrency.cell
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
    [<ExcelFunction(Name="_PKRCurrency_triangulationCurrency", Description="Create a PKRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PKRCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PKRCurrency",Description = "Reference to PKRCurrency")>] 
         pkrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PKRCurrency = Helper.toCell<PKRCurrency> pkrcurrency "PKRCurrency" true 
                let builder () = withMnemonic mnemonic ((_PKRCurrency.cell :?> PKRCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_PKRCurrency.source + ".TriangulationCurrency") 
                                               [| _PKRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PKRCurrency.cell
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
    [<ExcelFunction(Name="_PKRCurrency_Range", Description="Create a range of PKRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PKRCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the PKRCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PKRCurrency> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<PKRCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<PKRCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<PKRCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
