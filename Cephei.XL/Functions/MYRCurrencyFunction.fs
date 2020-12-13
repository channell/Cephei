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
  The ISO three-letter code is MYR; the numeric code is 458. It is divided in 100 sen.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module MYRCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_MYRCurrency", Description="Create a MYRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MYRCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.MYRCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MYRCurrency>) l

                let source () = Helper.sourceFold "Fun.MYRCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MYRCurrency> format
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
    [<ExcelFunction(Name="_MYRCurrency_code", Description="Create a MYRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MYRCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MYRCurrency",Description = "MYRCurrency")>] 
         myrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MYRCurrency = Helper.toCell<MYRCurrency> myrcurrency "MYRCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((MYRCurrencyModel.Cast _MYRCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MYRCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MYRCurrency.cell
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
    [<ExcelFunction(Name="_MYRCurrency_empty", Description="Create a MYRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MYRCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MYRCurrency",Description = "MYRCurrency")>] 
         myrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MYRCurrency = Helper.toCell<MYRCurrency> myrcurrency "MYRCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((MYRCurrencyModel.Cast _MYRCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MYRCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MYRCurrency.cell
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
    [<ExcelFunction(Name="_MYRCurrency_Equals", Description="Create a MYRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MYRCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MYRCurrency",Description = "MYRCurrency")>] 
         myrcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MYRCurrency = Helper.toCell<MYRCurrency> myrcurrency "MYRCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((MYRCurrencyModel.Cast _MYRCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MYRCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MYRCurrency.cell
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
    [<ExcelFunction(Name="_MYRCurrency_format", Description="Create a MYRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MYRCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MYRCurrency",Description = "MYRCurrency")>] 
         myrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MYRCurrency = Helper.toCell<MYRCurrency> myrcurrency "MYRCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((MYRCurrencyModel.Cast _MYRCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MYRCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MYRCurrency.cell
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
    [<ExcelFunction(Name="_MYRCurrency_fractionsPerUnit", Description="Create a MYRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MYRCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MYRCurrency",Description = "MYRCurrency")>] 
         myrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MYRCurrency = Helper.toCell<MYRCurrency> myrcurrency "MYRCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((MYRCurrencyModel.Cast _MYRCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MYRCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MYRCurrency.cell
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
    [<ExcelFunction(Name="_MYRCurrency_fractionSymbol", Description="Create a MYRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MYRCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MYRCurrency",Description = "MYRCurrency")>] 
         myrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MYRCurrency = Helper.toCell<MYRCurrency> myrcurrency "MYRCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((MYRCurrencyModel.Cast _MYRCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MYRCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MYRCurrency.cell
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
    [<ExcelFunction(Name="_MYRCurrency_name", Description="Create a MYRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MYRCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MYRCurrency",Description = "MYRCurrency")>] 
         myrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MYRCurrency = Helper.toCell<MYRCurrency> myrcurrency "MYRCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((MYRCurrencyModel.Cast _MYRCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MYRCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MYRCurrency.cell
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
    [<ExcelFunction(Name="_MYRCurrency_numericCode", Description="Create a MYRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MYRCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MYRCurrency",Description = "MYRCurrency")>] 
         myrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MYRCurrency = Helper.toCell<MYRCurrency> myrcurrency "MYRCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((MYRCurrencyModel.Cast _MYRCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MYRCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MYRCurrency.cell
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
    [<ExcelFunction(Name="_MYRCurrency_rounding", Description="Create a MYRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MYRCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MYRCurrency",Description = "MYRCurrency")>] 
         myrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MYRCurrency = Helper.toCell<MYRCurrency> myrcurrency "MYRCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((MYRCurrencyModel.Cast _MYRCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_MYRCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MYRCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MYRCurrency> format
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
    [<ExcelFunction(Name="_MYRCurrency_symbol", Description="Create a MYRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MYRCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MYRCurrency",Description = "MYRCurrency")>] 
         myrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MYRCurrency = Helper.toCell<MYRCurrency> myrcurrency "MYRCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((MYRCurrencyModel.Cast _MYRCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MYRCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MYRCurrency.cell
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
    [<ExcelFunction(Name="_MYRCurrency_ToString", Description="Create a MYRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MYRCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MYRCurrency",Description = "MYRCurrency")>] 
         myrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MYRCurrency = Helper.toCell<MYRCurrency> myrcurrency "MYRCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((MYRCurrencyModel.Cast _MYRCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MYRCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MYRCurrency.cell
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
    [<ExcelFunction(Name="_MYRCurrency_triangulationCurrency", Description="Create a MYRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MYRCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MYRCurrency",Description = "MYRCurrency")>] 
         myrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MYRCurrency = Helper.toCell<MYRCurrency> myrcurrency "MYRCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((MYRCurrencyModel.Cast _MYRCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_MYRCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MYRCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MYRCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_MYRCurrency_Range", Description="Create a range of MYRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MYRCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MYRCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<MYRCurrency> (c)) :> ICell
                let format (i : Cephei.Cell.List<MYRCurrency>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<MYRCurrency>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
