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
  The ISO three-letter code is TWD; the numeric code is 901. It is divided in 100 cents.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module TWDCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_TWDCurrency", Description="Create a TWDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TWDCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.TWDCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TWDCurrency>) l

                let source = Helper.sourceFold "Fun.TWDCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TWDCurrency> format
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
    [<ExcelFunction(Name="_TWDCurrency_code", Description="Create a TWDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TWDCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TWDCurrency",Description = "Reference to TWDCurrency")>] 
         twdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TWDCurrency = Helper.toCell<TWDCurrency> twdcurrency "TWDCurrency"  
                let builder () = withMnemonic mnemonic ((TWDCurrencyModel.Cast _TWDCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TWDCurrency.source + ".Code") 
                                               [| _TWDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TWDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_TWDCurrency_empty", Description="Create a TWDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TWDCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TWDCurrency",Description = "Reference to TWDCurrency")>] 
         twdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TWDCurrency = Helper.toCell<TWDCurrency> twdcurrency "TWDCurrency"  
                let builder () = withMnemonic mnemonic ((TWDCurrencyModel.Cast _TWDCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TWDCurrency.source + ".Empty") 
                                               [| _TWDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TWDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_TWDCurrency_Equals", Description="Create a TWDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TWDCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TWDCurrency",Description = "Reference to TWDCurrency")>] 
         twdcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TWDCurrency = Helper.toCell<TWDCurrency> twdcurrency "TWDCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((TWDCurrencyModel.Cast _TWDCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TWDCurrency.source + ".Equals") 
                                               [| _TWDCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TWDCurrency.cell
                                ;  _o.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_TWDCurrency_format", Description="Create a TWDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TWDCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TWDCurrency",Description = "Reference to TWDCurrency")>] 
         twdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TWDCurrency = Helper.toCell<TWDCurrency> twdcurrency "TWDCurrency"  
                let builder () = withMnemonic mnemonic ((TWDCurrencyModel.Cast _TWDCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TWDCurrency.source + ".Format") 
                                               [| _TWDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TWDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_TWDCurrency_fractionsPerUnit", Description="Create a TWDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TWDCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TWDCurrency",Description = "Reference to TWDCurrency")>] 
         twdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TWDCurrency = Helper.toCell<TWDCurrency> twdcurrency "TWDCurrency"  
                let builder () = withMnemonic mnemonic ((TWDCurrencyModel.Cast _TWDCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_TWDCurrency.source + ".FractionsPerUnit") 
                                               [| _TWDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TWDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_TWDCurrency_fractionSymbol", Description="Create a TWDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TWDCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TWDCurrency",Description = "Reference to TWDCurrency")>] 
         twdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TWDCurrency = Helper.toCell<TWDCurrency> twdcurrency "TWDCurrency"  
                let builder () = withMnemonic mnemonic ((TWDCurrencyModel.Cast _TWDCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TWDCurrency.source + ".FractionSymbol") 
                                               [| _TWDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TWDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_TWDCurrency_name", Description="Create a TWDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TWDCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TWDCurrency",Description = "Reference to TWDCurrency")>] 
         twdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TWDCurrency = Helper.toCell<TWDCurrency> twdcurrency "TWDCurrency"  
                let builder () = withMnemonic mnemonic ((TWDCurrencyModel.Cast _TWDCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TWDCurrency.source + ".Name") 
                                               [| _TWDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TWDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_TWDCurrency_numericCode", Description="Create a TWDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TWDCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TWDCurrency",Description = "Reference to TWDCurrency")>] 
         twdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TWDCurrency = Helper.toCell<TWDCurrency> twdcurrency "TWDCurrency"  
                let builder () = withMnemonic mnemonic ((TWDCurrencyModel.Cast _TWDCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_TWDCurrency.source + ".NumericCode") 
                                               [| _TWDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TWDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_TWDCurrency_rounding", Description="Create a TWDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TWDCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TWDCurrency",Description = "Reference to TWDCurrency")>] 
         twdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TWDCurrency = Helper.toCell<TWDCurrency> twdcurrency "TWDCurrency"  
                let builder () = withMnemonic mnemonic ((TWDCurrencyModel.Cast _TWDCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_TWDCurrency.source + ".Rounding") 
                                               [| _TWDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TWDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TWDCurrency> format
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
    [<ExcelFunction(Name="_TWDCurrency_symbol", Description="Create a TWDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TWDCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TWDCurrency",Description = "Reference to TWDCurrency")>] 
         twdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TWDCurrency = Helper.toCell<TWDCurrency> twdcurrency "TWDCurrency"  
                let builder () = withMnemonic mnemonic ((TWDCurrencyModel.Cast _TWDCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TWDCurrency.source + ".Symbol") 
                                               [| _TWDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TWDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_TWDCurrency_ToString", Description="Create a TWDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TWDCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TWDCurrency",Description = "Reference to TWDCurrency")>] 
         twdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TWDCurrency = Helper.toCell<TWDCurrency> twdcurrency "TWDCurrency"  
                let builder () = withMnemonic mnemonic ((TWDCurrencyModel.Cast _TWDCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TWDCurrency.source + ".ToString") 
                                               [| _TWDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TWDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_TWDCurrency_triangulationCurrency", Description="Create a TWDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TWDCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TWDCurrency",Description = "Reference to TWDCurrency")>] 
         twdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TWDCurrency = Helper.toCell<TWDCurrency> twdcurrency "TWDCurrency"  
                let builder () = withMnemonic mnemonic ((TWDCurrencyModel.Cast _TWDCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_TWDCurrency.source + ".TriangulationCurrency") 
                                               [| _TWDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TWDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TWDCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_TWDCurrency_Range", Description="Create a range of TWDCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TWDCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the TWDCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TWDCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<TWDCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<TWDCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<TWDCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
