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
  The ISO three-letter code is CNY; the numeric code is 156. It is divided in 100 fen.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module CNYCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CNYCurrency", Description="Create a CNYCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CNYCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.CNYCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CNYCurrency>) l

                let source = Helper.sourceFold "Fun.CNYCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CNYCurrency> format
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
    [<ExcelFunction(Name="_CNYCurrency_code", Description="Create a CNYCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CNYCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CNYCurrency",Description = "Reference to CNYCurrency")>] 
         cnycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CNYCurrency = Helper.toCell<CNYCurrency> cnycurrency "CNYCurrency"  
                let builder () = withMnemonic mnemonic ((_CNYCurrency.cell :?> CNYCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CNYCurrency.source + ".Code") 
                                               [| _CNYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CNYCurrency.cell
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
    [<ExcelFunction(Name="_CNYCurrency_empty", Description="Create a CNYCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CNYCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CNYCurrency",Description = "Reference to CNYCurrency")>] 
         cnycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CNYCurrency = Helper.toCell<CNYCurrency> cnycurrency "CNYCurrency"  
                let builder () = withMnemonic mnemonic ((_CNYCurrency.cell :?> CNYCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CNYCurrency.source + ".Empty") 
                                               [| _CNYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CNYCurrency.cell
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
    [<ExcelFunction(Name="_CNYCurrency_Equals", Description="Create a CNYCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CNYCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CNYCurrency",Description = "Reference to CNYCurrency")>] 
         cnycurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CNYCurrency = Helper.toCell<CNYCurrency> cnycurrency "CNYCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((_CNYCurrency.cell :?> CNYCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CNYCurrency.source + ".Equals") 
                                               [| _CNYCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CNYCurrency.cell
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
    [<ExcelFunction(Name="_CNYCurrency_format", Description="Create a CNYCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CNYCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CNYCurrency",Description = "Reference to CNYCurrency")>] 
         cnycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CNYCurrency = Helper.toCell<CNYCurrency> cnycurrency "CNYCurrency"  
                let builder () = withMnemonic mnemonic ((_CNYCurrency.cell :?> CNYCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CNYCurrency.source + ".Format") 
                                               [| _CNYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CNYCurrency.cell
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
    [<ExcelFunction(Name="_CNYCurrency_fractionsPerUnit", Description="Create a CNYCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CNYCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CNYCurrency",Description = "Reference to CNYCurrency")>] 
         cnycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CNYCurrency = Helper.toCell<CNYCurrency> cnycurrency "CNYCurrency"  
                let builder () = withMnemonic mnemonic ((_CNYCurrency.cell :?> CNYCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CNYCurrency.source + ".FractionsPerUnit") 
                                               [| _CNYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CNYCurrency.cell
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
    [<ExcelFunction(Name="_CNYCurrency_fractionSymbol", Description="Create a CNYCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CNYCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CNYCurrency",Description = "Reference to CNYCurrency")>] 
         cnycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CNYCurrency = Helper.toCell<CNYCurrency> cnycurrency "CNYCurrency"  
                let builder () = withMnemonic mnemonic ((_CNYCurrency.cell :?> CNYCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CNYCurrency.source + ".FractionSymbol") 
                                               [| _CNYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CNYCurrency.cell
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
    [<ExcelFunction(Name="_CNYCurrency_name", Description="Create a CNYCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CNYCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CNYCurrency",Description = "Reference to CNYCurrency")>] 
         cnycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CNYCurrency = Helper.toCell<CNYCurrency> cnycurrency "CNYCurrency"  
                let builder () = withMnemonic mnemonic ((_CNYCurrency.cell :?> CNYCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CNYCurrency.source + ".Name") 
                                               [| _CNYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CNYCurrency.cell
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
    [<ExcelFunction(Name="_CNYCurrency_numericCode", Description="Create a CNYCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CNYCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CNYCurrency",Description = "Reference to CNYCurrency")>] 
         cnycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CNYCurrency = Helper.toCell<CNYCurrency> cnycurrency "CNYCurrency"  
                let builder () = withMnemonic mnemonic ((_CNYCurrency.cell :?> CNYCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CNYCurrency.source + ".NumericCode") 
                                               [| _CNYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CNYCurrency.cell
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
    [<ExcelFunction(Name="_CNYCurrency_rounding", Description="Create a CNYCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CNYCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CNYCurrency",Description = "Reference to CNYCurrency")>] 
         cnycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CNYCurrency = Helper.toCell<CNYCurrency> cnycurrency "CNYCurrency"  
                let builder () = withMnemonic mnemonic ((_CNYCurrency.cell :?> CNYCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_CNYCurrency.source + ".Rounding") 
                                               [| _CNYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CNYCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CNYCurrency> format
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
    [<ExcelFunction(Name="_CNYCurrency_symbol", Description="Create a CNYCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CNYCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CNYCurrency",Description = "Reference to CNYCurrency")>] 
         cnycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CNYCurrency = Helper.toCell<CNYCurrency> cnycurrency "CNYCurrency"  
                let builder () = withMnemonic mnemonic ((_CNYCurrency.cell :?> CNYCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CNYCurrency.source + ".Symbol") 
                                               [| _CNYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CNYCurrency.cell
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
    [<ExcelFunction(Name="_CNYCurrency_ToString", Description="Create a CNYCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CNYCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CNYCurrency",Description = "Reference to CNYCurrency")>] 
         cnycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CNYCurrency = Helper.toCell<CNYCurrency> cnycurrency "CNYCurrency"  
                let builder () = withMnemonic mnemonic ((_CNYCurrency.cell :?> CNYCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CNYCurrency.source + ".ToString") 
                                               [| _CNYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CNYCurrency.cell
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
    [<ExcelFunction(Name="_CNYCurrency_triangulationCurrency", Description="Create a CNYCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CNYCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CNYCurrency",Description = "Reference to CNYCurrency")>] 
         cnycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CNYCurrency = Helper.toCell<CNYCurrency> cnycurrency "CNYCurrency"  
                let builder () = withMnemonic mnemonic ((_CNYCurrency.cell :?> CNYCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_CNYCurrency.source + ".TriangulationCurrency") 
                                               [| _CNYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CNYCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CNYCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_CNYCurrency_Range", Description="Create a range of CNYCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CNYCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CNYCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CNYCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CNYCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CNYCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CNYCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
