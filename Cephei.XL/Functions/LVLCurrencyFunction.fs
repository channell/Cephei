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
module LVLCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_LVLCurrency", Description="Create a LVLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LVLCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.LVLCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LVLCurrency>) l

                let source () = Helper.sourceFold "Fun.LVLCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LVLCurrency> format
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
    [<ExcelFunction(Name="_LVLCurrency_code", Description="Create a LVLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LVLCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LVLCurrency",Description = "LVLCurrency")>] 
         lvlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LVLCurrency = Helper.toCell<LVLCurrency> lvlcurrency "LVLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((LVLCurrencyModel.Cast _LVLCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LVLCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LVLCurrency.cell
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
    [<ExcelFunction(Name="_LVLCurrency_empty", Description="Create a LVLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LVLCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LVLCurrency",Description = "LVLCurrency")>] 
         lvlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LVLCurrency = Helper.toCell<LVLCurrency> lvlcurrency "LVLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((LVLCurrencyModel.Cast _LVLCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LVLCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LVLCurrency.cell
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
    [<ExcelFunction(Name="_LVLCurrency_Equals", Description="Create a LVLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LVLCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LVLCurrency",Description = "LVLCurrency")>] 
         lvlcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LVLCurrency = Helper.toCell<LVLCurrency> lvlcurrency "LVLCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((LVLCurrencyModel.Cast _LVLCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LVLCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LVLCurrency.cell
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
    [<ExcelFunction(Name="_LVLCurrency_format", Description="Create a LVLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LVLCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LVLCurrency",Description = "LVLCurrency")>] 
         lvlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LVLCurrency = Helper.toCell<LVLCurrency> lvlcurrency "LVLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((LVLCurrencyModel.Cast _LVLCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LVLCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LVLCurrency.cell
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
    [<ExcelFunction(Name="_LVLCurrency_fractionsPerUnit", Description="Create a LVLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LVLCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LVLCurrency",Description = "LVLCurrency")>] 
         lvlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LVLCurrency = Helper.toCell<LVLCurrency> lvlcurrency "LVLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((LVLCurrencyModel.Cast _LVLCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LVLCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LVLCurrency.cell
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
    [<ExcelFunction(Name="_LVLCurrency_fractionSymbol", Description="Create a LVLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LVLCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LVLCurrency",Description = "LVLCurrency")>] 
         lvlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LVLCurrency = Helper.toCell<LVLCurrency> lvlcurrency "LVLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((LVLCurrencyModel.Cast _LVLCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LVLCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LVLCurrency.cell
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
    [<ExcelFunction(Name="_LVLCurrency_name", Description="Create a LVLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LVLCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LVLCurrency",Description = "LVLCurrency")>] 
         lvlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LVLCurrency = Helper.toCell<LVLCurrency> lvlcurrency "LVLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((LVLCurrencyModel.Cast _LVLCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LVLCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LVLCurrency.cell
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
    [<ExcelFunction(Name="_LVLCurrency_numericCode", Description="Create a LVLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LVLCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LVLCurrency",Description = "LVLCurrency")>] 
         lvlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LVLCurrency = Helper.toCell<LVLCurrency> lvlcurrency "LVLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((LVLCurrencyModel.Cast _LVLCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LVLCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LVLCurrency.cell
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
    [<ExcelFunction(Name="_LVLCurrency_rounding", Description="Create a LVLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LVLCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LVLCurrency",Description = "LVLCurrency")>] 
         lvlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LVLCurrency = Helper.toCell<LVLCurrency> lvlcurrency "LVLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((LVLCurrencyModel.Cast _LVLCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_LVLCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LVLCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LVLCurrency> format
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
    [<ExcelFunction(Name="_LVLCurrency_symbol", Description="Create a LVLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LVLCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LVLCurrency",Description = "LVLCurrency")>] 
         lvlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LVLCurrency = Helper.toCell<LVLCurrency> lvlcurrency "LVLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((LVLCurrencyModel.Cast _LVLCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LVLCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LVLCurrency.cell
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
    [<ExcelFunction(Name="_LVLCurrency_ToString", Description="Create a LVLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LVLCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LVLCurrency",Description = "LVLCurrency")>] 
         lvlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LVLCurrency = Helper.toCell<LVLCurrency> lvlcurrency "LVLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((LVLCurrencyModel.Cast _LVLCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LVLCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LVLCurrency.cell
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
    [<ExcelFunction(Name="_LVLCurrency_triangulationCurrency", Description="Create a LVLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LVLCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LVLCurrency",Description = "LVLCurrency")>] 
         lvlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LVLCurrency = Helper.toCell<LVLCurrency> lvlcurrency "LVLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((LVLCurrencyModel.Cast _LVLCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_LVLCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LVLCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LVLCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_LVLCurrency_Range", Description="Create a range of LVLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LVLCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LVLCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<LVLCurrency> (c)) :> ICell
                let format (i : Cephei.Cell.List<LVLCurrency>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<LVLCurrency>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
