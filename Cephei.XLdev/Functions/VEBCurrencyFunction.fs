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
  Venezuelan bolivar   The ISO three-letter code is VEB; the numeric code is 862. It is divided in 100 centimos.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module VEBCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_VEBCurrency", Description="Create a VEBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VEBCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.VEBCurrency 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VEBCurrency>) l

                let source = Helper.sourceFold "Fun.VEBCurrency" 
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
    [<ExcelFunction(Name="_VEBCurrency_code", Description="Create a VEBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VEBCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VEBCurrency",Description = "Reference to VEBCurrency")>] 
         vebcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VEBCurrency = Helper.toCell<VEBCurrency> vebcurrency "VEBCurrency" true 
                let builder () = withMnemonic mnemonic ((_VEBCurrency.cell :?> VEBCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_VEBCurrency.source + ".Code") 
                                               [| _VEBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VEBCurrency.cell
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
    [<ExcelFunction(Name="_VEBCurrency_empty", Description="Create a VEBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VEBCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VEBCurrency",Description = "Reference to VEBCurrency")>] 
         vebcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VEBCurrency = Helper.toCell<VEBCurrency> vebcurrency "VEBCurrency" true 
                let builder () = withMnemonic mnemonic ((_VEBCurrency.cell :?> VEBCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_VEBCurrency.source + ".Empty") 
                                               [| _VEBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VEBCurrency.cell
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
    [<ExcelFunction(Name="_VEBCurrency_Equals", Description="Create a VEBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VEBCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VEBCurrency",Description = "Reference to VEBCurrency")>] 
         vebcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VEBCurrency = Helper.toCell<VEBCurrency> vebcurrency "VEBCurrency" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_VEBCurrency.cell :?> VEBCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_VEBCurrency.source + ".Equals") 
                                               [| _VEBCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VEBCurrency.cell
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
    [<ExcelFunction(Name="_VEBCurrency_format", Description="Create a VEBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VEBCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VEBCurrency",Description = "Reference to VEBCurrency")>] 
         vebcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VEBCurrency = Helper.toCell<VEBCurrency> vebcurrency "VEBCurrency" true 
                let builder () = withMnemonic mnemonic ((_VEBCurrency.cell :?> VEBCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_VEBCurrency.source + ".Format") 
                                               [| _VEBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VEBCurrency.cell
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
    [<ExcelFunction(Name="_VEBCurrency_fractionsPerUnit", Description="Create a VEBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VEBCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VEBCurrency",Description = "Reference to VEBCurrency")>] 
         vebcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VEBCurrency = Helper.toCell<VEBCurrency> vebcurrency "VEBCurrency" true 
                let builder () = withMnemonic mnemonic ((_VEBCurrency.cell :?> VEBCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_VEBCurrency.source + ".FractionsPerUnit") 
                                               [| _VEBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VEBCurrency.cell
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
    [<ExcelFunction(Name="_VEBCurrency_fractionSymbol", Description="Create a VEBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VEBCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VEBCurrency",Description = "Reference to VEBCurrency")>] 
         vebcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VEBCurrency = Helper.toCell<VEBCurrency> vebcurrency "VEBCurrency" true 
                let builder () = withMnemonic mnemonic ((_VEBCurrency.cell :?> VEBCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_VEBCurrency.source + ".FractionSymbol") 
                                               [| _VEBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VEBCurrency.cell
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
    [<ExcelFunction(Name="_VEBCurrency_name", Description="Create a VEBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VEBCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VEBCurrency",Description = "Reference to VEBCurrency")>] 
         vebcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VEBCurrency = Helper.toCell<VEBCurrency> vebcurrency "VEBCurrency" true 
                let builder () = withMnemonic mnemonic ((_VEBCurrency.cell :?> VEBCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_VEBCurrency.source + ".Name") 
                                               [| _VEBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VEBCurrency.cell
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
    [<ExcelFunction(Name="_VEBCurrency_numericCode", Description="Create a VEBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VEBCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VEBCurrency",Description = "Reference to VEBCurrency")>] 
         vebcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VEBCurrency = Helper.toCell<VEBCurrency> vebcurrency "VEBCurrency" true 
                let builder () = withMnemonic mnemonic ((_VEBCurrency.cell :?> VEBCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_VEBCurrency.source + ".NumericCode") 
                                               [| _VEBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VEBCurrency.cell
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
    [<ExcelFunction(Name="_VEBCurrency_rounding", Description="Create a VEBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VEBCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VEBCurrency",Description = "Reference to VEBCurrency")>] 
         vebcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VEBCurrency = Helper.toCell<VEBCurrency> vebcurrency "VEBCurrency" true 
                let builder () = withMnemonic mnemonic ((_VEBCurrency.cell :?> VEBCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_VEBCurrency.source + ".Rounding") 
                                               [| _VEBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VEBCurrency.cell
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
    [<ExcelFunction(Name="_VEBCurrency_symbol", Description="Create a VEBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VEBCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VEBCurrency",Description = "Reference to VEBCurrency")>] 
         vebcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VEBCurrency = Helper.toCell<VEBCurrency> vebcurrency "VEBCurrency" true 
                let builder () = withMnemonic mnemonic ((_VEBCurrency.cell :?> VEBCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_VEBCurrency.source + ".Symbol") 
                                               [| _VEBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VEBCurrency.cell
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
    [<ExcelFunction(Name="_VEBCurrency_ToString", Description="Create a VEBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VEBCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VEBCurrency",Description = "Reference to VEBCurrency")>] 
         vebcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VEBCurrency = Helper.toCell<VEBCurrency> vebcurrency "VEBCurrency" true 
                let builder () = withMnemonic mnemonic ((_VEBCurrency.cell :?> VEBCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_VEBCurrency.source + ".ToString") 
                                               [| _VEBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VEBCurrency.cell
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
    [<ExcelFunction(Name="_VEBCurrency_triangulationCurrency", Description="Create a VEBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VEBCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VEBCurrency",Description = "Reference to VEBCurrency")>] 
         vebcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VEBCurrency = Helper.toCell<VEBCurrency> vebcurrency "VEBCurrency" true 
                let builder () = withMnemonic mnemonic ((_VEBCurrency.cell :?> VEBCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_VEBCurrency.source + ".TriangulationCurrency") 
                                               [| _VEBCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VEBCurrency.cell
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
    [<ExcelFunction(Name="_VEBCurrency_Range", Description="Create a range of VEBCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VEBCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the VEBCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<VEBCurrency> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<VEBCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<VEBCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<VEBCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
