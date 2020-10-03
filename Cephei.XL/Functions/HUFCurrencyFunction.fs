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
module HUFCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_HUFCurrency", Description="Create a HUFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HUFCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.HUFCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<HUFCurrency>) l

                let source = Helper.sourceFold "Fun.HUFCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HUFCurrency> format
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
    [<ExcelFunction(Name="_HUFCurrency_code", Description="Create a HUFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HUFCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HUFCurrency",Description = "Reference to HUFCurrency")>] 
         hufcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HUFCurrency = Helper.toCell<HUFCurrency> hufcurrency "HUFCurrency"  
                let builder () = withMnemonic mnemonic ((HUFCurrencyModel.Cast _HUFCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HUFCurrency.source + ".Code") 
                                               [| _HUFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HUFCurrency.cell
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
    [<ExcelFunction(Name="_HUFCurrency_empty", Description="Create a HUFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HUFCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HUFCurrency",Description = "Reference to HUFCurrency")>] 
         hufcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HUFCurrency = Helper.toCell<HUFCurrency> hufcurrency "HUFCurrency"  
                let builder () = withMnemonic mnemonic ((HUFCurrencyModel.Cast _HUFCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HUFCurrency.source + ".Empty") 
                                               [| _HUFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HUFCurrency.cell
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
    [<ExcelFunction(Name="_HUFCurrency_Equals", Description="Create a HUFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HUFCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HUFCurrency",Description = "Reference to HUFCurrency")>] 
         hufcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HUFCurrency = Helper.toCell<HUFCurrency> hufcurrency "HUFCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((HUFCurrencyModel.Cast _HUFCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HUFCurrency.source + ".Equals") 
                                               [| _HUFCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HUFCurrency.cell
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
    [<ExcelFunction(Name="_HUFCurrency_format", Description="Create a HUFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HUFCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HUFCurrency",Description = "Reference to HUFCurrency")>] 
         hufcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HUFCurrency = Helper.toCell<HUFCurrency> hufcurrency "HUFCurrency"  
                let builder () = withMnemonic mnemonic ((HUFCurrencyModel.Cast _HUFCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HUFCurrency.source + ".Format") 
                                               [| _HUFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HUFCurrency.cell
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
    [<ExcelFunction(Name="_HUFCurrency_fractionsPerUnit", Description="Create a HUFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HUFCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HUFCurrency",Description = "Reference to HUFCurrency")>] 
         hufcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HUFCurrency = Helper.toCell<HUFCurrency> hufcurrency "HUFCurrency"  
                let builder () = withMnemonic mnemonic ((HUFCurrencyModel.Cast _HUFCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_HUFCurrency.source + ".FractionsPerUnit") 
                                               [| _HUFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HUFCurrency.cell
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
    [<ExcelFunction(Name="_HUFCurrency_fractionSymbol", Description="Create a HUFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HUFCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HUFCurrency",Description = "Reference to HUFCurrency")>] 
         hufcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HUFCurrency = Helper.toCell<HUFCurrency> hufcurrency "HUFCurrency"  
                let builder () = withMnemonic mnemonic ((HUFCurrencyModel.Cast _HUFCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HUFCurrency.source + ".FractionSymbol") 
                                               [| _HUFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HUFCurrency.cell
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
    [<ExcelFunction(Name="_HUFCurrency_name", Description="Create a HUFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HUFCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HUFCurrency",Description = "Reference to HUFCurrency")>] 
         hufcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HUFCurrency = Helper.toCell<HUFCurrency> hufcurrency "HUFCurrency"  
                let builder () = withMnemonic mnemonic ((HUFCurrencyModel.Cast _HUFCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HUFCurrency.source + ".Name") 
                                               [| _HUFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HUFCurrency.cell
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
    [<ExcelFunction(Name="_HUFCurrency_numericCode", Description="Create a HUFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HUFCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HUFCurrency",Description = "Reference to HUFCurrency")>] 
         hufcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HUFCurrency = Helper.toCell<HUFCurrency> hufcurrency "HUFCurrency"  
                let builder () = withMnemonic mnemonic ((HUFCurrencyModel.Cast _HUFCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_HUFCurrency.source + ".NumericCode") 
                                               [| _HUFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HUFCurrency.cell
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
    [<ExcelFunction(Name="_HUFCurrency_rounding", Description="Create a HUFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HUFCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HUFCurrency",Description = "Reference to HUFCurrency")>] 
         hufcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HUFCurrency = Helper.toCell<HUFCurrency> hufcurrency "HUFCurrency"  
                let builder () = withMnemonic mnemonic ((HUFCurrencyModel.Cast _HUFCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_HUFCurrency.source + ".Rounding") 
                                               [| _HUFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HUFCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HUFCurrency> format
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
    [<ExcelFunction(Name="_HUFCurrency_symbol", Description="Create a HUFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HUFCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HUFCurrency",Description = "Reference to HUFCurrency")>] 
         hufcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HUFCurrency = Helper.toCell<HUFCurrency> hufcurrency "HUFCurrency"  
                let builder () = withMnemonic mnemonic ((HUFCurrencyModel.Cast _HUFCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HUFCurrency.source + ".Symbol") 
                                               [| _HUFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HUFCurrency.cell
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
    [<ExcelFunction(Name="_HUFCurrency_ToString", Description="Create a HUFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HUFCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HUFCurrency",Description = "Reference to HUFCurrency")>] 
         hufcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HUFCurrency = Helper.toCell<HUFCurrency> hufcurrency "HUFCurrency"  
                let builder () = withMnemonic mnemonic ((HUFCurrencyModel.Cast _HUFCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HUFCurrency.source + ".ToString") 
                                               [| _HUFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HUFCurrency.cell
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
    [<ExcelFunction(Name="_HUFCurrency_triangulationCurrency", Description="Create a HUFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HUFCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HUFCurrency",Description = "Reference to HUFCurrency")>] 
         hufcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HUFCurrency = Helper.toCell<HUFCurrency> hufcurrency "HUFCurrency"  
                let builder () = withMnemonic mnemonic ((HUFCurrencyModel.Cast _HUFCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_HUFCurrency.source + ".TriangulationCurrency") 
                                               [| _HUFCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HUFCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HUFCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_HUFCurrency_Range", Description="Create a range of HUFCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HUFCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the HUFCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<HUFCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<HUFCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<HUFCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<HUFCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
