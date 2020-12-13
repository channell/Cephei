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
  The ISO three-letter code is KRW; the numeric code is 410. It is divided in 100 chon.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module KRWCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_KRWCurrency", Description="Create a KRWCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KRWCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.KRWCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<KRWCurrency>) l

                let source () = Helper.sourceFold "Fun.KRWCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<KRWCurrency> format
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
    [<ExcelFunction(Name="_KRWCurrency_code", Description="Create a KRWCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KRWCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KRWCurrency",Description = "KRWCurrency")>] 
         krwcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KRWCurrency = Helper.toCell<KRWCurrency> krwcurrency "KRWCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((KRWCurrencyModel.Cast _KRWCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_KRWCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _KRWCurrency.cell
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
    [<ExcelFunction(Name="_KRWCurrency_empty", Description="Create a KRWCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KRWCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KRWCurrency",Description = "KRWCurrency")>] 
         krwcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KRWCurrency = Helper.toCell<KRWCurrency> krwcurrency "KRWCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((KRWCurrencyModel.Cast _KRWCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_KRWCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _KRWCurrency.cell
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
    [<ExcelFunction(Name="_KRWCurrency_Equals", Description="Create a KRWCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KRWCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KRWCurrency",Description = "KRWCurrency")>] 
         krwcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KRWCurrency = Helper.toCell<KRWCurrency> krwcurrency "KRWCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((KRWCurrencyModel.Cast _KRWCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_KRWCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KRWCurrency.cell
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
    [<ExcelFunction(Name="_KRWCurrency_format", Description="Create a KRWCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KRWCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KRWCurrency",Description = "KRWCurrency")>] 
         krwcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KRWCurrency = Helper.toCell<KRWCurrency> krwcurrency "KRWCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((KRWCurrencyModel.Cast _KRWCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_KRWCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _KRWCurrency.cell
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
    [<ExcelFunction(Name="_KRWCurrency_fractionsPerUnit", Description="Create a KRWCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KRWCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KRWCurrency",Description = "KRWCurrency")>] 
         krwcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KRWCurrency = Helper.toCell<KRWCurrency> krwcurrency "KRWCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((KRWCurrencyModel.Cast _KRWCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_KRWCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _KRWCurrency.cell
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
    [<ExcelFunction(Name="_KRWCurrency_fractionSymbol", Description="Create a KRWCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KRWCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KRWCurrency",Description = "KRWCurrency")>] 
         krwcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KRWCurrency = Helper.toCell<KRWCurrency> krwcurrency "KRWCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((KRWCurrencyModel.Cast _KRWCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_KRWCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _KRWCurrency.cell
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
    [<ExcelFunction(Name="_KRWCurrency_name", Description="Create a KRWCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KRWCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KRWCurrency",Description = "KRWCurrency")>] 
         krwcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KRWCurrency = Helper.toCell<KRWCurrency> krwcurrency "KRWCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((KRWCurrencyModel.Cast _KRWCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_KRWCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _KRWCurrency.cell
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
    [<ExcelFunction(Name="_KRWCurrency_numericCode", Description="Create a KRWCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KRWCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KRWCurrency",Description = "KRWCurrency")>] 
         krwcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KRWCurrency = Helper.toCell<KRWCurrency> krwcurrency "KRWCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((KRWCurrencyModel.Cast _KRWCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_KRWCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _KRWCurrency.cell
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
    [<ExcelFunction(Name="_KRWCurrency_rounding", Description="Create a KRWCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KRWCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KRWCurrency",Description = "KRWCurrency")>] 
         krwcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KRWCurrency = Helper.toCell<KRWCurrency> krwcurrency "KRWCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((KRWCurrencyModel.Cast _KRWCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_KRWCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _KRWCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<KRWCurrency> format
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
    [<ExcelFunction(Name="_KRWCurrency_symbol", Description="Create a KRWCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KRWCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KRWCurrency",Description = "KRWCurrency")>] 
         krwcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KRWCurrency = Helper.toCell<KRWCurrency> krwcurrency "KRWCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((KRWCurrencyModel.Cast _KRWCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_KRWCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _KRWCurrency.cell
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
    [<ExcelFunction(Name="_KRWCurrency_ToString", Description="Create a KRWCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KRWCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KRWCurrency",Description = "KRWCurrency")>] 
         krwcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KRWCurrency = Helper.toCell<KRWCurrency> krwcurrency "KRWCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((KRWCurrencyModel.Cast _KRWCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_KRWCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _KRWCurrency.cell
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
    [<ExcelFunction(Name="_KRWCurrency_triangulationCurrency", Description="Create a KRWCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KRWCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KRWCurrency",Description = "KRWCurrency")>] 
         krwcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KRWCurrency = Helper.toCell<KRWCurrency> krwcurrency "KRWCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((KRWCurrencyModel.Cast _KRWCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_KRWCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _KRWCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<KRWCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_KRWCurrency_Range", Description="Create a range of KRWCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KRWCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<KRWCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<KRWCurrency> (c)) :> ICell
                let format (i : Cephei.Cell.List<KRWCurrency>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<KRWCurrency>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
