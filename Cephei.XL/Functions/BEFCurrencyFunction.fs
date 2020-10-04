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
module BEFCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BEFCurrency", Description="Create a BEFCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BEFCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.BEFCurrency 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BEFCurrency>) l

                let source = Helper.sourceFold "Fun.BEFCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BEFCurrency> format
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
    [<ExcelFunction(Name="_BEFCurrency_code", Description="Create a BEFCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BEFCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BEFCurrency",Description = "Reference to BEFCurrency")>] 
         befcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BEFCurrency = Helper.toCell<BEFCurrency> befcurrency "BEFCurrency"  
                let builder () = withMnemonic mnemonic ((BEFCurrencyModel.Cast _BEFCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BEFCurrency.source + ".Code") 
                                               [| _BEFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BEFCurrency.cell
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
    [<ExcelFunction(Name="_BEFCurrency_empty", Description="Create a BEFCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BEFCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BEFCurrency",Description = "Reference to BEFCurrency")>] 
         befcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BEFCurrency = Helper.toCell<BEFCurrency> befcurrency "BEFCurrency"  
                let builder () = withMnemonic mnemonic ((BEFCurrencyModel.Cast _BEFCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BEFCurrency.source + ".Empty") 
                                               [| _BEFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BEFCurrency.cell
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
    [<ExcelFunction(Name="_BEFCurrency_Equals", Description="Create a BEFCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BEFCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BEFCurrency",Description = "Reference to BEFCurrency")>] 
         befcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BEFCurrency = Helper.toCell<BEFCurrency> befcurrency "BEFCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((BEFCurrencyModel.Cast _BEFCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BEFCurrency.source + ".Equals") 
                                               [| _BEFCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BEFCurrency.cell
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
    [<ExcelFunction(Name="_BEFCurrency_format", Description="Create a BEFCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BEFCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BEFCurrency",Description = "Reference to BEFCurrency")>] 
         befcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BEFCurrency = Helper.toCell<BEFCurrency> befcurrency "BEFCurrency"  
                let builder () = withMnemonic mnemonic ((BEFCurrencyModel.Cast _BEFCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BEFCurrency.source + ".Format") 
                                               [| _BEFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BEFCurrency.cell
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
    [<ExcelFunction(Name="_BEFCurrency_fractionsPerUnit", Description="Create a BEFCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BEFCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BEFCurrency",Description = "Reference to BEFCurrency")>] 
         befcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BEFCurrency = Helper.toCell<BEFCurrency> befcurrency "BEFCurrency"  
                let builder () = withMnemonic mnemonic ((BEFCurrencyModel.Cast _BEFCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_BEFCurrency.source + ".FractionsPerUnit") 
                                               [| _BEFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BEFCurrency.cell
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
    [<ExcelFunction(Name="_BEFCurrency_fractionSymbol", Description="Create a BEFCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BEFCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BEFCurrency",Description = "Reference to BEFCurrency")>] 
         befcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BEFCurrency = Helper.toCell<BEFCurrency> befcurrency "BEFCurrency"  
                let builder () = withMnemonic mnemonic ((BEFCurrencyModel.Cast _BEFCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BEFCurrency.source + ".FractionSymbol") 
                                               [| _BEFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BEFCurrency.cell
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
    [<ExcelFunction(Name="_BEFCurrency_name", Description="Create a BEFCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BEFCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BEFCurrency",Description = "Reference to BEFCurrency")>] 
         befcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BEFCurrency = Helper.toCell<BEFCurrency> befcurrency "BEFCurrency"  
                let builder () = withMnemonic mnemonic ((BEFCurrencyModel.Cast _BEFCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BEFCurrency.source + ".Name") 
                                               [| _BEFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BEFCurrency.cell
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
    [<ExcelFunction(Name="_BEFCurrency_numericCode", Description="Create a BEFCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BEFCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BEFCurrency",Description = "Reference to BEFCurrency")>] 
         befcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BEFCurrency = Helper.toCell<BEFCurrency> befcurrency "BEFCurrency"  
                let builder () = withMnemonic mnemonic ((BEFCurrencyModel.Cast _BEFCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_BEFCurrency.source + ".NumericCode") 
                                               [| _BEFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BEFCurrency.cell
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
    [<ExcelFunction(Name="_BEFCurrency_rounding", Description="Create a BEFCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BEFCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BEFCurrency",Description = "Reference to BEFCurrency")>] 
         befcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BEFCurrency = Helper.toCell<BEFCurrency> befcurrency "BEFCurrency"  
                let builder () = withMnemonic mnemonic ((BEFCurrencyModel.Cast _BEFCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_BEFCurrency.source + ".Rounding") 
                                               [| _BEFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BEFCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BEFCurrency> format
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
    [<ExcelFunction(Name="_BEFCurrency_symbol", Description="Create a BEFCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BEFCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BEFCurrency",Description = "Reference to BEFCurrency")>] 
         befcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BEFCurrency = Helper.toCell<BEFCurrency> befcurrency "BEFCurrency"  
                let builder () = withMnemonic mnemonic ((BEFCurrencyModel.Cast _BEFCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BEFCurrency.source + ".Symbol") 
                                               [| _BEFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BEFCurrency.cell
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
    [<ExcelFunction(Name="_BEFCurrency_ToString", Description="Create a BEFCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BEFCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BEFCurrency",Description = "Reference to BEFCurrency")>] 
         befcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BEFCurrency = Helper.toCell<BEFCurrency> befcurrency "BEFCurrency"  
                let builder () = withMnemonic mnemonic ((BEFCurrencyModel.Cast _BEFCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BEFCurrency.source + ".ToString") 
                                               [| _BEFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BEFCurrency.cell
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
    [<ExcelFunction(Name="_BEFCurrency_triangulationCurrency", Description="Create a BEFCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BEFCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BEFCurrency",Description = "Reference to BEFCurrency")>] 
         befcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BEFCurrency = Helper.toCell<BEFCurrency> befcurrency "BEFCurrency"  
                let builder () = withMnemonic mnemonic ((BEFCurrencyModel.Cast _BEFCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_BEFCurrency.source + ".TriangulationCurrency") 
                                               [| _BEFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BEFCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BEFCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_BEFCurrency_Range", Description="Create a range of BEFCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BEFCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BEFCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BEFCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BEFCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BEFCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BEFCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
