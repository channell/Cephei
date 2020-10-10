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
  Australian dollar   The ISO three-letter code is AUD; the numeric code is 36. It is divided into 100 cents.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module AUDCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AUDCurrency", Description="Create a AUDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AUDCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.AUDCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AUDCurrency>) l

                let source () = Helper.sourceFold "Fun.AUDCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AUDCurrency> format
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
    [<ExcelFunction(Name="_AUDCurrency_code", Description="Create a AUDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AUDCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDCurrency",Description = "Reference to AUDCurrency")>] 
         audcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDCurrency = Helper.toCell<AUDCurrency> audcurrency "AUDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((AUDCurrencyModel.Cast _AUDCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AUDCurrency.source + ".Code") 
                                               [| _AUDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDCurrency.cell
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
    [<ExcelFunction(Name="_AUDCurrency_empty", Description="Create a AUDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AUDCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDCurrency",Description = "Reference to AUDCurrency")>] 
         audcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDCurrency = Helper.toCell<AUDCurrency> audcurrency "AUDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((AUDCurrencyModel.Cast _AUDCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AUDCurrency.source + ".Empty") 
                                               [| _AUDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDCurrency.cell
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
    [<ExcelFunction(Name="_AUDCurrency_Equals", Description="Create a AUDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AUDCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDCurrency",Description = "Reference to AUDCurrency")>] 
         audcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDCurrency = Helper.toCell<AUDCurrency> audcurrency "AUDCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((AUDCurrencyModel.Cast _AUDCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AUDCurrency.source + ".Equals") 
                                               [| _AUDCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDCurrency.cell
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
    [<ExcelFunction(Name="_AUDCurrency_format", Description="Create a AUDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AUDCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDCurrency",Description = "Reference to AUDCurrency")>] 
         audcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDCurrency = Helper.toCell<AUDCurrency> audcurrency "AUDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((AUDCurrencyModel.Cast _AUDCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AUDCurrency.source + ".Format") 
                                               [| _AUDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDCurrency.cell
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
    [<ExcelFunction(Name="_AUDCurrency_fractionsPerUnit", Description="Create a AUDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AUDCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDCurrency",Description = "Reference to AUDCurrency")>] 
         audcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDCurrency = Helper.toCell<AUDCurrency> audcurrency "AUDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((AUDCurrencyModel.Cast _AUDCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AUDCurrency.source + ".FractionsPerUnit") 
                                               [| _AUDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDCurrency.cell
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
    [<ExcelFunction(Name="_AUDCurrency_fractionSymbol", Description="Create a AUDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AUDCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDCurrency",Description = "Reference to AUDCurrency")>] 
         audcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDCurrency = Helper.toCell<AUDCurrency> audcurrency "AUDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((AUDCurrencyModel.Cast _AUDCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AUDCurrency.source + ".FractionSymbol") 
                                               [| _AUDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDCurrency.cell
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
    [<ExcelFunction(Name="_AUDCurrency_name", Description="Create a AUDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AUDCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDCurrency",Description = "Reference to AUDCurrency")>] 
         audcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDCurrency = Helper.toCell<AUDCurrency> audcurrency "AUDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((AUDCurrencyModel.Cast _AUDCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AUDCurrency.source + ".Name") 
                                               [| _AUDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDCurrency.cell
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
    [<ExcelFunction(Name="_AUDCurrency_numericCode", Description="Create a AUDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AUDCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDCurrency",Description = "Reference to AUDCurrency")>] 
         audcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDCurrency = Helper.toCell<AUDCurrency> audcurrency "AUDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((AUDCurrencyModel.Cast _AUDCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AUDCurrency.source + ".NumericCode") 
                                               [| _AUDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDCurrency.cell
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
    [<ExcelFunction(Name="_AUDCurrency_rounding", Description="Create a AUDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AUDCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDCurrency",Description = "Reference to AUDCurrency")>] 
         audcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDCurrency = Helper.toCell<AUDCurrency> audcurrency "AUDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((AUDCurrencyModel.Cast _AUDCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_AUDCurrency.source + ".Rounding") 
                                               [| _AUDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AUDCurrency> format
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
    [<ExcelFunction(Name="_AUDCurrency_symbol", Description="Create a AUDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AUDCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDCurrency",Description = "Reference to AUDCurrency")>] 
         audcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDCurrency = Helper.toCell<AUDCurrency> audcurrency "AUDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((AUDCurrencyModel.Cast _AUDCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AUDCurrency.source + ".Symbol") 
                                               [| _AUDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDCurrency.cell
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
    [<ExcelFunction(Name="_AUDCurrency_ToString", Description="Create a AUDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AUDCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDCurrency",Description = "Reference to AUDCurrency")>] 
         audcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDCurrency = Helper.toCell<AUDCurrency> audcurrency "AUDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((AUDCurrencyModel.Cast _AUDCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AUDCurrency.source + ".ToString") 
                                               [| _AUDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDCurrency.cell
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
    [<ExcelFunction(Name="_AUDCurrency_triangulationCurrency", Description="Create a AUDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AUDCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUDCurrency",Description = "Reference to AUDCurrency")>] 
         audcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUDCurrency = Helper.toCell<AUDCurrency> audcurrency "AUDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((AUDCurrencyModel.Cast _AUDCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_AUDCurrency.source + ".TriangulationCurrency") 
                                               [| _AUDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AUDCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_AUDCurrency_Range", Description="Create a range of AUDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AUDCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the AUDCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AUDCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AUDCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<AUDCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<AUDCurrency>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
