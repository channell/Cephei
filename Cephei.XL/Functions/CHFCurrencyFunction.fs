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
module CHFCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CHFCurrency", Description="Create a CHFCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CHFCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "CHFCurrency")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.CHFCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CHFCurrency>) l

                let source () = Helper.sourceFold "Fun.CHFCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CHFCurrency> format
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
    [<ExcelFunction(Name="_CHFCurrency_code", Description="Create a CHFCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CHFCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFCurrency",Description = "CHFCurrency")>] 
         chfcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFCurrency = Helper.toCell<CHFCurrency> chfcurrency "CHFCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CHFCurrencyModel.Cast _CHFCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CHFCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CHFCurrency.cell
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
    [<ExcelFunction(Name="_CHFCurrency_empty", Description="Create a CHFCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CHFCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFCurrency",Description = "CHFCurrency")>] 
         chfcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFCurrency = Helper.toCell<CHFCurrency> chfcurrency "CHFCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CHFCurrencyModel.Cast _CHFCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CHFCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CHFCurrency.cell
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
    [<ExcelFunction(Name="_CHFCurrency_Equals", Description="Create a CHFCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CHFCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFCurrency",Description = "CHFCurrency")>] 
         chfcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFCurrency = Helper.toCell<CHFCurrency> chfcurrency "CHFCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((CHFCurrencyModel.Cast _CHFCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CHFCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFCurrency.cell
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
    [<ExcelFunction(Name="_CHFCurrency_format", Description="Create a CHFCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CHFCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFCurrency",Description = "CHFCurrency")>] 
         chfcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFCurrency = Helper.toCell<CHFCurrency> chfcurrency "CHFCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CHFCurrencyModel.Cast _CHFCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CHFCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CHFCurrency.cell
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
    [<ExcelFunction(Name="_CHFCurrency_fractionsPerUnit", Description="Create a CHFCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CHFCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFCurrency",Description = "CHFCurrency")>] 
         chfcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFCurrency = Helper.toCell<CHFCurrency> chfcurrency "CHFCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CHFCurrencyModel.Cast _CHFCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CHFCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CHFCurrency.cell
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
    [<ExcelFunction(Name="_CHFCurrency_fractionSymbol", Description="Create a CHFCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CHFCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFCurrency",Description = "CHFCurrency")>] 
         chfcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFCurrency = Helper.toCell<CHFCurrency> chfcurrency "CHFCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CHFCurrencyModel.Cast _CHFCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CHFCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CHFCurrency.cell
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
    [<ExcelFunction(Name="_CHFCurrency_name", Description="Create a CHFCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CHFCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFCurrency",Description = "CHFCurrency")>] 
         chfcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFCurrency = Helper.toCell<CHFCurrency> chfcurrency "CHFCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CHFCurrencyModel.Cast _CHFCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CHFCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CHFCurrency.cell
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
    [<ExcelFunction(Name="_CHFCurrency_numericCode", Description="Create a CHFCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CHFCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFCurrency",Description = "CHFCurrency")>] 
         chfcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFCurrency = Helper.toCell<CHFCurrency> chfcurrency "CHFCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CHFCurrencyModel.Cast _CHFCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CHFCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CHFCurrency.cell
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
    [<ExcelFunction(Name="_CHFCurrency_rounding", Description="Create a CHFCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CHFCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFCurrency",Description = "CHFCurrency")>] 
         chfcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFCurrency = Helper.toCell<CHFCurrency> chfcurrency "CHFCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CHFCurrencyModel.Cast _CHFCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_CHFCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CHFCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CHFCurrency> format
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
    [<ExcelFunction(Name="_CHFCurrency_symbol", Description="Create a CHFCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CHFCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFCurrency",Description = "CHFCurrency")>] 
         chfcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFCurrency = Helper.toCell<CHFCurrency> chfcurrency "CHFCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CHFCurrencyModel.Cast _CHFCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CHFCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CHFCurrency.cell
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
    [<ExcelFunction(Name="_CHFCurrency_ToString", Description="Create a CHFCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CHFCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFCurrency",Description = "CHFCurrency")>] 
         chfcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFCurrency = Helper.toCell<CHFCurrency> chfcurrency "CHFCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CHFCurrencyModel.Cast _CHFCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CHFCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CHFCurrency.cell
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
    [<ExcelFunction(Name="_CHFCurrency_triangulationCurrency", Description="Create a CHFCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CHFCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFCurrency",Description = "CHFCurrency")>] 
         chfcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFCurrency = Helper.toCell<CHFCurrency> chfcurrency "CHFCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CHFCurrencyModel.Cast _CHFCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_CHFCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CHFCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CHFCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_CHFCurrency_Range", Description="Create a range of CHFCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CHFCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CHFCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CHFCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<CHFCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<CHFCurrency>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
