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
module EEKCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EEKCurrency", Description="Create a EEKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EEKCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.EEKCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EEKCurrency>) l

                let source () = Helper.sourceFold "Fun.EEKCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EEKCurrency> format
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
    [<ExcelFunction(Name="_EEKCurrency_code", Description="Create a EEKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EEKCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EEKCurrency",Description = "EEKCurrency")>] 
         eekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EEKCurrency = Helper.toCell<EEKCurrency> eekcurrency "EEKCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((EEKCurrencyModel.Cast _EEKCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EEKCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EEKCurrency.cell
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
    [<ExcelFunction(Name="_EEKCurrency_empty", Description="Create a EEKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EEKCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EEKCurrency",Description = "EEKCurrency")>] 
         eekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EEKCurrency = Helper.toCell<EEKCurrency> eekcurrency "EEKCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((EEKCurrencyModel.Cast _EEKCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EEKCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EEKCurrency.cell
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
    [<ExcelFunction(Name="_EEKCurrency_Equals", Description="Create a EEKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EEKCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EEKCurrency",Description = "EEKCurrency")>] 
         eekcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EEKCurrency = Helper.toCell<EEKCurrency> eekcurrency "EEKCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((EEKCurrencyModel.Cast _EEKCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EEKCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EEKCurrency.cell
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
    [<ExcelFunction(Name="_EEKCurrency_format", Description="Create a EEKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EEKCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EEKCurrency",Description = "EEKCurrency")>] 
         eekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EEKCurrency = Helper.toCell<EEKCurrency> eekcurrency "EEKCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((EEKCurrencyModel.Cast _EEKCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EEKCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EEKCurrency.cell
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
    [<ExcelFunction(Name="_EEKCurrency_fractionsPerUnit", Description="Create a EEKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EEKCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EEKCurrency",Description = "EEKCurrency")>] 
         eekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EEKCurrency = Helper.toCell<EEKCurrency> eekcurrency "EEKCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((EEKCurrencyModel.Cast _EEKCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EEKCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EEKCurrency.cell
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
    [<ExcelFunction(Name="_EEKCurrency_fractionSymbol", Description="Create a EEKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EEKCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EEKCurrency",Description = "EEKCurrency")>] 
         eekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EEKCurrency = Helper.toCell<EEKCurrency> eekcurrency "EEKCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((EEKCurrencyModel.Cast _EEKCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EEKCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EEKCurrency.cell
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
    [<ExcelFunction(Name="_EEKCurrency_name", Description="Create a EEKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EEKCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EEKCurrency",Description = "EEKCurrency")>] 
         eekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EEKCurrency = Helper.toCell<EEKCurrency> eekcurrency "EEKCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((EEKCurrencyModel.Cast _EEKCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EEKCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EEKCurrency.cell
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
    [<ExcelFunction(Name="_EEKCurrency_numericCode", Description="Create a EEKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EEKCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EEKCurrency",Description = "EEKCurrency")>] 
         eekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EEKCurrency = Helper.toCell<EEKCurrency> eekcurrency "EEKCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((EEKCurrencyModel.Cast _EEKCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EEKCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EEKCurrency.cell
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
    [<ExcelFunction(Name="_EEKCurrency_rounding", Description="Create a EEKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EEKCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EEKCurrency",Description = "EEKCurrency")>] 
         eekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EEKCurrency = Helper.toCell<EEKCurrency> eekcurrency "EEKCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((EEKCurrencyModel.Cast _EEKCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_EEKCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EEKCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EEKCurrency> format
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
    [<ExcelFunction(Name="_EEKCurrency_symbol", Description="Create a EEKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EEKCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EEKCurrency",Description = "EEKCurrency")>] 
         eekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EEKCurrency = Helper.toCell<EEKCurrency> eekcurrency "EEKCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((EEKCurrencyModel.Cast _EEKCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EEKCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EEKCurrency.cell
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
    [<ExcelFunction(Name="_EEKCurrency_ToString", Description="Create a EEKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EEKCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EEKCurrency",Description = "EEKCurrency")>] 
         eekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EEKCurrency = Helper.toCell<EEKCurrency> eekcurrency "EEKCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((EEKCurrencyModel.Cast _EEKCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EEKCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EEKCurrency.cell
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
    [<ExcelFunction(Name="_EEKCurrency_triangulationCurrency", Description="Create a EEKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EEKCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EEKCurrency",Description = "EEKCurrency")>] 
         eekcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EEKCurrency = Helper.toCell<EEKCurrency> eekcurrency "EEKCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((EEKCurrencyModel.Cast _EEKCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_EEKCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EEKCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EEKCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_EEKCurrency_Range", Description="Create a range of EEKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EEKCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EEKCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<EEKCurrency> (c)) :> ICell
                let format (i : Cephei.Cell.List<EEKCurrency>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<EEKCurrency>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
