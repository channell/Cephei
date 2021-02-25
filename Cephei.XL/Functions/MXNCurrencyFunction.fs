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
  Mexican peso   The ISO three-letter code is MXN; the numeric code is 484. It is divided in 100 centavos.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module MXNCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_MXNCurrency", Description="Create a MXNCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MXNCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.MXNCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MXNCurrency>) l

                let source () = Helper.sourceFold "Fun.MXNCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MXNCurrency> format
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
    [<ExcelFunction(Name="_MXNCurrency_code", Description="Create a MXNCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MXNCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MXNCurrency",Description = "MXNCurrency")>] 
         mxncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MXNCurrency = Helper.toModelReference<MXNCurrency> mxncurrency "MXNCurrency"  
                let builder (current : ICell) = ((MXNCurrencyModel.Cast _MXNCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MXNCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MXNCurrency.cell
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
    [<ExcelFunction(Name="_MXNCurrency_empty", Description="Create a MXNCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MXNCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MXNCurrency",Description = "MXNCurrency")>] 
         mxncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MXNCurrency = Helper.toModelReference<MXNCurrency> mxncurrency "MXNCurrency"  
                let builder (current : ICell) = ((MXNCurrencyModel.Cast _MXNCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MXNCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MXNCurrency.cell
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
    [<ExcelFunction(Name="_MXNCurrency_Equals", Description="Create a MXNCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MXNCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MXNCurrency",Description = "MXNCurrency")>] 
         mxncurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MXNCurrency = Helper.toModelReference<MXNCurrency> mxncurrency "MXNCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = ((MXNCurrencyModel.Cast _MXNCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MXNCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MXNCurrency.cell
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
    [<ExcelFunction(Name="_MXNCurrency_format", Description="Create a MXNCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MXNCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MXNCurrency",Description = "MXNCurrency")>] 
         mxncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MXNCurrency = Helper.toModelReference<MXNCurrency> mxncurrency "MXNCurrency"  
                let builder (current : ICell) = ((MXNCurrencyModel.Cast _MXNCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MXNCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MXNCurrency.cell
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
    [<ExcelFunction(Name="_MXNCurrency_fractionsPerUnit", Description="Create a MXNCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MXNCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MXNCurrency",Description = "MXNCurrency")>] 
         mxncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MXNCurrency = Helper.toModelReference<MXNCurrency> mxncurrency "MXNCurrency"  
                let builder (current : ICell) = ((MXNCurrencyModel.Cast _MXNCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MXNCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MXNCurrency.cell
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
    [<ExcelFunction(Name="_MXNCurrency_fractionSymbol", Description="Create a MXNCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MXNCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MXNCurrency",Description = "MXNCurrency")>] 
         mxncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MXNCurrency = Helper.toModelReference<MXNCurrency> mxncurrency "MXNCurrency"  
                let builder (current : ICell) = ((MXNCurrencyModel.Cast _MXNCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MXNCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MXNCurrency.cell
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
    [<ExcelFunction(Name="_MXNCurrency_name", Description="Create a MXNCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MXNCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MXNCurrency",Description = "MXNCurrency")>] 
         mxncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MXNCurrency = Helper.toModelReference<MXNCurrency> mxncurrency "MXNCurrency"  
                let builder (current : ICell) = ((MXNCurrencyModel.Cast _MXNCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MXNCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MXNCurrency.cell
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
    [<ExcelFunction(Name="_MXNCurrency_numericCode", Description="Create a MXNCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MXNCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MXNCurrency",Description = "MXNCurrency")>] 
         mxncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MXNCurrency = Helper.toModelReference<MXNCurrency> mxncurrency "MXNCurrency"  
                let builder (current : ICell) = ((MXNCurrencyModel.Cast _MXNCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MXNCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MXNCurrency.cell
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
    [<ExcelFunction(Name="_MXNCurrency_rounding", Description="Create a MXNCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MXNCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MXNCurrency",Description = "MXNCurrency")>] 
         mxncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MXNCurrency = Helper.toModelReference<MXNCurrency> mxncurrency "MXNCurrency"  
                let builder (current : ICell) = ((MXNCurrencyModel.Cast _MXNCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_MXNCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MXNCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MXNCurrency> format
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
    [<ExcelFunction(Name="_MXNCurrency_symbol", Description="Create a MXNCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MXNCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MXNCurrency",Description = "MXNCurrency")>] 
         mxncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MXNCurrency = Helper.toModelReference<MXNCurrency> mxncurrency "MXNCurrency"  
                let builder (current : ICell) = ((MXNCurrencyModel.Cast _MXNCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MXNCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MXNCurrency.cell
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
    [<ExcelFunction(Name="_MXNCurrency_ToString", Description="Create a MXNCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MXNCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MXNCurrency",Description = "MXNCurrency")>] 
         mxncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MXNCurrency = Helper.toModelReference<MXNCurrency> mxncurrency "MXNCurrency"  
                let builder (current : ICell) = ((MXNCurrencyModel.Cast _MXNCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MXNCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MXNCurrency.cell
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
    [<ExcelFunction(Name="_MXNCurrency_triangulationCurrency", Description="Create a MXNCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MXNCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MXNCurrency",Description = "MXNCurrency")>] 
         mxncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MXNCurrency = Helper.toModelReference<MXNCurrency> mxncurrency "MXNCurrency"  
                let builder (current : ICell) = ((MXNCurrencyModel.Cast _MXNCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_MXNCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MXNCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MXNCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_MXNCurrency_Range", Description="Create a range of MXNCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MXNCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MXNCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<MXNCurrency> (c)) :> ICell
                let format (i : Cephei.Cell.List<MXNCurrency>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<MXNCurrency>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
