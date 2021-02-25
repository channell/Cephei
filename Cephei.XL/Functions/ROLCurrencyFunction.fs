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
module ROLCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ROLCurrency", Description="Create a ROLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ROLCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.ROLCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ROLCurrency>) l

                let source () = Helper.sourceFold "Fun.ROLCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ROLCurrency> format
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
    [<ExcelFunction(Name="_ROLCurrency_code", Description="Create a ROLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ROLCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ROLCurrency",Description = "ROLCurrency")>] 
         rolcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ROLCurrency = Helper.toModelReference<ROLCurrency> rolcurrency "ROLCurrency"  
                let builder (current : ICell) = ((ROLCurrencyModel.Cast _ROLCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ROLCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ROLCurrency.cell
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
    [<ExcelFunction(Name="_ROLCurrency_empty", Description="Create a ROLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ROLCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ROLCurrency",Description = "ROLCurrency")>] 
         rolcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ROLCurrency = Helper.toModelReference<ROLCurrency> rolcurrency "ROLCurrency"  
                let builder (current : ICell) = ((ROLCurrencyModel.Cast _ROLCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ROLCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ROLCurrency.cell
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
    [<ExcelFunction(Name="_ROLCurrency_Equals", Description="Create a ROLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ROLCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ROLCurrency",Description = "ROLCurrency")>] 
         rolcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ROLCurrency = Helper.toModelReference<ROLCurrency> rolcurrency "ROLCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = ((ROLCurrencyModel.Cast _ROLCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ROLCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ROLCurrency.cell
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
    [<ExcelFunction(Name="_ROLCurrency_format", Description="Create a ROLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ROLCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ROLCurrency",Description = "ROLCurrency")>] 
         rolcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ROLCurrency = Helper.toModelReference<ROLCurrency> rolcurrency "ROLCurrency"  
                let builder (current : ICell) = ((ROLCurrencyModel.Cast _ROLCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ROLCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ROLCurrency.cell
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
    [<ExcelFunction(Name="_ROLCurrency_fractionsPerUnit", Description="Create a ROLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ROLCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ROLCurrency",Description = "ROLCurrency")>] 
         rolcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ROLCurrency = Helper.toModelReference<ROLCurrency> rolcurrency "ROLCurrency"  
                let builder (current : ICell) = ((ROLCurrencyModel.Cast _ROLCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ROLCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ROLCurrency.cell
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
    [<ExcelFunction(Name="_ROLCurrency_fractionSymbol", Description="Create a ROLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ROLCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ROLCurrency",Description = "ROLCurrency")>] 
         rolcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ROLCurrency = Helper.toModelReference<ROLCurrency> rolcurrency "ROLCurrency"  
                let builder (current : ICell) = ((ROLCurrencyModel.Cast _ROLCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ROLCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ROLCurrency.cell
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
    [<ExcelFunction(Name="_ROLCurrency_name", Description="Create a ROLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ROLCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ROLCurrency",Description = "ROLCurrency")>] 
         rolcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ROLCurrency = Helper.toModelReference<ROLCurrency> rolcurrency "ROLCurrency"  
                let builder (current : ICell) = ((ROLCurrencyModel.Cast _ROLCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ROLCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ROLCurrency.cell
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
    [<ExcelFunction(Name="_ROLCurrency_numericCode", Description="Create a ROLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ROLCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ROLCurrency",Description = "ROLCurrency")>] 
         rolcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ROLCurrency = Helper.toModelReference<ROLCurrency> rolcurrency "ROLCurrency"  
                let builder (current : ICell) = ((ROLCurrencyModel.Cast _ROLCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ROLCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ROLCurrency.cell
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
    [<ExcelFunction(Name="_ROLCurrency_rounding", Description="Create a ROLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ROLCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ROLCurrency",Description = "ROLCurrency")>] 
         rolcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ROLCurrency = Helper.toModelReference<ROLCurrency> rolcurrency "ROLCurrency"  
                let builder (current : ICell) = ((ROLCurrencyModel.Cast _ROLCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_ROLCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ROLCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ROLCurrency> format
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
    [<ExcelFunction(Name="_ROLCurrency_symbol", Description="Create a ROLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ROLCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ROLCurrency",Description = "ROLCurrency")>] 
         rolcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ROLCurrency = Helper.toModelReference<ROLCurrency> rolcurrency "ROLCurrency"  
                let builder (current : ICell) = ((ROLCurrencyModel.Cast _ROLCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ROLCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ROLCurrency.cell
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
    [<ExcelFunction(Name="_ROLCurrency_ToString", Description="Create a ROLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ROLCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ROLCurrency",Description = "ROLCurrency")>] 
         rolcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ROLCurrency = Helper.toModelReference<ROLCurrency> rolcurrency "ROLCurrency"  
                let builder (current : ICell) = ((ROLCurrencyModel.Cast _ROLCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ROLCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ROLCurrency.cell
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
    [<ExcelFunction(Name="_ROLCurrency_triangulationCurrency", Description="Create a ROLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ROLCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ROLCurrency",Description = "ROLCurrency")>] 
         rolcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ROLCurrency = Helper.toModelReference<ROLCurrency> rolcurrency "ROLCurrency"  
                let builder (current : ICell) = ((ROLCurrencyModel.Cast _ROLCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_ROLCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ROLCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ROLCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_ROLCurrency_Range", Description="Create a range of ROLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ROLCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ROLCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<ROLCurrency> (c)) :> ICell
                let format (i : Cephei.Cell.List<ROLCurrency>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<ROLCurrency>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
