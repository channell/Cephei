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
module DEMCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DEMCurrency", Description="Create a DEMCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DEMCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "DEMCurrency")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.DEMCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DEMCurrency>) l

                let source () = Helper.sourceFold "Fun.DEMCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DEMCurrency> format
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
    [<ExcelFunction(Name="_DEMCurrency_code", Description="Create a DEMCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DEMCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DEMCurrency",Description = "DEMCurrency")>] 
         demcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DEMCurrency = Helper.toCell<DEMCurrency> demcurrency "DEMCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((DEMCurrencyModel.Cast _DEMCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DEMCurrency.source + ".Code") 
                                               [| _DEMCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DEMCurrency.cell
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
    [<ExcelFunction(Name="_DEMCurrency_empty", Description="Create a DEMCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DEMCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DEMCurrency",Description = "DEMCurrency")>] 
         demcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DEMCurrency = Helper.toCell<DEMCurrency> demcurrency "DEMCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((DEMCurrencyModel.Cast _DEMCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DEMCurrency.source + ".Empty") 
                                               [| _DEMCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DEMCurrency.cell
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
    [<ExcelFunction(Name="_DEMCurrency_Equals", Description="Create a DEMCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DEMCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DEMCurrency",Description = "DEMCurrency")>] 
         demcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DEMCurrency = Helper.toCell<DEMCurrency> demcurrency "DEMCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((DEMCurrencyModel.Cast _DEMCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DEMCurrency.source + ".Equals") 
                                               [| _DEMCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DEMCurrency.cell
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
    [<ExcelFunction(Name="_DEMCurrency_format", Description="Create a DEMCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DEMCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DEMCurrency",Description = "DEMCurrency")>] 
         demcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DEMCurrency = Helper.toCell<DEMCurrency> demcurrency "DEMCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((DEMCurrencyModel.Cast _DEMCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DEMCurrency.source + ".Format") 
                                               [| _DEMCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DEMCurrency.cell
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
    [<ExcelFunction(Name="_DEMCurrency_fractionsPerUnit", Description="Create a DEMCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DEMCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DEMCurrency",Description = "DEMCurrency")>] 
         demcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DEMCurrency = Helper.toCell<DEMCurrency> demcurrency "DEMCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((DEMCurrencyModel.Cast _DEMCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DEMCurrency.source + ".FractionsPerUnit") 
                                               [| _DEMCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DEMCurrency.cell
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
    [<ExcelFunction(Name="_DEMCurrency_fractionSymbol", Description="Create a DEMCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DEMCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DEMCurrency",Description = "DEMCurrency")>] 
         demcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DEMCurrency = Helper.toCell<DEMCurrency> demcurrency "DEMCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((DEMCurrencyModel.Cast _DEMCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DEMCurrency.source + ".FractionSymbol") 
                                               [| _DEMCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DEMCurrency.cell
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
    [<ExcelFunction(Name="_DEMCurrency_name", Description="Create a DEMCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DEMCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DEMCurrency",Description = "DEMCurrency")>] 
         demcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DEMCurrency = Helper.toCell<DEMCurrency> demcurrency "DEMCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((DEMCurrencyModel.Cast _DEMCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DEMCurrency.source + ".Name") 
                                               [| _DEMCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DEMCurrency.cell
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
    [<ExcelFunction(Name="_DEMCurrency_numericCode", Description="Create a DEMCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DEMCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DEMCurrency",Description = "DEMCurrency")>] 
         demcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DEMCurrency = Helper.toCell<DEMCurrency> demcurrency "DEMCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((DEMCurrencyModel.Cast _DEMCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DEMCurrency.source + ".NumericCode") 
                                               [| _DEMCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DEMCurrency.cell
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
    [<ExcelFunction(Name="_DEMCurrency_rounding", Description="Create a DEMCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DEMCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DEMCurrency",Description = "DEMCurrency")>] 
         demcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DEMCurrency = Helper.toCell<DEMCurrency> demcurrency "DEMCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((DEMCurrencyModel.Cast _DEMCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_DEMCurrency.source + ".Rounding") 
                                               [| _DEMCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DEMCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DEMCurrency> format
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
    [<ExcelFunction(Name="_DEMCurrency_symbol", Description="Create a DEMCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DEMCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DEMCurrency",Description = "DEMCurrency")>] 
         demcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DEMCurrency = Helper.toCell<DEMCurrency> demcurrency "DEMCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((DEMCurrencyModel.Cast _DEMCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DEMCurrency.source + ".Symbol") 
                                               [| _DEMCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DEMCurrency.cell
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
    [<ExcelFunction(Name="_DEMCurrency_ToString", Description="Create a DEMCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DEMCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DEMCurrency",Description = "DEMCurrency")>] 
         demcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DEMCurrency = Helper.toCell<DEMCurrency> demcurrency "DEMCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((DEMCurrencyModel.Cast _DEMCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DEMCurrency.source + ".ToString") 
                                               [| _DEMCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DEMCurrency.cell
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
    [<ExcelFunction(Name="_DEMCurrency_triangulationCurrency", Description="Create a DEMCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DEMCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DEMCurrency",Description = "DEMCurrency")>] 
         demcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DEMCurrency = Helper.toCell<DEMCurrency> demcurrency "DEMCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((DEMCurrencyModel.Cast _DEMCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_DEMCurrency.source + ".TriangulationCurrency") 
                                               [| _DEMCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DEMCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DEMCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_DEMCurrency_Range", Description="Create a range of DEMCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DEMCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DEMCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DEMCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<DEMCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<DEMCurrency>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
