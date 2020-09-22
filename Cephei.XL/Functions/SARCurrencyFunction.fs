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
  The ISO three-letter code is SAR; the numeric code is 682. It is divided in 100 halalat.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module SARCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SARCurrency", Description="Create a SARCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SARCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.SARCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SARCurrency>) l

                let source = Helper.sourceFold "Fun.SARCurrency" 
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
    [<ExcelFunction(Name="_SARCurrency_code", Description="Create a SARCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SARCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SARCurrency",Description = "Reference to SARCurrency")>] 
         sarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SARCurrency = Helper.toCell<SARCurrency> sarcurrency "SARCurrency" true 
                let builder () = withMnemonic mnemonic ((_SARCurrency.cell :?> SARCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SARCurrency.source + ".Code") 
                                               [| _SARCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SARCurrency.cell
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
    [<ExcelFunction(Name="_SARCurrency_empty", Description="Create a SARCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SARCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SARCurrency",Description = "Reference to SARCurrency")>] 
         sarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SARCurrency = Helper.toCell<SARCurrency> sarcurrency "SARCurrency" true 
                let builder () = withMnemonic mnemonic ((_SARCurrency.cell :?> SARCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SARCurrency.source + ".Empty") 
                                               [| _SARCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SARCurrency.cell
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
    [<ExcelFunction(Name="_SARCurrency_Equals", Description="Create a SARCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SARCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SARCurrency",Description = "Reference to SARCurrency")>] 
         sarcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SARCurrency = Helper.toCell<SARCurrency> sarcurrency "SARCurrency" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_SARCurrency.cell :?> SARCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SARCurrency.source + ".Equals") 
                                               [| _SARCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SARCurrency.cell
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
    [<ExcelFunction(Name="_SARCurrency_format", Description="Create a SARCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SARCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SARCurrency",Description = "Reference to SARCurrency")>] 
         sarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SARCurrency = Helper.toCell<SARCurrency> sarcurrency "SARCurrency" true 
                let builder () = withMnemonic mnemonic ((_SARCurrency.cell :?> SARCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SARCurrency.source + ".Format") 
                                               [| _SARCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SARCurrency.cell
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
    [<ExcelFunction(Name="_SARCurrency_fractionsPerUnit", Description="Create a SARCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SARCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SARCurrency",Description = "Reference to SARCurrency")>] 
         sarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SARCurrency = Helper.toCell<SARCurrency> sarcurrency "SARCurrency" true 
                let builder () = withMnemonic mnemonic ((_SARCurrency.cell :?> SARCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SARCurrency.source + ".FractionsPerUnit") 
                                               [| _SARCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SARCurrency.cell
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
    [<ExcelFunction(Name="_SARCurrency_fractionSymbol", Description="Create a SARCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SARCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SARCurrency",Description = "Reference to SARCurrency")>] 
         sarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SARCurrency = Helper.toCell<SARCurrency> sarcurrency "SARCurrency" true 
                let builder () = withMnemonic mnemonic ((_SARCurrency.cell :?> SARCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SARCurrency.source + ".FractionSymbol") 
                                               [| _SARCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SARCurrency.cell
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
    [<ExcelFunction(Name="_SARCurrency_name", Description="Create a SARCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SARCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SARCurrency",Description = "Reference to SARCurrency")>] 
         sarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SARCurrency = Helper.toCell<SARCurrency> sarcurrency "SARCurrency" true 
                let builder () = withMnemonic mnemonic ((_SARCurrency.cell :?> SARCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SARCurrency.source + ".Name") 
                                               [| _SARCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SARCurrency.cell
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
    [<ExcelFunction(Name="_SARCurrency_numericCode", Description="Create a SARCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SARCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SARCurrency",Description = "Reference to SARCurrency")>] 
         sarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SARCurrency = Helper.toCell<SARCurrency> sarcurrency "SARCurrency" true 
                let builder () = withMnemonic mnemonic ((_SARCurrency.cell :?> SARCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SARCurrency.source + ".NumericCode") 
                                               [| _SARCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SARCurrency.cell
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
    [<ExcelFunction(Name="_SARCurrency_rounding", Description="Create a SARCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SARCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SARCurrency",Description = "Reference to SARCurrency")>] 
         sarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SARCurrency = Helper.toCell<SARCurrency> sarcurrency "SARCurrency" true 
                let builder () = withMnemonic mnemonic ((_SARCurrency.cell :?> SARCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_SARCurrency.source + ".Rounding") 
                                               [| _SARCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SARCurrency.cell
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
    [<ExcelFunction(Name="_SARCurrency_symbol", Description="Create a SARCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SARCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SARCurrency",Description = "Reference to SARCurrency")>] 
         sarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SARCurrency = Helper.toCell<SARCurrency> sarcurrency "SARCurrency" true 
                let builder () = withMnemonic mnemonic ((_SARCurrency.cell :?> SARCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SARCurrency.source + ".Symbol") 
                                               [| _SARCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SARCurrency.cell
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
    [<ExcelFunction(Name="_SARCurrency_ToString", Description="Create a SARCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SARCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SARCurrency",Description = "Reference to SARCurrency")>] 
         sarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SARCurrency = Helper.toCell<SARCurrency> sarcurrency "SARCurrency" true 
                let builder () = withMnemonic mnemonic ((_SARCurrency.cell :?> SARCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SARCurrency.source + ".ToString") 
                                               [| _SARCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SARCurrency.cell
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
    [<ExcelFunction(Name="_SARCurrency_triangulationCurrency", Description="Create a SARCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SARCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SARCurrency",Description = "Reference to SARCurrency")>] 
         sarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SARCurrency = Helper.toCell<SARCurrency> sarcurrency "SARCurrency" true 
                let builder () = withMnemonic mnemonic ((_SARCurrency.cell :?> SARCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_SARCurrency.source + ".TriangulationCurrency") 
                                               [| _SARCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SARCurrency.cell
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
    [<ExcelFunction(Name="_SARCurrency_Range", Description="Create a range of SARCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SARCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SARCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SARCurrency> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SARCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SARCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SARCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
