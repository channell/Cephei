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
  Peruvian nuevo sol   The ISO three-letter code is PEN; the numeric code is 604. It is divided in 100 centimos.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module PENCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_PENCurrency", Description="Create a PENCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PENCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.PENCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PENCurrency>) l

                let source = Helper.sourceFold "Fun.PENCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PENCurrency> format
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
    [<ExcelFunction(Name="_PENCurrency_code", Description="Create a PENCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PENCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PENCurrency",Description = "Reference to PENCurrency")>] 
         pencurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PENCurrency = Helper.toCell<PENCurrency> pencurrency "PENCurrency"  
                let builder () = withMnemonic mnemonic ((_PENCurrency.cell :?> PENCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PENCurrency.source + ".Code") 
                                               [| _PENCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PENCurrency.cell
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
    [<ExcelFunction(Name="_PENCurrency_empty", Description="Create a PENCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PENCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PENCurrency",Description = "Reference to PENCurrency")>] 
         pencurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PENCurrency = Helper.toCell<PENCurrency> pencurrency "PENCurrency"  
                let builder () = withMnemonic mnemonic ((_PENCurrency.cell :?> PENCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PENCurrency.source + ".Empty") 
                                               [| _PENCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PENCurrency.cell
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
    [<ExcelFunction(Name="_PENCurrency_Equals", Description="Create a PENCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PENCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PENCurrency",Description = "Reference to PENCurrency")>] 
         pencurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PENCurrency = Helper.toCell<PENCurrency> pencurrency "PENCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((_PENCurrency.cell :?> PENCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PENCurrency.source + ".Equals") 
                                               [| _PENCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PENCurrency.cell
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
    [<ExcelFunction(Name="_PENCurrency_format", Description="Create a PENCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PENCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PENCurrency",Description = "Reference to PENCurrency")>] 
         pencurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PENCurrency = Helper.toCell<PENCurrency> pencurrency "PENCurrency"  
                let builder () = withMnemonic mnemonic ((_PENCurrency.cell :?> PENCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PENCurrency.source + ".Format") 
                                               [| _PENCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PENCurrency.cell
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
    [<ExcelFunction(Name="_PENCurrency_fractionsPerUnit", Description="Create a PENCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PENCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PENCurrency",Description = "Reference to PENCurrency")>] 
         pencurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PENCurrency = Helper.toCell<PENCurrency> pencurrency "PENCurrency"  
                let builder () = withMnemonic mnemonic ((_PENCurrency.cell :?> PENCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_PENCurrency.source + ".FractionsPerUnit") 
                                               [| _PENCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PENCurrency.cell
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
    [<ExcelFunction(Name="_PENCurrency_fractionSymbol", Description="Create a PENCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PENCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PENCurrency",Description = "Reference to PENCurrency")>] 
         pencurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PENCurrency = Helper.toCell<PENCurrency> pencurrency "PENCurrency"  
                let builder () = withMnemonic mnemonic ((_PENCurrency.cell :?> PENCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PENCurrency.source + ".FractionSymbol") 
                                               [| _PENCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PENCurrency.cell
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
    [<ExcelFunction(Name="_PENCurrency_name", Description="Create a PENCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PENCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PENCurrency",Description = "Reference to PENCurrency")>] 
         pencurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PENCurrency = Helper.toCell<PENCurrency> pencurrency "PENCurrency"  
                let builder () = withMnemonic mnemonic ((_PENCurrency.cell :?> PENCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PENCurrency.source + ".Name") 
                                               [| _PENCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PENCurrency.cell
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
    [<ExcelFunction(Name="_PENCurrency_numericCode", Description="Create a PENCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PENCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PENCurrency",Description = "Reference to PENCurrency")>] 
         pencurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PENCurrency = Helper.toCell<PENCurrency> pencurrency "PENCurrency"  
                let builder () = withMnemonic mnemonic ((_PENCurrency.cell :?> PENCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_PENCurrency.source + ".NumericCode") 
                                               [| _PENCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PENCurrency.cell
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
    [<ExcelFunction(Name="_PENCurrency_rounding", Description="Create a PENCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PENCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PENCurrency",Description = "Reference to PENCurrency")>] 
         pencurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PENCurrency = Helper.toCell<PENCurrency> pencurrency "PENCurrency"  
                let builder () = withMnemonic mnemonic ((_PENCurrency.cell :?> PENCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_PENCurrency.source + ".Rounding") 
                                               [| _PENCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PENCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PENCurrency> format
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
    [<ExcelFunction(Name="_PENCurrency_symbol", Description="Create a PENCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PENCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PENCurrency",Description = "Reference to PENCurrency")>] 
         pencurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PENCurrency = Helper.toCell<PENCurrency> pencurrency "PENCurrency"  
                let builder () = withMnemonic mnemonic ((_PENCurrency.cell :?> PENCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PENCurrency.source + ".Symbol") 
                                               [| _PENCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PENCurrency.cell
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
    [<ExcelFunction(Name="_PENCurrency_ToString", Description="Create a PENCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PENCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PENCurrency",Description = "Reference to PENCurrency")>] 
         pencurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PENCurrency = Helper.toCell<PENCurrency> pencurrency "PENCurrency"  
                let builder () = withMnemonic mnemonic ((_PENCurrency.cell :?> PENCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PENCurrency.source + ".ToString") 
                                               [| _PENCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PENCurrency.cell
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
    [<ExcelFunction(Name="_PENCurrency_triangulationCurrency", Description="Create a PENCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PENCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PENCurrency",Description = "Reference to PENCurrency")>] 
         pencurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PENCurrency = Helper.toCell<PENCurrency> pencurrency "PENCurrency"  
                let builder () = withMnemonic mnemonic ((_PENCurrency.cell :?> PENCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_PENCurrency.source + ".TriangulationCurrency") 
                                               [| _PENCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PENCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PENCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_PENCurrency_Range", Description="Create a range of PENCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PENCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the PENCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PENCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<PENCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<PENCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<PENCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
