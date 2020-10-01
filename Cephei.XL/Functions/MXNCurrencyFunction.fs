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
  Mexican peso   The ISO three-letter code is MXN; the numeric code is 484. It is divided in 100 centavos.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module MXNCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_MXNCurrency", Description="Create a MXNCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MXNCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.MXNCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MXNCurrency>) l

                let source = Helper.sourceFold "Fun.MXNCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MXNCurrency> format
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
    [<ExcelFunction(Name="_MXNCurrency_code", Description="Create a MXNCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MXNCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MXNCurrency",Description = "Reference to MXNCurrency")>] 
         mxncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MXNCurrency = Helper.toCell<MXNCurrency> mxncurrency "MXNCurrency"  
                let builder () = withMnemonic mnemonic ((_MXNCurrency.cell :?> MXNCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MXNCurrency.source + ".Code") 
                                               [| _MXNCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MXNCurrency.cell
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
    [<ExcelFunction(Name="_MXNCurrency_empty", Description="Create a MXNCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MXNCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MXNCurrency",Description = "Reference to MXNCurrency")>] 
         mxncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MXNCurrency = Helper.toCell<MXNCurrency> mxncurrency "MXNCurrency"  
                let builder () = withMnemonic mnemonic ((_MXNCurrency.cell :?> MXNCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MXNCurrency.source + ".Empty") 
                                               [| _MXNCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MXNCurrency.cell
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
    [<ExcelFunction(Name="_MXNCurrency_Equals", Description="Create a MXNCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MXNCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MXNCurrency",Description = "Reference to MXNCurrency")>] 
         mxncurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MXNCurrency = Helper.toCell<MXNCurrency> mxncurrency "MXNCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((_MXNCurrency.cell :?> MXNCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MXNCurrency.source + ".Equals") 
                                               [| _MXNCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MXNCurrency.cell
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
    [<ExcelFunction(Name="_MXNCurrency_format", Description="Create a MXNCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MXNCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MXNCurrency",Description = "Reference to MXNCurrency")>] 
         mxncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MXNCurrency = Helper.toCell<MXNCurrency> mxncurrency "MXNCurrency"  
                let builder () = withMnemonic mnemonic ((_MXNCurrency.cell :?> MXNCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MXNCurrency.source + ".Format") 
                                               [| _MXNCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MXNCurrency.cell
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
    [<ExcelFunction(Name="_MXNCurrency_fractionsPerUnit", Description="Create a MXNCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MXNCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MXNCurrency",Description = "Reference to MXNCurrency")>] 
         mxncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MXNCurrency = Helper.toCell<MXNCurrency> mxncurrency "MXNCurrency"  
                let builder () = withMnemonic mnemonic ((_MXNCurrency.cell :?> MXNCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_MXNCurrency.source + ".FractionsPerUnit") 
                                               [| _MXNCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MXNCurrency.cell
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
    [<ExcelFunction(Name="_MXNCurrency_fractionSymbol", Description="Create a MXNCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MXNCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MXNCurrency",Description = "Reference to MXNCurrency")>] 
         mxncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MXNCurrency = Helper.toCell<MXNCurrency> mxncurrency "MXNCurrency"  
                let builder () = withMnemonic mnemonic ((_MXNCurrency.cell :?> MXNCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MXNCurrency.source + ".FractionSymbol") 
                                               [| _MXNCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MXNCurrency.cell
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
    [<ExcelFunction(Name="_MXNCurrency_name", Description="Create a MXNCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MXNCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MXNCurrency",Description = "Reference to MXNCurrency")>] 
         mxncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MXNCurrency = Helper.toCell<MXNCurrency> mxncurrency "MXNCurrency"  
                let builder () = withMnemonic mnemonic ((_MXNCurrency.cell :?> MXNCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MXNCurrency.source + ".Name") 
                                               [| _MXNCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MXNCurrency.cell
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
    [<ExcelFunction(Name="_MXNCurrency_numericCode", Description="Create a MXNCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MXNCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MXNCurrency",Description = "Reference to MXNCurrency")>] 
         mxncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MXNCurrency = Helper.toCell<MXNCurrency> mxncurrency "MXNCurrency"  
                let builder () = withMnemonic mnemonic ((_MXNCurrency.cell :?> MXNCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_MXNCurrency.source + ".NumericCode") 
                                               [| _MXNCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MXNCurrency.cell
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
    [<ExcelFunction(Name="_MXNCurrency_rounding", Description="Create a MXNCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MXNCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MXNCurrency",Description = "Reference to MXNCurrency")>] 
         mxncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MXNCurrency = Helper.toCell<MXNCurrency> mxncurrency "MXNCurrency"  
                let builder () = withMnemonic mnemonic ((_MXNCurrency.cell :?> MXNCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_MXNCurrency.source + ".Rounding") 
                                               [| _MXNCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MXNCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MXNCurrency> format
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
    [<ExcelFunction(Name="_MXNCurrency_symbol", Description="Create a MXNCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MXNCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MXNCurrency",Description = "Reference to MXNCurrency")>] 
         mxncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MXNCurrency = Helper.toCell<MXNCurrency> mxncurrency "MXNCurrency"  
                let builder () = withMnemonic mnemonic ((_MXNCurrency.cell :?> MXNCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MXNCurrency.source + ".Symbol") 
                                               [| _MXNCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MXNCurrency.cell
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
    [<ExcelFunction(Name="_MXNCurrency_ToString", Description="Create a MXNCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MXNCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MXNCurrency",Description = "Reference to MXNCurrency")>] 
         mxncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MXNCurrency = Helper.toCell<MXNCurrency> mxncurrency "MXNCurrency"  
                let builder () = withMnemonic mnemonic ((_MXNCurrency.cell :?> MXNCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MXNCurrency.source + ".ToString") 
                                               [| _MXNCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MXNCurrency.cell
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
    [<ExcelFunction(Name="_MXNCurrency_triangulationCurrency", Description="Create a MXNCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MXNCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MXNCurrency",Description = "Reference to MXNCurrency")>] 
         mxncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MXNCurrency = Helper.toCell<MXNCurrency> mxncurrency "MXNCurrency"  
                let builder () = withMnemonic mnemonic ((_MXNCurrency.cell :?> MXNCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_MXNCurrency.source + ".TriangulationCurrency") 
                                               [| _MXNCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MXNCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MXNCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_MXNCurrency_Range", Description="Create a range of MXNCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MXNCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the MXNCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MXNCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<MXNCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<MXNCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<MXNCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
