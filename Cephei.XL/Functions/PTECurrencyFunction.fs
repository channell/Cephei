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
module PTECurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_PTECurrency", Description="Create a PTECurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PTECurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.PTECurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PTECurrency>) l

                let source = Helper.sourceFold "Fun.PTECurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PTECurrency> format
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
    [<ExcelFunction(Name="_PTECurrency_code", Description="Create a PTECurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PTECurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PTECurrency",Description = "Reference to PTECurrency")>] 
         ptecurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PTECurrency = Helper.toCell<PTECurrency> ptecurrency "PTECurrency"  
                let builder () = withMnemonic mnemonic ((_PTECurrency.cell :?> PTECurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PTECurrency.source + ".Code") 
                                               [| _PTECurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PTECurrency.cell
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
    [<ExcelFunction(Name="_PTECurrency_empty", Description="Create a PTECurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PTECurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PTECurrency",Description = "Reference to PTECurrency")>] 
         ptecurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PTECurrency = Helper.toCell<PTECurrency> ptecurrency "PTECurrency"  
                let builder () = withMnemonic mnemonic ((_PTECurrency.cell :?> PTECurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PTECurrency.source + ".Empty") 
                                               [| _PTECurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PTECurrency.cell
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
    [<ExcelFunction(Name="_PTECurrency_Equals", Description="Create a PTECurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PTECurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PTECurrency",Description = "Reference to PTECurrency")>] 
         ptecurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PTECurrency = Helper.toCell<PTECurrency> ptecurrency "PTECurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((_PTECurrency.cell :?> PTECurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PTECurrency.source + ".Equals") 
                                               [| _PTECurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PTECurrency.cell
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
    [<ExcelFunction(Name="_PTECurrency_format", Description="Create a PTECurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PTECurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PTECurrency",Description = "Reference to PTECurrency")>] 
         ptecurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PTECurrency = Helper.toCell<PTECurrency> ptecurrency "PTECurrency"  
                let builder () = withMnemonic mnemonic ((_PTECurrency.cell :?> PTECurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PTECurrency.source + ".Format") 
                                               [| _PTECurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PTECurrency.cell
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
    [<ExcelFunction(Name="_PTECurrency_fractionsPerUnit", Description="Create a PTECurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PTECurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PTECurrency",Description = "Reference to PTECurrency")>] 
         ptecurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PTECurrency = Helper.toCell<PTECurrency> ptecurrency "PTECurrency"  
                let builder () = withMnemonic mnemonic ((_PTECurrency.cell :?> PTECurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_PTECurrency.source + ".FractionsPerUnit") 
                                               [| _PTECurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PTECurrency.cell
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
    [<ExcelFunction(Name="_PTECurrency_fractionSymbol", Description="Create a PTECurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PTECurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PTECurrency",Description = "Reference to PTECurrency")>] 
         ptecurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PTECurrency = Helper.toCell<PTECurrency> ptecurrency "PTECurrency"  
                let builder () = withMnemonic mnemonic ((_PTECurrency.cell :?> PTECurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PTECurrency.source + ".FractionSymbol") 
                                               [| _PTECurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PTECurrency.cell
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
    [<ExcelFunction(Name="_PTECurrency_name", Description="Create a PTECurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PTECurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PTECurrency",Description = "Reference to PTECurrency")>] 
         ptecurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PTECurrency = Helper.toCell<PTECurrency> ptecurrency "PTECurrency"  
                let builder () = withMnemonic mnemonic ((_PTECurrency.cell :?> PTECurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PTECurrency.source + ".Name") 
                                               [| _PTECurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PTECurrency.cell
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
    [<ExcelFunction(Name="_PTECurrency_numericCode", Description="Create a PTECurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PTECurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PTECurrency",Description = "Reference to PTECurrency")>] 
         ptecurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PTECurrency = Helper.toCell<PTECurrency> ptecurrency "PTECurrency"  
                let builder () = withMnemonic mnemonic ((_PTECurrency.cell :?> PTECurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_PTECurrency.source + ".NumericCode") 
                                               [| _PTECurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PTECurrency.cell
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
    [<ExcelFunction(Name="_PTECurrency_rounding", Description="Create a PTECurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PTECurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PTECurrency",Description = "Reference to PTECurrency")>] 
         ptecurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PTECurrency = Helper.toCell<PTECurrency> ptecurrency "PTECurrency"  
                let builder () = withMnemonic mnemonic ((_PTECurrency.cell :?> PTECurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_PTECurrency.source + ".Rounding") 
                                               [| _PTECurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PTECurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PTECurrency> format
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
    [<ExcelFunction(Name="_PTECurrency_symbol", Description="Create a PTECurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PTECurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PTECurrency",Description = "Reference to PTECurrency")>] 
         ptecurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PTECurrency = Helper.toCell<PTECurrency> ptecurrency "PTECurrency"  
                let builder () = withMnemonic mnemonic ((_PTECurrency.cell :?> PTECurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PTECurrency.source + ".Symbol") 
                                               [| _PTECurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PTECurrency.cell
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
    [<ExcelFunction(Name="_PTECurrency_ToString", Description="Create a PTECurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PTECurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PTECurrency",Description = "Reference to PTECurrency")>] 
         ptecurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PTECurrency = Helper.toCell<PTECurrency> ptecurrency "PTECurrency"  
                let builder () = withMnemonic mnemonic ((_PTECurrency.cell :?> PTECurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PTECurrency.source + ".ToString") 
                                               [| _PTECurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PTECurrency.cell
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
    [<ExcelFunction(Name="_PTECurrency_triangulationCurrency", Description="Create a PTECurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PTECurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PTECurrency",Description = "Reference to PTECurrency")>] 
         ptecurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PTECurrency = Helper.toCell<PTECurrency> ptecurrency "PTECurrency"  
                let builder () = withMnemonic mnemonic ((_PTECurrency.cell :?> PTECurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_PTECurrency.source + ".TriangulationCurrency") 
                                               [| _PTECurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PTECurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PTECurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_PTECurrency_Range", Description="Create a range of PTECurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PTECurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the PTECurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PTECurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<PTECurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<PTECurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<PTECurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
