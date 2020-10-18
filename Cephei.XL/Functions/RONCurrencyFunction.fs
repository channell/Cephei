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
module RONCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_RONCurrency", Description="Create a RONCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RONCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "RONCurrency")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.RONCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RONCurrency>) l

                let source () = Helper.sourceFold "Fun.RONCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RONCurrency> format
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
    [<ExcelFunction(Name="_RONCurrency_code", Description="Create a RONCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RONCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RONCurrency",Description = "RONCurrency")>] 
         roncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RONCurrency = Helper.toCell<RONCurrency> roncurrency "RONCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((RONCurrencyModel.Cast _RONCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RONCurrency.source + ".Code") 
                                               [| _RONCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RONCurrency.cell
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
    [<ExcelFunction(Name="_RONCurrency_empty", Description="Create a RONCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RONCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RONCurrency",Description = "RONCurrency")>] 
         roncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RONCurrency = Helper.toCell<RONCurrency> roncurrency "RONCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((RONCurrencyModel.Cast _RONCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RONCurrency.source + ".Empty") 
                                               [| _RONCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RONCurrency.cell
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
    [<ExcelFunction(Name="_RONCurrency_Equals", Description="Create a RONCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RONCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RONCurrency",Description = "RONCurrency")>] 
         roncurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RONCurrency = Helper.toCell<RONCurrency> roncurrency "RONCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((RONCurrencyModel.Cast _RONCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RONCurrency.source + ".Equals") 
                                               [| _RONCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RONCurrency.cell
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
    [<ExcelFunction(Name="_RONCurrency_format", Description="Create a RONCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RONCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RONCurrency",Description = "RONCurrency")>] 
         roncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RONCurrency = Helper.toCell<RONCurrency> roncurrency "RONCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((RONCurrencyModel.Cast _RONCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RONCurrency.source + ".Format") 
                                               [| _RONCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RONCurrency.cell
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
    [<ExcelFunction(Name="_RONCurrency_fractionsPerUnit", Description="Create a RONCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RONCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RONCurrency",Description = "RONCurrency")>] 
         roncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RONCurrency = Helper.toCell<RONCurrency> roncurrency "RONCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((RONCurrencyModel.Cast _RONCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RONCurrency.source + ".FractionsPerUnit") 
                                               [| _RONCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RONCurrency.cell
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
    [<ExcelFunction(Name="_RONCurrency_fractionSymbol", Description="Create a RONCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RONCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RONCurrency",Description = "RONCurrency")>] 
         roncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RONCurrency = Helper.toCell<RONCurrency> roncurrency "RONCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((RONCurrencyModel.Cast _RONCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RONCurrency.source + ".FractionSymbol") 
                                               [| _RONCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RONCurrency.cell
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
    [<ExcelFunction(Name="_RONCurrency_name", Description="Create a RONCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RONCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RONCurrency",Description = "RONCurrency")>] 
         roncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RONCurrency = Helper.toCell<RONCurrency> roncurrency "RONCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((RONCurrencyModel.Cast _RONCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RONCurrency.source + ".Name") 
                                               [| _RONCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RONCurrency.cell
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
    [<ExcelFunction(Name="_RONCurrency_numericCode", Description="Create a RONCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RONCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RONCurrency",Description = "RONCurrency")>] 
         roncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RONCurrency = Helper.toCell<RONCurrency> roncurrency "RONCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((RONCurrencyModel.Cast _RONCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RONCurrency.source + ".NumericCode") 
                                               [| _RONCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RONCurrency.cell
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
    [<ExcelFunction(Name="_RONCurrency_rounding", Description="Create a RONCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RONCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RONCurrency",Description = "RONCurrency")>] 
         roncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RONCurrency = Helper.toCell<RONCurrency> roncurrency "RONCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((RONCurrencyModel.Cast _RONCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_RONCurrency.source + ".Rounding") 
                                               [| _RONCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RONCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RONCurrency> format
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
    [<ExcelFunction(Name="_RONCurrency_symbol", Description="Create a RONCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RONCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RONCurrency",Description = "RONCurrency")>] 
         roncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RONCurrency = Helper.toCell<RONCurrency> roncurrency "RONCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((RONCurrencyModel.Cast _RONCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RONCurrency.source + ".Symbol") 
                                               [| _RONCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RONCurrency.cell
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
    [<ExcelFunction(Name="_RONCurrency_ToString", Description="Create a RONCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RONCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RONCurrency",Description = "RONCurrency")>] 
         roncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RONCurrency = Helper.toCell<RONCurrency> roncurrency "RONCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((RONCurrencyModel.Cast _RONCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RONCurrency.source + ".ToString") 
                                               [| _RONCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RONCurrency.cell
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
    [<ExcelFunction(Name="_RONCurrency_triangulationCurrency", Description="Create a RONCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RONCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RONCurrency",Description = "RONCurrency")>] 
         roncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RONCurrency = Helper.toCell<RONCurrency> roncurrency "RONCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((RONCurrencyModel.Cast _RONCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_RONCurrency.source + ".TriangulationCurrency") 
                                               [| _RONCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RONCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RONCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_RONCurrency_Range", Description="Create a range of RONCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RONCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<RONCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<RONCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<RONCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<RONCurrency>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
