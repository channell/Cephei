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
module CZKCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CZKCurrency", Description="Create a CZKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CZKCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "CZKCurrency")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.CZKCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CZKCurrency>) l

                let source () = Helper.sourceFold "Fun.CZKCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CZKCurrency> format
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
    [<ExcelFunction(Name="_CZKCurrency_code", Description="Create a CZKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CZKCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CZKCurrency",Description = "CZKCurrency")>] 
         czkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CZKCurrency = Helper.toCell<CZKCurrency> czkcurrency "CZKCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CZKCurrencyModel.Cast _CZKCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CZKCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CZKCurrency.cell
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
    [<ExcelFunction(Name="_CZKCurrency_empty", Description="Create a CZKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CZKCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CZKCurrency",Description = "CZKCurrency")>] 
         czkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CZKCurrency = Helper.toCell<CZKCurrency> czkcurrency "CZKCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CZKCurrencyModel.Cast _CZKCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CZKCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CZKCurrency.cell
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
    [<ExcelFunction(Name="_CZKCurrency_Equals", Description="Create a CZKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CZKCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CZKCurrency",Description = "CZKCurrency")>] 
         czkcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CZKCurrency = Helper.toCell<CZKCurrency> czkcurrency "CZKCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((CZKCurrencyModel.Cast _CZKCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CZKCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CZKCurrency.cell
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
    [<ExcelFunction(Name="_CZKCurrency_format", Description="Create a CZKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CZKCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CZKCurrency",Description = "CZKCurrency")>] 
         czkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CZKCurrency = Helper.toCell<CZKCurrency> czkcurrency "CZKCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CZKCurrencyModel.Cast _CZKCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CZKCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CZKCurrency.cell
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
    [<ExcelFunction(Name="_CZKCurrency_fractionsPerUnit", Description="Create a CZKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CZKCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CZKCurrency",Description = "CZKCurrency")>] 
         czkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CZKCurrency = Helper.toCell<CZKCurrency> czkcurrency "CZKCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CZKCurrencyModel.Cast _CZKCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CZKCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CZKCurrency.cell
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
    [<ExcelFunction(Name="_CZKCurrency_fractionSymbol", Description="Create a CZKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CZKCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CZKCurrency",Description = "CZKCurrency")>] 
         czkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CZKCurrency = Helper.toCell<CZKCurrency> czkcurrency "CZKCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CZKCurrencyModel.Cast _CZKCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CZKCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CZKCurrency.cell
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
    [<ExcelFunction(Name="_CZKCurrency_name", Description="Create a CZKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CZKCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CZKCurrency",Description = "CZKCurrency")>] 
         czkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CZKCurrency = Helper.toCell<CZKCurrency> czkcurrency "CZKCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CZKCurrencyModel.Cast _CZKCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CZKCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CZKCurrency.cell
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
    [<ExcelFunction(Name="_CZKCurrency_numericCode", Description="Create a CZKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CZKCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CZKCurrency",Description = "CZKCurrency")>] 
         czkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CZKCurrency = Helper.toCell<CZKCurrency> czkcurrency "CZKCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CZKCurrencyModel.Cast _CZKCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CZKCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CZKCurrency.cell
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
    [<ExcelFunction(Name="_CZKCurrency_rounding", Description="Create a CZKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CZKCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CZKCurrency",Description = "CZKCurrency")>] 
         czkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CZKCurrency = Helper.toCell<CZKCurrency> czkcurrency "CZKCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CZKCurrencyModel.Cast _CZKCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_CZKCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CZKCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CZKCurrency> format
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
    [<ExcelFunction(Name="_CZKCurrency_symbol", Description="Create a CZKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CZKCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CZKCurrency",Description = "CZKCurrency")>] 
         czkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CZKCurrency = Helper.toCell<CZKCurrency> czkcurrency "CZKCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CZKCurrencyModel.Cast _CZKCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CZKCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CZKCurrency.cell
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
    [<ExcelFunction(Name="_CZKCurrency_ToString", Description="Create a CZKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CZKCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CZKCurrency",Description = "CZKCurrency")>] 
         czkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CZKCurrency = Helper.toCell<CZKCurrency> czkcurrency "CZKCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CZKCurrencyModel.Cast _CZKCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CZKCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CZKCurrency.cell
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
    [<ExcelFunction(Name="_CZKCurrency_triangulationCurrency", Description="Create a CZKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CZKCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CZKCurrency",Description = "CZKCurrency")>] 
         czkcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CZKCurrency = Helper.toCell<CZKCurrency> czkcurrency "CZKCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CZKCurrencyModel.Cast _CZKCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_CZKCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CZKCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CZKCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_CZKCurrency_Range", Description="Create a range of CZKCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CZKCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CZKCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CZKCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<CZKCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<CZKCurrency>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
