﻿(*
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
  The ISO three-letter code is HKD; the numeric code is 344. It is divided in 100 cents.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module HKDCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_HKDCurrency", Description="Create a HKDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HKDCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.HKDCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<HKDCurrency>) l

                let source = Helper.sourceFold "Fun.HKDCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HKDCurrency> format
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
    [<ExcelFunction(Name="_HKDCurrency_code", Description="Create a HKDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HKDCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HKDCurrency",Description = "Reference to HKDCurrency")>] 
         hkdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HKDCurrency = Helper.toCell<HKDCurrency> hkdcurrency "HKDCurrency"  
                let builder () = withMnemonic mnemonic ((_HKDCurrency.cell :?> HKDCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HKDCurrency.source + ".Code") 
                                               [| _HKDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HKDCurrency.cell
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
    [<ExcelFunction(Name="_HKDCurrency_empty", Description="Create a HKDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HKDCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HKDCurrency",Description = "Reference to HKDCurrency")>] 
         hkdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HKDCurrency = Helper.toCell<HKDCurrency> hkdcurrency "HKDCurrency"  
                let builder () = withMnemonic mnemonic ((_HKDCurrency.cell :?> HKDCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HKDCurrency.source + ".Empty") 
                                               [| _HKDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HKDCurrency.cell
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
    [<ExcelFunction(Name="_HKDCurrency_Equals", Description="Create a HKDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HKDCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HKDCurrency",Description = "Reference to HKDCurrency")>] 
         hkdcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HKDCurrency = Helper.toCell<HKDCurrency> hkdcurrency "HKDCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((_HKDCurrency.cell :?> HKDCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HKDCurrency.source + ".Equals") 
                                               [| _HKDCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HKDCurrency.cell
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
    [<ExcelFunction(Name="_HKDCurrency_format", Description="Create a HKDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HKDCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HKDCurrency",Description = "Reference to HKDCurrency")>] 
         hkdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HKDCurrency = Helper.toCell<HKDCurrency> hkdcurrency "HKDCurrency"  
                let builder () = withMnemonic mnemonic ((_HKDCurrency.cell :?> HKDCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HKDCurrency.source + ".Format") 
                                               [| _HKDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HKDCurrency.cell
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
    [<ExcelFunction(Name="_HKDCurrency_fractionsPerUnit", Description="Create a HKDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HKDCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HKDCurrency",Description = "Reference to HKDCurrency")>] 
         hkdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HKDCurrency = Helper.toCell<HKDCurrency> hkdcurrency "HKDCurrency"  
                let builder () = withMnemonic mnemonic ((_HKDCurrency.cell :?> HKDCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_HKDCurrency.source + ".FractionsPerUnit") 
                                               [| _HKDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HKDCurrency.cell
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
    [<ExcelFunction(Name="_HKDCurrency_fractionSymbol", Description="Create a HKDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HKDCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HKDCurrency",Description = "Reference to HKDCurrency")>] 
         hkdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HKDCurrency = Helper.toCell<HKDCurrency> hkdcurrency "HKDCurrency"  
                let builder () = withMnemonic mnemonic ((_HKDCurrency.cell :?> HKDCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HKDCurrency.source + ".FractionSymbol") 
                                               [| _HKDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HKDCurrency.cell
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
    [<ExcelFunction(Name="_HKDCurrency_name", Description="Create a HKDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HKDCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HKDCurrency",Description = "Reference to HKDCurrency")>] 
         hkdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HKDCurrency = Helper.toCell<HKDCurrency> hkdcurrency "HKDCurrency"  
                let builder () = withMnemonic mnemonic ((_HKDCurrency.cell :?> HKDCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HKDCurrency.source + ".Name") 
                                               [| _HKDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HKDCurrency.cell
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
    [<ExcelFunction(Name="_HKDCurrency_numericCode", Description="Create a HKDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HKDCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HKDCurrency",Description = "Reference to HKDCurrency")>] 
         hkdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HKDCurrency = Helper.toCell<HKDCurrency> hkdcurrency "HKDCurrency"  
                let builder () = withMnemonic mnemonic ((_HKDCurrency.cell :?> HKDCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_HKDCurrency.source + ".NumericCode") 
                                               [| _HKDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HKDCurrency.cell
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
    [<ExcelFunction(Name="_HKDCurrency_rounding", Description="Create a HKDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HKDCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HKDCurrency",Description = "Reference to HKDCurrency")>] 
         hkdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HKDCurrency = Helper.toCell<HKDCurrency> hkdcurrency "HKDCurrency"  
                let builder () = withMnemonic mnemonic ((_HKDCurrency.cell :?> HKDCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_HKDCurrency.source + ".Rounding") 
                                               [| _HKDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HKDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HKDCurrency> format
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
    [<ExcelFunction(Name="_HKDCurrency_symbol", Description="Create a HKDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HKDCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HKDCurrency",Description = "Reference to HKDCurrency")>] 
         hkdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HKDCurrency = Helper.toCell<HKDCurrency> hkdcurrency "HKDCurrency"  
                let builder () = withMnemonic mnemonic ((_HKDCurrency.cell :?> HKDCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HKDCurrency.source + ".Symbol") 
                                               [| _HKDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HKDCurrency.cell
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
    [<ExcelFunction(Name="_HKDCurrency_ToString", Description="Create a HKDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HKDCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HKDCurrency",Description = "Reference to HKDCurrency")>] 
         hkdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HKDCurrency = Helper.toCell<HKDCurrency> hkdcurrency "HKDCurrency"  
                let builder () = withMnemonic mnemonic ((_HKDCurrency.cell :?> HKDCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HKDCurrency.source + ".ToString") 
                                               [| _HKDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HKDCurrency.cell
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
    [<ExcelFunction(Name="_HKDCurrency_triangulationCurrency", Description="Create a HKDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HKDCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HKDCurrency",Description = "Reference to HKDCurrency")>] 
         hkdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HKDCurrency = Helper.toCell<HKDCurrency> hkdcurrency "HKDCurrency"  
                let builder () = withMnemonic mnemonic ((_HKDCurrency.cell :?> HKDCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_HKDCurrency.source + ".TriangulationCurrency") 
                                               [| _HKDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HKDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HKDCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_HKDCurrency_Range", Description="Create a range of HKDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HKDCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the HKDCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<HKDCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<HKDCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<HKDCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<HKDCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"