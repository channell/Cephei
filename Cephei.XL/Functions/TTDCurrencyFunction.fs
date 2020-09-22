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
  Trinidad & Tobago dollar   The ISO three-letter code is TTD; the numeric code is 780. It is divided in 100 cents.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module TTDCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_TTDCurrency", Description="Create a TTDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TTDCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.TTDCurrency 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TTDCurrency>) l

                let source = Helper.sourceFold "Fun.TTDCurrency" 
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
    [<ExcelFunction(Name="_TTDCurrency_code", Description="Create a TTDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TTDCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TTDCurrency",Description = "Reference to TTDCurrency")>] 
         ttdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TTDCurrency = Helper.toCell<TTDCurrency> ttdcurrency "TTDCurrency" true 
                let builder () = withMnemonic mnemonic ((_TTDCurrency.cell :?> TTDCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TTDCurrency.source + ".Code") 
                                               [| _TTDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TTDCurrency.cell
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
    [<ExcelFunction(Name="_TTDCurrency_empty", Description="Create a TTDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TTDCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TTDCurrency",Description = "Reference to TTDCurrency")>] 
         ttdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TTDCurrency = Helper.toCell<TTDCurrency> ttdcurrency "TTDCurrency" true 
                let builder () = withMnemonic mnemonic ((_TTDCurrency.cell :?> TTDCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TTDCurrency.source + ".Empty") 
                                               [| _TTDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TTDCurrency.cell
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
    [<ExcelFunction(Name="_TTDCurrency_Equals", Description="Create a TTDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TTDCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TTDCurrency",Description = "Reference to TTDCurrency")>] 
         ttdcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TTDCurrency = Helper.toCell<TTDCurrency> ttdcurrency "TTDCurrency" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_TTDCurrency.cell :?> TTDCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TTDCurrency.source + ".Equals") 
                                               [| _TTDCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TTDCurrency.cell
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
    [<ExcelFunction(Name="_TTDCurrency_format", Description="Create a TTDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TTDCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TTDCurrency",Description = "Reference to TTDCurrency")>] 
         ttdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TTDCurrency = Helper.toCell<TTDCurrency> ttdcurrency "TTDCurrency" true 
                let builder () = withMnemonic mnemonic ((_TTDCurrency.cell :?> TTDCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TTDCurrency.source + ".Format") 
                                               [| _TTDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TTDCurrency.cell
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
    [<ExcelFunction(Name="_TTDCurrency_fractionsPerUnit", Description="Create a TTDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TTDCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TTDCurrency",Description = "Reference to TTDCurrency")>] 
         ttdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TTDCurrency = Helper.toCell<TTDCurrency> ttdcurrency "TTDCurrency" true 
                let builder () = withMnemonic mnemonic ((_TTDCurrency.cell :?> TTDCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_TTDCurrency.source + ".FractionsPerUnit") 
                                               [| _TTDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TTDCurrency.cell
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
    [<ExcelFunction(Name="_TTDCurrency_fractionSymbol", Description="Create a TTDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TTDCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TTDCurrency",Description = "Reference to TTDCurrency")>] 
         ttdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TTDCurrency = Helper.toCell<TTDCurrency> ttdcurrency "TTDCurrency" true 
                let builder () = withMnemonic mnemonic ((_TTDCurrency.cell :?> TTDCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TTDCurrency.source + ".FractionSymbol") 
                                               [| _TTDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TTDCurrency.cell
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
    [<ExcelFunction(Name="_TTDCurrency_name", Description="Create a TTDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TTDCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TTDCurrency",Description = "Reference to TTDCurrency")>] 
         ttdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TTDCurrency = Helper.toCell<TTDCurrency> ttdcurrency "TTDCurrency" true 
                let builder () = withMnemonic mnemonic ((_TTDCurrency.cell :?> TTDCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TTDCurrency.source + ".Name") 
                                               [| _TTDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TTDCurrency.cell
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
    [<ExcelFunction(Name="_TTDCurrency_numericCode", Description="Create a TTDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TTDCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TTDCurrency",Description = "Reference to TTDCurrency")>] 
         ttdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TTDCurrency = Helper.toCell<TTDCurrency> ttdcurrency "TTDCurrency" true 
                let builder () = withMnemonic mnemonic ((_TTDCurrency.cell :?> TTDCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_TTDCurrency.source + ".NumericCode") 
                                               [| _TTDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TTDCurrency.cell
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
    [<ExcelFunction(Name="_TTDCurrency_rounding", Description="Create a TTDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TTDCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TTDCurrency",Description = "Reference to TTDCurrency")>] 
         ttdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TTDCurrency = Helper.toCell<TTDCurrency> ttdcurrency "TTDCurrency" true 
                let builder () = withMnemonic mnemonic ((_TTDCurrency.cell :?> TTDCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_TTDCurrency.source + ".Rounding") 
                                               [| _TTDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TTDCurrency.cell
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
    [<ExcelFunction(Name="_TTDCurrency_symbol", Description="Create a TTDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TTDCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TTDCurrency",Description = "Reference to TTDCurrency")>] 
         ttdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TTDCurrency = Helper.toCell<TTDCurrency> ttdcurrency "TTDCurrency" true 
                let builder () = withMnemonic mnemonic ((_TTDCurrency.cell :?> TTDCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TTDCurrency.source + ".Symbol") 
                                               [| _TTDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TTDCurrency.cell
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
    [<ExcelFunction(Name="_TTDCurrency_ToString", Description="Create a TTDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TTDCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TTDCurrency",Description = "Reference to TTDCurrency")>] 
         ttdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TTDCurrency = Helper.toCell<TTDCurrency> ttdcurrency "TTDCurrency" true 
                let builder () = withMnemonic mnemonic ((_TTDCurrency.cell :?> TTDCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TTDCurrency.source + ".ToString") 
                                               [| _TTDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TTDCurrency.cell
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
    [<ExcelFunction(Name="_TTDCurrency_triangulationCurrency", Description="Create a TTDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TTDCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TTDCurrency",Description = "Reference to TTDCurrency")>] 
         ttdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TTDCurrency = Helper.toCell<TTDCurrency> ttdcurrency "TTDCurrency" true 
                let builder () = withMnemonic mnemonic ((_TTDCurrency.cell :?> TTDCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_TTDCurrency.source + ".TriangulationCurrency") 
                                               [| _TTDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TTDCurrency.cell
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
    [<ExcelFunction(Name="_TTDCurrency_Range", Description="Create a range of TTDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TTDCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the TTDCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TTDCurrency> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<TTDCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<TTDCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<TTDCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
