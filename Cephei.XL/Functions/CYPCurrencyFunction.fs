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
module CYPCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CYPCurrency", Description="Create a CYPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CYPCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.CYPCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CYPCurrency>) l

                let source = Helper.sourceFold "Fun.CYPCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CYPCurrency> format
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
    [<ExcelFunction(Name="_CYPCurrency_code", Description="Create a CYPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CYPCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CYPCurrency",Description = "Reference to CYPCurrency")>] 
         cypcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CYPCurrency = Helper.toCell<CYPCurrency> cypcurrency "CYPCurrency"  
                let builder () = withMnemonic mnemonic ((CYPCurrencyModel.Cast _CYPCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CYPCurrency.source + ".Code") 
                                               [| _CYPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CYPCurrency.cell
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
    [<ExcelFunction(Name="_CYPCurrency_empty", Description="Create a CYPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CYPCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CYPCurrency",Description = "Reference to CYPCurrency")>] 
         cypcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CYPCurrency = Helper.toCell<CYPCurrency> cypcurrency "CYPCurrency"  
                let builder () = withMnemonic mnemonic ((CYPCurrencyModel.Cast _CYPCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CYPCurrency.source + ".Empty") 
                                               [| _CYPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CYPCurrency.cell
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
    [<ExcelFunction(Name="_CYPCurrency_Equals", Description="Create a CYPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CYPCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CYPCurrency",Description = "Reference to CYPCurrency")>] 
         cypcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CYPCurrency = Helper.toCell<CYPCurrency> cypcurrency "CYPCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((CYPCurrencyModel.Cast _CYPCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CYPCurrency.source + ".Equals") 
                                               [| _CYPCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CYPCurrency.cell
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
    [<ExcelFunction(Name="_CYPCurrency_format", Description="Create a CYPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CYPCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CYPCurrency",Description = "Reference to CYPCurrency")>] 
         cypcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CYPCurrency = Helper.toCell<CYPCurrency> cypcurrency "CYPCurrency"  
                let builder () = withMnemonic mnemonic ((CYPCurrencyModel.Cast _CYPCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CYPCurrency.source + ".Format") 
                                               [| _CYPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CYPCurrency.cell
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
    [<ExcelFunction(Name="_CYPCurrency_fractionsPerUnit", Description="Create a CYPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CYPCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CYPCurrency",Description = "Reference to CYPCurrency")>] 
         cypcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CYPCurrency = Helper.toCell<CYPCurrency> cypcurrency "CYPCurrency"  
                let builder () = withMnemonic mnemonic ((CYPCurrencyModel.Cast _CYPCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CYPCurrency.source + ".FractionsPerUnit") 
                                               [| _CYPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CYPCurrency.cell
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
    [<ExcelFunction(Name="_CYPCurrency_fractionSymbol", Description="Create a CYPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CYPCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CYPCurrency",Description = "Reference to CYPCurrency")>] 
         cypcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CYPCurrency = Helper.toCell<CYPCurrency> cypcurrency "CYPCurrency"  
                let builder () = withMnemonic mnemonic ((CYPCurrencyModel.Cast _CYPCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CYPCurrency.source + ".FractionSymbol") 
                                               [| _CYPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CYPCurrency.cell
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
    [<ExcelFunction(Name="_CYPCurrency_name", Description="Create a CYPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CYPCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CYPCurrency",Description = "Reference to CYPCurrency")>] 
         cypcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CYPCurrency = Helper.toCell<CYPCurrency> cypcurrency "CYPCurrency"  
                let builder () = withMnemonic mnemonic ((CYPCurrencyModel.Cast _CYPCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CYPCurrency.source + ".Name") 
                                               [| _CYPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CYPCurrency.cell
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
    [<ExcelFunction(Name="_CYPCurrency_numericCode", Description="Create a CYPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CYPCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CYPCurrency",Description = "Reference to CYPCurrency")>] 
         cypcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CYPCurrency = Helper.toCell<CYPCurrency> cypcurrency "CYPCurrency"  
                let builder () = withMnemonic mnemonic ((CYPCurrencyModel.Cast _CYPCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CYPCurrency.source + ".NumericCode") 
                                               [| _CYPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CYPCurrency.cell
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
    [<ExcelFunction(Name="_CYPCurrency_rounding", Description="Create a CYPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CYPCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CYPCurrency",Description = "Reference to CYPCurrency")>] 
         cypcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CYPCurrency = Helper.toCell<CYPCurrency> cypcurrency "CYPCurrency"  
                let builder () = withMnemonic mnemonic ((CYPCurrencyModel.Cast _CYPCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_CYPCurrency.source + ".Rounding") 
                                               [| _CYPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CYPCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CYPCurrency> format
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
    [<ExcelFunction(Name="_CYPCurrency_symbol", Description="Create a CYPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CYPCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CYPCurrency",Description = "Reference to CYPCurrency")>] 
         cypcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CYPCurrency = Helper.toCell<CYPCurrency> cypcurrency "CYPCurrency"  
                let builder () = withMnemonic mnemonic ((CYPCurrencyModel.Cast _CYPCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CYPCurrency.source + ".Symbol") 
                                               [| _CYPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CYPCurrency.cell
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
    [<ExcelFunction(Name="_CYPCurrency_ToString", Description="Create a CYPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CYPCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CYPCurrency",Description = "Reference to CYPCurrency")>] 
         cypcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CYPCurrency = Helper.toCell<CYPCurrency> cypcurrency "CYPCurrency"  
                let builder () = withMnemonic mnemonic ((CYPCurrencyModel.Cast _CYPCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CYPCurrency.source + ".ToString") 
                                               [| _CYPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CYPCurrency.cell
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
    [<ExcelFunction(Name="_CYPCurrency_triangulationCurrency", Description="Create a CYPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CYPCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CYPCurrency",Description = "Reference to CYPCurrency")>] 
         cypcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CYPCurrency = Helper.toCell<CYPCurrency> cypcurrency "CYPCurrency"  
                let builder () = withMnemonic mnemonic ((CYPCurrencyModel.Cast _CYPCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_CYPCurrency.source + ".TriangulationCurrency") 
                                               [| _CYPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CYPCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CYPCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_CYPCurrency_Range", Description="Create a range of CYPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CYPCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CYPCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CYPCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CYPCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CYPCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CYPCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
