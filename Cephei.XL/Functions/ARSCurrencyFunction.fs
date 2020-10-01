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
  Argentinian peso   The ISO three-letter code is ARS; the numeric code is 32. It is divided in 100 centavos.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module ARSCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ARSCurrency", Description="Create a ARSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ARSCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.ARSCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ARSCurrency>) l

                let source = Helper.sourceFold "Fun.ARSCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ARSCurrency> format
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
    [<ExcelFunction(Name="_ARSCurrency_code", Description="Create a ARSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ARSCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ARSCurrency",Description = "Reference to ARSCurrency")>] 
         arscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ARSCurrency = Helper.toCell<ARSCurrency> arscurrency "ARSCurrency"  
                let builder () = withMnemonic mnemonic ((_ARSCurrency.cell :?> ARSCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ARSCurrency.source + ".Code") 
                                               [| _ARSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ARSCurrency.cell
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
    [<ExcelFunction(Name="_ARSCurrency_empty", Description="Create a ARSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ARSCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ARSCurrency",Description = "Reference to ARSCurrency")>] 
         arscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ARSCurrency = Helper.toCell<ARSCurrency> arscurrency "ARSCurrency"  
                let builder () = withMnemonic mnemonic ((_ARSCurrency.cell :?> ARSCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ARSCurrency.source + ".Empty") 
                                               [| _ARSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ARSCurrency.cell
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
    [<ExcelFunction(Name="_ARSCurrency_Equals", Description="Create a ARSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ARSCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ARSCurrency",Description = "Reference to ARSCurrency")>] 
         arscurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ARSCurrency = Helper.toCell<ARSCurrency> arscurrency "ARSCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((_ARSCurrency.cell :?> ARSCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ARSCurrency.source + ".Equals") 
                                               [| _ARSCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ARSCurrency.cell
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
    [<ExcelFunction(Name="_ARSCurrency_format", Description="Create a ARSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ARSCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ARSCurrency",Description = "Reference to ARSCurrency")>] 
         arscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ARSCurrency = Helper.toCell<ARSCurrency> arscurrency "ARSCurrency"  
                let builder () = withMnemonic mnemonic ((_ARSCurrency.cell :?> ARSCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ARSCurrency.source + ".Format") 
                                               [| _ARSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ARSCurrency.cell
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
    [<ExcelFunction(Name="_ARSCurrency_fractionsPerUnit", Description="Create a ARSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ARSCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ARSCurrency",Description = "Reference to ARSCurrency")>] 
         arscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ARSCurrency = Helper.toCell<ARSCurrency> arscurrency "ARSCurrency"  
                let builder () = withMnemonic mnemonic ((_ARSCurrency.cell :?> ARSCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ARSCurrency.source + ".FractionsPerUnit") 
                                               [| _ARSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ARSCurrency.cell
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
    [<ExcelFunction(Name="_ARSCurrency_fractionSymbol", Description="Create a ARSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ARSCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ARSCurrency",Description = "Reference to ARSCurrency")>] 
         arscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ARSCurrency = Helper.toCell<ARSCurrency> arscurrency "ARSCurrency"  
                let builder () = withMnemonic mnemonic ((_ARSCurrency.cell :?> ARSCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ARSCurrency.source + ".FractionSymbol") 
                                               [| _ARSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ARSCurrency.cell
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
    [<ExcelFunction(Name="_ARSCurrency_name", Description="Create a ARSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ARSCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ARSCurrency",Description = "Reference to ARSCurrency")>] 
         arscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ARSCurrency = Helper.toCell<ARSCurrency> arscurrency "ARSCurrency"  
                let builder () = withMnemonic mnemonic ((_ARSCurrency.cell :?> ARSCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ARSCurrency.source + ".Name") 
                                               [| _ARSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ARSCurrency.cell
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
    [<ExcelFunction(Name="_ARSCurrency_numericCode", Description="Create a ARSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ARSCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ARSCurrency",Description = "Reference to ARSCurrency")>] 
         arscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ARSCurrency = Helper.toCell<ARSCurrency> arscurrency "ARSCurrency"  
                let builder () = withMnemonic mnemonic ((_ARSCurrency.cell :?> ARSCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ARSCurrency.source + ".NumericCode") 
                                               [| _ARSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ARSCurrency.cell
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
    [<ExcelFunction(Name="_ARSCurrency_rounding", Description="Create a ARSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ARSCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ARSCurrency",Description = "Reference to ARSCurrency")>] 
         arscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ARSCurrency = Helper.toCell<ARSCurrency> arscurrency "ARSCurrency"  
                let builder () = withMnemonic mnemonic ((_ARSCurrency.cell :?> ARSCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_ARSCurrency.source + ".Rounding") 
                                               [| _ARSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ARSCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ARSCurrency> format
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
    [<ExcelFunction(Name="_ARSCurrency_symbol", Description="Create a ARSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ARSCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ARSCurrency",Description = "Reference to ARSCurrency")>] 
         arscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ARSCurrency = Helper.toCell<ARSCurrency> arscurrency "ARSCurrency"  
                let builder () = withMnemonic mnemonic ((_ARSCurrency.cell :?> ARSCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ARSCurrency.source + ".Symbol") 
                                               [| _ARSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ARSCurrency.cell
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
    [<ExcelFunction(Name="_ARSCurrency_ToString", Description="Create a ARSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ARSCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ARSCurrency",Description = "Reference to ARSCurrency")>] 
         arscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ARSCurrency = Helper.toCell<ARSCurrency> arscurrency "ARSCurrency"  
                let builder () = withMnemonic mnemonic ((_ARSCurrency.cell :?> ARSCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ARSCurrency.source + ".ToString") 
                                               [| _ARSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ARSCurrency.cell
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
    [<ExcelFunction(Name="_ARSCurrency_triangulationCurrency", Description="Create a ARSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ARSCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ARSCurrency",Description = "Reference to ARSCurrency")>] 
         arscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ARSCurrency = Helper.toCell<ARSCurrency> arscurrency "ARSCurrency"  
                let builder () = withMnemonic mnemonic ((_ARSCurrency.cell :?> ARSCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_ARSCurrency.source + ".TriangulationCurrency") 
                                               [| _ARSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ARSCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ARSCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_ARSCurrency_Range", Description="Create a range of ARSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ARSCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ARSCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ARSCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ARSCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ARSCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ARSCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
