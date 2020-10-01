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
module PLNCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_PLNCurrency", Description="Create a PLNCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PLNCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.PLNCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PLNCurrency>) l

                let source = Helper.sourceFold "Fun.PLNCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PLNCurrency> format
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
    [<ExcelFunction(Name="_PLNCurrency_code", Description="Create a PLNCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PLNCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PLNCurrency",Description = "Reference to PLNCurrency")>] 
         plncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PLNCurrency = Helper.toCell<PLNCurrency> plncurrency "PLNCurrency"  
                let builder () = withMnemonic mnemonic ((_PLNCurrency.cell :?> PLNCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PLNCurrency.source + ".Code") 
                                               [| _PLNCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PLNCurrency.cell
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
    [<ExcelFunction(Name="_PLNCurrency_empty", Description="Create a PLNCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PLNCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PLNCurrency",Description = "Reference to PLNCurrency")>] 
         plncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PLNCurrency = Helper.toCell<PLNCurrency> plncurrency "PLNCurrency"  
                let builder () = withMnemonic mnemonic ((_PLNCurrency.cell :?> PLNCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PLNCurrency.source + ".Empty") 
                                               [| _PLNCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PLNCurrency.cell
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
    [<ExcelFunction(Name="_PLNCurrency_Equals", Description="Create a PLNCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PLNCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PLNCurrency",Description = "Reference to PLNCurrency")>] 
         plncurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PLNCurrency = Helper.toCell<PLNCurrency> plncurrency "PLNCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((_PLNCurrency.cell :?> PLNCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PLNCurrency.source + ".Equals") 
                                               [| _PLNCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PLNCurrency.cell
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
    [<ExcelFunction(Name="_PLNCurrency_format", Description="Create a PLNCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PLNCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PLNCurrency",Description = "Reference to PLNCurrency")>] 
         plncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PLNCurrency = Helper.toCell<PLNCurrency> plncurrency "PLNCurrency"  
                let builder () = withMnemonic mnemonic ((_PLNCurrency.cell :?> PLNCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PLNCurrency.source + ".Format") 
                                               [| _PLNCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PLNCurrency.cell
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
    [<ExcelFunction(Name="_PLNCurrency_fractionsPerUnit", Description="Create a PLNCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PLNCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PLNCurrency",Description = "Reference to PLNCurrency")>] 
         plncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PLNCurrency = Helper.toCell<PLNCurrency> plncurrency "PLNCurrency"  
                let builder () = withMnemonic mnemonic ((_PLNCurrency.cell :?> PLNCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_PLNCurrency.source + ".FractionsPerUnit") 
                                               [| _PLNCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PLNCurrency.cell
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
    [<ExcelFunction(Name="_PLNCurrency_fractionSymbol", Description="Create a PLNCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PLNCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PLNCurrency",Description = "Reference to PLNCurrency")>] 
         plncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PLNCurrency = Helper.toCell<PLNCurrency> plncurrency "PLNCurrency"  
                let builder () = withMnemonic mnemonic ((_PLNCurrency.cell :?> PLNCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PLNCurrency.source + ".FractionSymbol") 
                                               [| _PLNCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PLNCurrency.cell
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
    [<ExcelFunction(Name="_PLNCurrency_name", Description="Create a PLNCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PLNCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PLNCurrency",Description = "Reference to PLNCurrency")>] 
         plncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PLNCurrency = Helper.toCell<PLNCurrency> plncurrency "PLNCurrency"  
                let builder () = withMnemonic mnemonic ((_PLNCurrency.cell :?> PLNCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PLNCurrency.source + ".Name") 
                                               [| _PLNCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PLNCurrency.cell
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
    [<ExcelFunction(Name="_PLNCurrency_numericCode", Description="Create a PLNCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PLNCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PLNCurrency",Description = "Reference to PLNCurrency")>] 
         plncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PLNCurrency = Helper.toCell<PLNCurrency> plncurrency "PLNCurrency"  
                let builder () = withMnemonic mnemonic ((_PLNCurrency.cell :?> PLNCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_PLNCurrency.source + ".NumericCode") 
                                               [| _PLNCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PLNCurrency.cell
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
    [<ExcelFunction(Name="_PLNCurrency_rounding", Description="Create a PLNCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PLNCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PLNCurrency",Description = "Reference to PLNCurrency")>] 
         plncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PLNCurrency = Helper.toCell<PLNCurrency> plncurrency "PLNCurrency"  
                let builder () = withMnemonic mnemonic ((_PLNCurrency.cell :?> PLNCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_PLNCurrency.source + ".Rounding") 
                                               [| _PLNCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PLNCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PLNCurrency> format
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
    [<ExcelFunction(Name="_PLNCurrency_symbol", Description="Create a PLNCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PLNCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PLNCurrency",Description = "Reference to PLNCurrency")>] 
         plncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PLNCurrency = Helper.toCell<PLNCurrency> plncurrency "PLNCurrency"  
                let builder () = withMnemonic mnemonic ((_PLNCurrency.cell :?> PLNCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PLNCurrency.source + ".Symbol") 
                                               [| _PLNCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PLNCurrency.cell
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
    [<ExcelFunction(Name="_PLNCurrency_ToString", Description="Create a PLNCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PLNCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PLNCurrency",Description = "Reference to PLNCurrency")>] 
         plncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PLNCurrency = Helper.toCell<PLNCurrency> plncurrency "PLNCurrency"  
                let builder () = withMnemonic mnemonic ((_PLNCurrency.cell :?> PLNCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PLNCurrency.source + ".ToString") 
                                               [| _PLNCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PLNCurrency.cell
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
    [<ExcelFunction(Name="_PLNCurrency_triangulationCurrency", Description="Create a PLNCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PLNCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PLNCurrency",Description = "Reference to PLNCurrency")>] 
         plncurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PLNCurrency = Helper.toCell<PLNCurrency> plncurrency "PLNCurrency"  
                let builder () = withMnemonic mnemonic ((_PLNCurrency.cell :?> PLNCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_PLNCurrency.source + ".TriangulationCurrency") 
                                               [| _PLNCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PLNCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PLNCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_PLNCurrency_Range", Description="Create a range of PLNCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PLNCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the PLNCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PLNCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<PLNCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<PLNCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<PLNCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
