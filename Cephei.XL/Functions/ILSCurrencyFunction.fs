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
  The ISO three-letter code is ILS; the numeric code is 376. It is divided in 100 agorot.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module ILSCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ILSCurrency", Description="Create a ILSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ILSCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.ILSCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ILSCurrency>) l

                let source = Helper.sourceFold "Fun.ILSCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
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
    [<ExcelFunction(Name="_ILSCurrency_code", Description="Create a ILSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ILSCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ILSCurrency",Description = "Reference to ILSCurrency")>] 
         ilscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ILSCurrency = Helper.toCell<ILSCurrency> ilscurrency "ILSCurrency" true 
                let builder () = withMnemonic mnemonic ((_ILSCurrency.cell :?> ILSCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ILSCurrency.source + ".Code") 
                                               [| _ILSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ILSCurrency.cell
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
    [<ExcelFunction(Name="_ILSCurrency_empty", Description="Create a ILSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ILSCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ILSCurrency",Description = "Reference to ILSCurrency")>] 
         ilscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ILSCurrency = Helper.toCell<ILSCurrency> ilscurrency "ILSCurrency" true 
                let builder () = withMnemonic mnemonic ((_ILSCurrency.cell :?> ILSCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ILSCurrency.source + ".Empty") 
                                               [| _ILSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ILSCurrency.cell
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
    [<ExcelFunction(Name="_ILSCurrency_Equals", Description="Create a ILSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ILSCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ILSCurrency",Description = "Reference to ILSCurrency")>] 
         ilscurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ILSCurrency = Helper.toCell<ILSCurrency> ilscurrency "ILSCurrency" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_ILSCurrency.cell :?> ILSCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ILSCurrency.source + ".Equals") 
                                               [| _ILSCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ILSCurrency.cell
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
    [<ExcelFunction(Name="_ILSCurrency_format", Description="Create a ILSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ILSCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ILSCurrency",Description = "Reference to ILSCurrency")>] 
         ilscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ILSCurrency = Helper.toCell<ILSCurrency> ilscurrency "ILSCurrency" true 
                let builder () = withMnemonic mnemonic ((_ILSCurrency.cell :?> ILSCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ILSCurrency.source + ".Format") 
                                               [| _ILSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ILSCurrency.cell
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
    [<ExcelFunction(Name="_ILSCurrency_fractionsPerUnit", Description="Create a ILSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ILSCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ILSCurrency",Description = "Reference to ILSCurrency")>] 
         ilscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ILSCurrency = Helper.toCell<ILSCurrency> ilscurrency "ILSCurrency" true 
                let builder () = withMnemonic mnemonic ((_ILSCurrency.cell :?> ILSCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ILSCurrency.source + ".FractionsPerUnit") 
                                               [| _ILSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ILSCurrency.cell
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
    [<ExcelFunction(Name="_ILSCurrency_fractionSymbol", Description="Create a ILSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ILSCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ILSCurrency",Description = "Reference to ILSCurrency")>] 
         ilscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ILSCurrency = Helper.toCell<ILSCurrency> ilscurrency "ILSCurrency" true 
                let builder () = withMnemonic mnemonic ((_ILSCurrency.cell :?> ILSCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ILSCurrency.source + ".FractionSymbol") 
                                               [| _ILSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ILSCurrency.cell
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
    [<ExcelFunction(Name="_ILSCurrency_name", Description="Create a ILSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ILSCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ILSCurrency",Description = "Reference to ILSCurrency")>] 
         ilscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ILSCurrency = Helper.toCell<ILSCurrency> ilscurrency "ILSCurrency" true 
                let builder () = withMnemonic mnemonic ((_ILSCurrency.cell :?> ILSCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ILSCurrency.source + ".Name") 
                                               [| _ILSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ILSCurrency.cell
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
    [<ExcelFunction(Name="_ILSCurrency_numericCode", Description="Create a ILSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ILSCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ILSCurrency",Description = "Reference to ILSCurrency")>] 
         ilscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ILSCurrency = Helper.toCell<ILSCurrency> ilscurrency "ILSCurrency" true 
                let builder () = withMnemonic mnemonic ((_ILSCurrency.cell :?> ILSCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ILSCurrency.source + ".NumericCode") 
                                               [| _ILSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ILSCurrency.cell
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
    [<ExcelFunction(Name="_ILSCurrency_rounding", Description="Create a ILSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ILSCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ILSCurrency",Description = "Reference to ILSCurrency")>] 
         ilscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ILSCurrency = Helper.toCell<ILSCurrency> ilscurrency "ILSCurrency" true 
                let builder () = withMnemonic mnemonic ((_ILSCurrency.cell :?> ILSCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_ILSCurrency.source + ".Rounding") 
                                               [| _ILSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ILSCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
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
    [<ExcelFunction(Name="_ILSCurrency_symbol", Description="Create a ILSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ILSCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ILSCurrency",Description = "Reference to ILSCurrency")>] 
         ilscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ILSCurrency = Helper.toCell<ILSCurrency> ilscurrency "ILSCurrency" true 
                let builder () = withMnemonic mnemonic ((_ILSCurrency.cell :?> ILSCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ILSCurrency.source + ".Symbol") 
                                               [| _ILSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ILSCurrency.cell
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
    [<ExcelFunction(Name="_ILSCurrency_ToString", Description="Create a ILSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ILSCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ILSCurrency",Description = "Reference to ILSCurrency")>] 
         ilscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ILSCurrency = Helper.toCell<ILSCurrency> ilscurrency "ILSCurrency" true 
                let builder () = withMnemonic mnemonic ((_ILSCurrency.cell :?> ILSCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ILSCurrency.source + ".ToString") 
                                               [| _ILSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ILSCurrency.cell
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
    [<ExcelFunction(Name="_ILSCurrency_triangulationCurrency", Description="Create a ILSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ILSCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ILSCurrency",Description = "Reference to ILSCurrency")>] 
         ilscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ILSCurrency = Helper.toCell<ILSCurrency> ilscurrency "ILSCurrency" true 
                let builder () = withMnemonic mnemonic ((_ILSCurrency.cell :?> ILSCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_ILSCurrency.source + ".TriangulationCurrency") 
                                               [| _ILSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ILSCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_ILSCurrency_Range", Description="Create a range of ILSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ILSCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ILSCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ILSCurrency> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ILSCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ILSCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ILSCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
