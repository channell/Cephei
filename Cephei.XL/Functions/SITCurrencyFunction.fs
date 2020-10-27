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
module SITCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SITCurrency", Description="Create a SITCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SITCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.SITCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SITCurrency>) l

                let source () = Helper.sourceFold "Fun.SITCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SITCurrency> format
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
    [<ExcelFunction(Name="_SITCurrency_code", Description="Create a SITCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SITCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SITCurrency",Description = "SITCurrency")>] 
         sitcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SITCurrency = Helper.toCell<SITCurrency> sitcurrency "SITCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((SITCurrencyModel.Cast _SITCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SITCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SITCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_SITCurrency_empty", Description="Create a SITCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SITCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SITCurrency",Description = "SITCurrency")>] 
         sitcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SITCurrency = Helper.toCell<SITCurrency> sitcurrency "SITCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((SITCurrencyModel.Cast _SITCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SITCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SITCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_SITCurrency_Equals", Description="Create a SITCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SITCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SITCurrency",Description = "SITCurrency")>] 
         sitcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SITCurrency = Helper.toCell<SITCurrency> sitcurrency "SITCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((SITCurrencyModel.Cast _SITCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SITCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SITCurrency.cell
                                ;  _o.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_SITCurrency_format", Description="Create a SITCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SITCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SITCurrency",Description = "SITCurrency")>] 
         sitcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SITCurrency = Helper.toCell<SITCurrency> sitcurrency "SITCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((SITCurrencyModel.Cast _SITCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SITCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SITCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_SITCurrency_fractionsPerUnit", Description="Create a SITCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SITCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SITCurrency",Description = "SITCurrency")>] 
         sitcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SITCurrency = Helper.toCell<SITCurrency> sitcurrency "SITCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((SITCurrencyModel.Cast _SITCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SITCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SITCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_SITCurrency_fractionSymbol", Description="Create a SITCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SITCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SITCurrency",Description = "SITCurrency")>] 
         sitcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SITCurrency = Helper.toCell<SITCurrency> sitcurrency "SITCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((SITCurrencyModel.Cast _SITCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SITCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SITCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_SITCurrency_name", Description="Create a SITCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SITCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SITCurrency",Description = "SITCurrency")>] 
         sitcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SITCurrency = Helper.toCell<SITCurrency> sitcurrency "SITCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((SITCurrencyModel.Cast _SITCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SITCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SITCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_SITCurrency_numericCode", Description="Create a SITCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SITCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SITCurrency",Description = "SITCurrency")>] 
         sitcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SITCurrency = Helper.toCell<SITCurrency> sitcurrency "SITCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((SITCurrencyModel.Cast _SITCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SITCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SITCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_SITCurrency_rounding", Description="Create a SITCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SITCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SITCurrency",Description = "SITCurrency")>] 
         sitcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SITCurrency = Helper.toCell<SITCurrency> sitcurrency "SITCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((SITCurrencyModel.Cast _SITCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_SITCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SITCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SITCurrency> format
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
    [<ExcelFunction(Name="_SITCurrency_symbol", Description="Create a SITCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SITCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SITCurrency",Description = "SITCurrency")>] 
         sitcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SITCurrency = Helper.toCell<SITCurrency> sitcurrency "SITCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((SITCurrencyModel.Cast _SITCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SITCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SITCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_SITCurrency_ToString", Description="Create a SITCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SITCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SITCurrency",Description = "SITCurrency")>] 
         sitcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SITCurrency = Helper.toCell<SITCurrency> sitcurrency "SITCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((SITCurrencyModel.Cast _SITCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SITCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SITCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_SITCurrency_triangulationCurrency", Description="Create a SITCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SITCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SITCurrency",Description = "SITCurrency")>] 
         sitcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SITCurrency = Helper.toCell<SITCurrency> sitcurrency "SITCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((SITCurrencyModel.Cast _SITCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_SITCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SITCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SITCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_SITCurrency_Range", Description="Create a range of SITCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SITCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SITCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SITCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<SITCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<SITCurrency>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
