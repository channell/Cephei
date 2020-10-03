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
  The ISO three-letter code is KWD; the numeric code is 414. It is divided in 1000 fils.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module KWDCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_KWDCurrency", Description="Create a KWDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KWDCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.KWDCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<KWDCurrency>) l

                let source = Helper.sourceFold "Fun.KWDCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<KWDCurrency> format
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
    [<ExcelFunction(Name="_KWDCurrency_code", Description="Create a KWDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KWDCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KWDCurrency",Description = "Reference to KWDCurrency")>] 
         kwdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KWDCurrency = Helper.toCell<KWDCurrency> kwdcurrency "KWDCurrency"  
                let builder () = withMnemonic mnemonic ((_KWDCurrency.cell :?> KWDCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_KWDCurrency.source + ".Code") 
                                               [| _KWDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KWDCurrency.cell
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
    [<ExcelFunction(Name="_KWDCurrency_empty", Description="Create a KWDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KWDCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KWDCurrency",Description = "Reference to KWDCurrency")>] 
         kwdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KWDCurrency = Helper.toCell<KWDCurrency> kwdcurrency "KWDCurrency"  
                let builder () = withMnemonic mnemonic ((_KWDCurrency.cell :?> KWDCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_KWDCurrency.source + ".Empty") 
                                               [| _KWDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KWDCurrency.cell
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
    [<ExcelFunction(Name="_KWDCurrency_Equals", Description="Create a KWDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KWDCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KWDCurrency",Description = "Reference to KWDCurrency")>] 
         kwdcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KWDCurrency = Helper.toCell<KWDCurrency> kwdcurrency "KWDCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((_KWDCurrency.cell :?> KWDCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_KWDCurrency.source + ".Equals") 
                                               [| _KWDCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KWDCurrency.cell
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
    [<ExcelFunction(Name="_KWDCurrency_format", Description="Create a KWDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KWDCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KWDCurrency",Description = "Reference to KWDCurrency")>] 
         kwdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KWDCurrency = Helper.toCell<KWDCurrency> kwdcurrency "KWDCurrency"  
                let builder () = withMnemonic mnemonic ((_KWDCurrency.cell :?> KWDCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_KWDCurrency.source + ".Format") 
                                               [| _KWDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KWDCurrency.cell
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
    [<ExcelFunction(Name="_KWDCurrency_fractionsPerUnit", Description="Create a KWDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KWDCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KWDCurrency",Description = "Reference to KWDCurrency")>] 
         kwdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KWDCurrency = Helper.toCell<KWDCurrency> kwdcurrency "KWDCurrency"  
                let builder () = withMnemonic mnemonic ((_KWDCurrency.cell :?> KWDCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_KWDCurrency.source + ".FractionsPerUnit") 
                                               [| _KWDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KWDCurrency.cell
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
    [<ExcelFunction(Name="_KWDCurrency_fractionSymbol", Description="Create a KWDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KWDCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KWDCurrency",Description = "Reference to KWDCurrency")>] 
         kwdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KWDCurrency = Helper.toCell<KWDCurrency> kwdcurrency "KWDCurrency"  
                let builder () = withMnemonic mnemonic ((_KWDCurrency.cell :?> KWDCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_KWDCurrency.source + ".FractionSymbol") 
                                               [| _KWDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KWDCurrency.cell
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
    [<ExcelFunction(Name="_KWDCurrency_name", Description="Create a KWDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KWDCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KWDCurrency",Description = "Reference to KWDCurrency")>] 
         kwdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KWDCurrency = Helper.toCell<KWDCurrency> kwdcurrency "KWDCurrency"  
                let builder () = withMnemonic mnemonic ((_KWDCurrency.cell :?> KWDCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_KWDCurrency.source + ".Name") 
                                               [| _KWDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KWDCurrency.cell
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
    [<ExcelFunction(Name="_KWDCurrency_numericCode", Description="Create a KWDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KWDCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KWDCurrency",Description = "Reference to KWDCurrency")>] 
         kwdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KWDCurrency = Helper.toCell<KWDCurrency> kwdcurrency "KWDCurrency"  
                let builder () = withMnemonic mnemonic ((_KWDCurrency.cell :?> KWDCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_KWDCurrency.source + ".NumericCode") 
                                               [| _KWDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KWDCurrency.cell
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
    [<ExcelFunction(Name="_KWDCurrency_rounding", Description="Create a KWDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KWDCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KWDCurrency",Description = "Reference to KWDCurrency")>] 
         kwdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KWDCurrency = Helper.toCell<KWDCurrency> kwdcurrency "KWDCurrency"  
                let builder () = withMnemonic mnemonic ((_KWDCurrency.cell :?> KWDCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_KWDCurrency.source + ".Rounding") 
                                               [| _KWDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KWDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<KWDCurrency> format
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
    [<ExcelFunction(Name="_KWDCurrency_symbol", Description="Create a KWDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KWDCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KWDCurrency",Description = "Reference to KWDCurrency")>] 
         kwdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KWDCurrency = Helper.toCell<KWDCurrency> kwdcurrency "KWDCurrency"  
                let builder () = withMnemonic mnemonic ((_KWDCurrency.cell :?> KWDCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_KWDCurrency.source + ".Symbol") 
                                               [| _KWDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KWDCurrency.cell
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
    [<ExcelFunction(Name="_KWDCurrency_ToString", Description="Create a KWDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KWDCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KWDCurrency",Description = "Reference to KWDCurrency")>] 
         kwdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KWDCurrency = Helper.toCell<KWDCurrency> kwdcurrency "KWDCurrency"  
                let builder () = withMnemonic mnemonic ((_KWDCurrency.cell :?> KWDCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_KWDCurrency.source + ".ToString") 
                                               [| _KWDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KWDCurrency.cell
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
    [<ExcelFunction(Name="_KWDCurrency_triangulationCurrency", Description="Create a KWDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KWDCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KWDCurrency",Description = "Reference to KWDCurrency")>] 
         kwdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KWDCurrency = Helper.toCell<KWDCurrency> kwdcurrency "KWDCurrency"  
                let builder () = withMnemonic mnemonic ((_KWDCurrency.cell :?> KWDCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_KWDCurrency.source + ".TriangulationCurrency") 
                                               [| _KWDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KWDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<KWDCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_KWDCurrency_Range", Description="Create a range of KWDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let KWDCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the KWDCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<KWDCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<KWDCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<KWDCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<KWDCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"