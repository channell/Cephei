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
module FIMCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FIMCurrency", Description="Create a FIMCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FIMCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.FIMCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FIMCurrency>) l

                let source () = Helper.sourceFold "Fun.FIMCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FIMCurrency> format
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
    [<ExcelFunction(Name="_FIMCurrency_code", Description="Create a FIMCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FIMCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FIMCurrency",Description = "Reference to FIMCurrency")>] 
         fimcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FIMCurrency = Helper.toCell<FIMCurrency> fimcurrency "FIMCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((FIMCurrencyModel.Cast _FIMCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FIMCurrency.source + ".Code") 
                                               [| _FIMCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FIMCurrency.cell
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
    [<ExcelFunction(Name="_FIMCurrency_empty", Description="Create a FIMCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FIMCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FIMCurrency",Description = "Reference to FIMCurrency")>] 
         fimcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FIMCurrency = Helper.toCell<FIMCurrency> fimcurrency "FIMCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((FIMCurrencyModel.Cast _FIMCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FIMCurrency.source + ".Empty") 
                                               [| _FIMCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FIMCurrency.cell
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
    [<ExcelFunction(Name="_FIMCurrency_Equals", Description="Create a FIMCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FIMCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FIMCurrency",Description = "Reference to FIMCurrency")>] 
         fimcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FIMCurrency = Helper.toCell<FIMCurrency> fimcurrency "FIMCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((FIMCurrencyModel.Cast _FIMCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FIMCurrency.source + ".Equals") 
                                               [| _FIMCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FIMCurrency.cell
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
    [<ExcelFunction(Name="_FIMCurrency_format", Description="Create a FIMCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FIMCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FIMCurrency",Description = "Reference to FIMCurrency")>] 
         fimcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FIMCurrency = Helper.toCell<FIMCurrency> fimcurrency "FIMCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((FIMCurrencyModel.Cast _FIMCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FIMCurrency.source + ".Format") 
                                               [| _FIMCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FIMCurrency.cell
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
    [<ExcelFunction(Name="_FIMCurrency_fractionsPerUnit", Description="Create a FIMCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FIMCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FIMCurrency",Description = "Reference to FIMCurrency")>] 
         fimcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FIMCurrency = Helper.toCell<FIMCurrency> fimcurrency "FIMCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((FIMCurrencyModel.Cast _FIMCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FIMCurrency.source + ".FractionsPerUnit") 
                                               [| _FIMCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FIMCurrency.cell
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
    [<ExcelFunction(Name="_FIMCurrency_fractionSymbol", Description="Create a FIMCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FIMCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FIMCurrency",Description = "Reference to FIMCurrency")>] 
         fimcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FIMCurrency = Helper.toCell<FIMCurrency> fimcurrency "FIMCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((FIMCurrencyModel.Cast _FIMCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FIMCurrency.source + ".FractionSymbol") 
                                               [| _FIMCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FIMCurrency.cell
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
    [<ExcelFunction(Name="_FIMCurrency_name", Description="Create a FIMCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FIMCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FIMCurrency",Description = "Reference to FIMCurrency")>] 
         fimcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FIMCurrency = Helper.toCell<FIMCurrency> fimcurrency "FIMCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((FIMCurrencyModel.Cast _FIMCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FIMCurrency.source + ".Name") 
                                               [| _FIMCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FIMCurrency.cell
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
    [<ExcelFunction(Name="_FIMCurrency_numericCode", Description="Create a FIMCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FIMCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FIMCurrency",Description = "Reference to FIMCurrency")>] 
         fimcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FIMCurrency = Helper.toCell<FIMCurrency> fimcurrency "FIMCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((FIMCurrencyModel.Cast _FIMCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FIMCurrency.source + ".NumericCode") 
                                               [| _FIMCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FIMCurrency.cell
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
    [<ExcelFunction(Name="_FIMCurrency_rounding", Description="Create a FIMCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FIMCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FIMCurrency",Description = "Reference to FIMCurrency")>] 
         fimcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FIMCurrency = Helper.toCell<FIMCurrency> fimcurrency "FIMCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((FIMCurrencyModel.Cast _FIMCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_FIMCurrency.source + ".Rounding") 
                                               [| _FIMCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FIMCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FIMCurrency> format
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
    [<ExcelFunction(Name="_FIMCurrency_symbol", Description="Create a FIMCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FIMCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FIMCurrency",Description = "Reference to FIMCurrency")>] 
         fimcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FIMCurrency = Helper.toCell<FIMCurrency> fimcurrency "FIMCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((FIMCurrencyModel.Cast _FIMCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FIMCurrency.source + ".Symbol") 
                                               [| _FIMCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FIMCurrency.cell
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
    [<ExcelFunction(Name="_FIMCurrency_ToString", Description="Create a FIMCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FIMCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FIMCurrency",Description = "Reference to FIMCurrency")>] 
         fimcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FIMCurrency = Helper.toCell<FIMCurrency> fimcurrency "FIMCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((FIMCurrencyModel.Cast _FIMCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FIMCurrency.source + ".ToString") 
                                               [| _FIMCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FIMCurrency.cell
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
    [<ExcelFunction(Name="_FIMCurrency_triangulationCurrency", Description="Create a FIMCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FIMCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FIMCurrency",Description = "Reference to FIMCurrency")>] 
         fimcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FIMCurrency = Helper.toCell<FIMCurrency> fimcurrency "FIMCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((FIMCurrencyModel.Cast _FIMCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_FIMCurrency.source + ".TriangulationCurrency") 
                                               [| _FIMCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FIMCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FIMCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FIMCurrency_Range", Description="Create a range of FIMCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FIMCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FIMCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FIMCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FIMCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<FIMCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<FIMCurrency>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
