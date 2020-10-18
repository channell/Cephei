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
  Colombian peso   The ISO three-letter code is COP; the numeric code is 170. It is divided in 100 centavos.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module COPCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_COPCurrency", Description="Create a COPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let COPCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "COPCurrency")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.COPCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<COPCurrency>) l

                let source () = Helper.sourceFold "Fun.COPCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<COPCurrency> format
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
    [<ExcelFunction(Name="_COPCurrency_code", Description="Create a COPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let COPCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="COPCurrency",Description = "COPCurrency")>] 
         copcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _COPCurrency = Helper.toCell<COPCurrency> copcurrency "COPCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((COPCurrencyModel.Cast _COPCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_COPCurrency.source + ".Code") 
                                               [| _COPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _COPCurrency.cell
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
    [<ExcelFunction(Name="_COPCurrency_empty", Description="Create a COPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let COPCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="COPCurrency",Description = "COPCurrency")>] 
         copcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _COPCurrency = Helper.toCell<COPCurrency> copcurrency "COPCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((COPCurrencyModel.Cast _COPCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_COPCurrency.source + ".Empty") 
                                               [| _COPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _COPCurrency.cell
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
    [<ExcelFunction(Name="_COPCurrency_Equals", Description="Create a COPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let COPCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="COPCurrency",Description = "COPCurrency")>] 
         copcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _COPCurrency = Helper.toCell<COPCurrency> copcurrency "COPCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((COPCurrencyModel.Cast _COPCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_COPCurrency.source + ".Equals") 
                                               [| _COPCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _COPCurrency.cell
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
    [<ExcelFunction(Name="_COPCurrency_format", Description="Create a COPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let COPCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="COPCurrency",Description = "COPCurrency")>] 
         copcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _COPCurrency = Helper.toCell<COPCurrency> copcurrency "COPCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((COPCurrencyModel.Cast _COPCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_COPCurrency.source + ".Format") 
                                               [| _COPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _COPCurrency.cell
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
    [<ExcelFunction(Name="_COPCurrency_fractionsPerUnit", Description="Create a COPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let COPCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="COPCurrency",Description = "COPCurrency")>] 
         copcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _COPCurrency = Helper.toCell<COPCurrency> copcurrency "COPCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((COPCurrencyModel.Cast _COPCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_COPCurrency.source + ".FractionsPerUnit") 
                                               [| _COPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _COPCurrency.cell
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
    [<ExcelFunction(Name="_COPCurrency_fractionSymbol", Description="Create a COPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let COPCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="COPCurrency",Description = "COPCurrency")>] 
         copcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _COPCurrency = Helper.toCell<COPCurrency> copcurrency "COPCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((COPCurrencyModel.Cast _COPCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_COPCurrency.source + ".FractionSymbol") 
                                               [| _COPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _COPCurrency.cell
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
    [<ExcelFunction(Name="_COPCurrency_name", Description="Create a COPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let COPCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="COPCurrency",Description = "COPCurrency")>] 
         copcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _COPCurrency = Helper.toCell<COPCurrency> copcurrency "COPCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((COPCurrencyModel.Cast _COPCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_COPCurrency.source + ".Name") 
                                               [| _COPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _COPCurrency.cell
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
    [<ExcelFunction(Name="_COPCurrency_numericCode", Description="Create a COPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let COPCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="COPCurrency",Description = "COPCurrency")>] 
         copcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _COPCurrency = Helper.toCell<COPCurrency> copcurrency "COPCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((COPCurrencyModel.Cast _COPCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_COPCurrency.source + ".NumericCode") 
                                               [| _COPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _COPCurrency.cell
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
    [<ExcelFunction(Name="_COPCurrency_rounding", Description="Create a COPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let COPCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="COPCurrency",Description = "COPCurrency")>] 
         copcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _COPCurrency = Helper.toCell<COPCurrency> copcurrency "COPCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((COPCurrencyModel.Cast _COPCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_COPCurrency.source + ".Rounding") 
                                               [| _COPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _COPCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<COPCurrency> format
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
    [<ExcelFunction(Name="_COPCurrency_symbol", Description="Create a COPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let COPCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="COPCurrency",Description = "COPCurrency")>] 
         copcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _COPCurrency = Helper.toCell<COPCurrency> copcurrency "COPCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((COPCurrencyModel.Cast _COPCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_COPCurrency.source + ".Symbol") 
                                               [| _COPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _COPCurrency.cell
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
    [<ExcelFunction(Name="_COPCurrency_ToString", Description="Create a COPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let COPCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="COPCurrency",Description = "COPCurrency")>] 
         copcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _COPCurrency = Helper.toCell<COPCurrency> copcurrency "COPCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((COPCurrencyModel.Cast _COPCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_COPCurrency.source + ".ToString") 
                                               [| _COPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _COPCurrency.cell
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
    [<ExcelFunction(Name="_COPCurrency_triangulationCurrency", Description="Create a COPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let COPCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="COPCurrency",Description = "COPCurrency")>] 
         copcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _COPCurrency = Helper.toCell<COPCurrency> copcurrency "COPCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((COPCurrencyModel.Cast _COPCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_COPCurrency.source + ".TriangulationCurrency") 
                                               [| _COPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _COPCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<COPCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_COPCurrency_Range", Description="Create a range of COPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let COPCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<COPCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<COPCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<COPCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<COPCurrency>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
