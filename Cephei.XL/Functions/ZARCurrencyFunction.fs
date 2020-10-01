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
module ZARCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ZARCurrency", Description="Create a ZARCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZARCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.ZARCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ZARCurrency>) l

                let source = Helper.sourceFold "Fun.ZARCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ZARCurrency> format
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
    [<ExcelFunction(Name="_ZARCurrency_code", Description="Create a ZARCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZARCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZARCurrency",Description = "Reference to ZARCurrency")>] 
         zarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZARCurrency = Helper.toCell<ZARCurrency> zarcurrency "ZARCurrency"  
                let builder () = withMnemonic mnemonic ((_ZARCurrency.cell :?> ZARCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZARCurrency.source + ".Code") 
                                               [| _ZARCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZARCurrency.cell
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
    [<ExcelFunction(Name="_ZARCurrency_empty", Description="Create a ZARCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZARCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZARCurrency",Description = "Reference to ZARCurrency")>] 
         zarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZARCurrency = Helper.toCell<ZARCurrency> zarcurrency "ZARCurrency"  
                let builder () = withMnemonic mnemonic ((_ZARCurrency.cell :?> ZARCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZARCurrency.source + ".Empty") 
                                               [| _ZARCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZARCurrency.cell
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
    [<ExcelFunction(Name="_ZARCurrency_Equals", Description="Create a ZARCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZARCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZARCurrency",Description = "Reference to ZARCurrency")>] 
         zarcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZARCurrency = Helper.toCell<ZARCurrency> zarcurrency "ZARCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((_ZARCurrency.cell :?> ZARCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZARCurrency.source + ".Equals") 
                                               [| _ZARCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZARCurrency.cell
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
    [<ExcelFunction(Name="_ZARCurrency_format", Description="Create a ZARCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZARCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZARCurrency",Description = "Reference to ZARCurrency")>] 
         zarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZARCurrency = Helper.toCell<ZARCurrency> zarcurrency "ZARCurrency"  
                let builder () = withMnemonic mnemonic ((_ZARCurrency.cell :?> ZARCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZARCurrency.source + ".Format") 
                                               [| _ZARCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZARCurrency.cell
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
    [<ExcelFunction(Name="_ZARCurrency_fractionsPerUnit", Description="Create a ZARCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZARCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZARCurrency",Description = "Reference to ZARCurrency")>] 
         zarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZARCurrency = Helper.toCell<ZARCurrency> zarcurrency "ZARCurrency"  
                let builder () = withMnemonic mnemonic ((_ZARCurrency.cell :?> ZARCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZARCurrency.source + ".FractionsPerUnit") 
                                               [| _ZARCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZARCurrency.cell
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
    [<ExcelFunction(Name="_ZARCurrency_fractionSymbol", Description="Create a ZARCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZARCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZARCurrency",Description = "Reference to ZARCurrency")>] 
         zarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZARCurrency = Helper.toCell<ZARCurrency> zarcurrency "ZARCurrency"  
                let builder () = withMnemonic mnemonic ((_ZARCurrency.cell :?> ZARCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZARCurrency.source + ".FractionSymbol") 
                                               [| _ZARCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZARCurrency.cell
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
    [<ExcelFunction(Name="_ZARCurrency_name", Description="Create a ZARCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZARCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZARCurrency",Description = "Reference to ZARCurrency")>] 
         zarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZARCurrency = Helper.toCell<ZARCurrency> zarcurrency "ZARCurrency"  
                let builder () = withMnemonic mnemonic ((_ZARCurrency.cell :?> ZARCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZARCurrency.source + ".Name") 
                                               [| _ZARCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZARCurrency.cell
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
    [<ExcelFunction(Name="_ZARCurrency_numericCode", Description="Create a ZARCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZARCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZARCurrency",Description = "Reference to ZARCurrency")>] 
         zarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZARCurrency = Helper.toCell<ZARCurrency> zarcurrency "ZARCurrency"  
                let builder () = withMnemonic mnemonic ((_ZARCurrency.cell :?> ZARCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZARCurrency.source + ".NumericCode") 
                                               [| _ZARCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZARCurrency.cell
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
    [<ExcelFunction(Name="_ZARCurrency_rounding", Description="Create a ZARCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZARCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZARCurrency",Description = "Reference to ZARCurrency")>] 
         zarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZARCurrency = Helper.toCell<ZARCurrency> zarcurrency "ZARCurrency"  
                let builder () = withMnemonic mnemonic ((_ZARCurrency.cell :?> ZARCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_ZARCurrency.source + ".Rounding") 
                                               [| _ZARCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZARCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ZARCurrency> format
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
    [<ExcelFunction(Name="_ZARCurrency_symbol", Description="Create a ZARCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZARCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZARCurrency",Description = "Reference to ZARCurrency")>] 
         zarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZARCurrency = Helper.toCell<ZARCurrency> zarcurrency "ZARCurrency"  
                let builder () = withMnemonic mnemonic ((_ZARCurrency.cell :?> ZARCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZARCurrency.source + ".Symbol") 
                                               [| _ZARCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZARCurrency.cell
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
    [<ExcelFunction(Name="_ZARCurrency_ToString", Description="Create a ZARCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZARCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZARCurrency",Description = "Reference to ZARCurrency")>] 
         zarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZARCurrency = Helper.toCell<ZARCurrency> zarcurrency "ZARCurrency"  
                let builder () = withMnemonic mnemonic ((_ZARCurrency.cell :?> ZARCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZARCurrency.source + ".ToString") 
                                               [| _ZARCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZARCurrency.cell
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
    [<ExcelFunction(Name="_ZARCurrency_triangulationCurrency", Description="Create a ZARCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZARCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZARCurrency",Description = "Reference to ZARCurrency")>] 
         zarcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZARCurrency = Helper.toCell<ZARCurrency> zarcurrency "ZARCurrency"  
                let builder () = withMnemonic mnemonic ((_ZARCurrency.cell :?> ZARCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_ZARCurrency.source + ".TriangulationCurrency") 
                                               [| _ZARCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZARCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ZARCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_ZARCurrency_Range", Description="Create a range of ZARCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZARCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ZARCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ZARCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ZARCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ZARCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ZARCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
