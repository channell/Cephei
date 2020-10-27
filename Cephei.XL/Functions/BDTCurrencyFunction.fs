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
  The ISO three-letter code is BDT; the numeric code is 50. It is divided in 100 paisa. currencies
  </summary> *)
[<AutoSerializable(true)>]
module BDTCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BDTCurrency", Description="Create a BDTCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BDTCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.BDTCurrency 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BDTCurrency>) l

                let source () = Helper.sourceFold "Fun.BDTCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BDTCurrency> format
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
    [<ExcelFunction(Name="_BDTCurrency_code", Description="Create a BDTCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BDTCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BDTCurrency",Description = "BDTCurrency")>] 
         bdtcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BDTCurrency = Helper.toCell<BDTCurrency> bdtcurrency "BDTCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((BDTCurrencyModel.Cast _BDTCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BDTCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BDTCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_BDTCurrency_empty", Description="Create a BDTCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BDTCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BDTCurrency",Description = "BDTCurrency")>] 
         bdtcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BDTCurrency = Helper.toCell<BDTCurrency> bdtcurrency "BDTCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((BDTCurrencyModel.Cast _BDTCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BDTCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BDTCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_BDTCurrency_Equals", Description="Create a BDTCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BDTCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BDTCurrency",Description = "BDTCurrency")>] 
         bdtcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BDTCurrency = Helper.toCell<BDTCurrency> bdtcurrency "BDTCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((BDTCurrencyModel.Cast _BDTCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BDTCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BDTCurrency.cell
                                ;  _o.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_BDTCurrency_format", Description="Create a BDTCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BDTCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BDTCurrency",Description = "BDTCurrency")>] 
         bdtcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BDTCurrency = Helper.toCell<BDTCurrency> bdtcurrency "BDTCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((BDTCurrencyModel.Cast _BDTCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BDTCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BDTCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_BDTCurrency_fractionsPerUnit", Description="Create a BDTCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BDTCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BDTCurrency",Description = "BDTCurrency")>] 
         bdtcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BDTCurrency = Helper.toCell<BDTCurrency> bdtcurrency "BDTCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((BDTCurrencyModel.Cast _BDTCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BDTCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BDTCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_BDTCurrency_fractionSymbol", Description="Create a BDTCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BDTCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BDTCurrency",Description = "BDTCurrency")>] 
         bdtcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BDTCurrency = Helper.toCell<BDTCurrency> bdtcurrency "BDTCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((BDTCurrencyModel.Cast _BDTCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BDTCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BDTCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_BDTCurrency_name", Description="Create a BDTCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BDTCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BDTCurrency",Description = "BDTCurrency")>] 
         bdtcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BDTCurrency = Helper.toCell<BDTCurrency> bdtcurrency "BDTCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((BDTCurrencyModel.Cast _BDTCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BDTCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BDTCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_BDTCurrency_numericCode", Description="Create a BDTCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BDTCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BDTCurrency",Description = "BDTCurrency")>] 
         bdtcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BDTCurrency = Helper.toCell<BDTCurrency> bdtcurrency "BDTCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((BDTCurrencyModel.Cast _BDTCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BDTCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BDTCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_BDTCurrency_rounding", Description="Create a BDTCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BDTCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BDTCurrency",Description = "BDTCurrency")>] 
         bdtcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BDTCurrency = Helper.toCell<BDTCurrency> bdtcurrency "BDTCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((BDTCurrencyModel.Cast _BDTCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_BDTCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BDTCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BDTCurrency> format
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
    [<ExcelFunction(Name="_BDTCurrency_symbol", Description="Create a BDTCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BDTCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BDTCurrency",Description = "BDTCurrency")>] 
         bdtcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BDTCurrency = Helper.toCell<BDTCurrency> bdtcurrency "BDTCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((BDTCurrencyModel.Cast _BDTCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BDTCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BDTCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_BDTCurrency_ToString", Description="Create a BDTCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BDTCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BDTCurrency",Description = "BDTCurrency")>] 
         bdtcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BDTCurrency = Helper.toCell<BDTCurrency> bdtcurrency "BDTCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((BDTCurrencyModel.Cast _BDTCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BDTCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BDTCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_BDTCurrency_triangulationCurrency", Description="Create a BDTCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BDTCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BDTCurrency",Description = "BDTCurrency")>] 
         bdtcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BDTCurrency = Helper.toCell<BDTCurrency> bdtcurrency "BDTCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((BDTCurrencyModel.Cast _BDTCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_BDTCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BDTCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BDTCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_BDTCurrency_Range", Description="Create a range of BDTCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BDTCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BDTCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BDTCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<BDTCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<BDTCurrency>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
