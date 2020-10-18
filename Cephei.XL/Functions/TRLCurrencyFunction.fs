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
module TRLCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_TRLCurrency", Description="Create a TRLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TRLCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "TRLCurrency")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.TRLCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TRLCurrency>) l

                let source () = Helper.sourceFold "Fun.TRLCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TRLCurrency> format
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
    [<ExcelFunction(Name="_TRLCurrency_code", Description="Create a TRLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TRLCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLCurrency",Description = "TRLCurrency")>] 
         trlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLCurrency = Helper.toCell<TRLCurrency> trlcurrency "TRLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((TRLCurrencyModel.Cast _TRLCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TRLCurrency.source + ".Code") 
                                               [| _TRLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLCurrency.cell
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
    [<ExcelFunction(Name="_TRLCurrency_empty", Description="Create a TRLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TRLCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLCurrency",Description = "TRLCurrency")>] 
         trlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLCurrency = Helper.toCell<TRLCurrency> trlcurrency "TRLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((TRLCurrencyModel.Cast _TRLCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TRLCurrency.source + ".Empty") 
                                               [| _TRLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLCurrency.cell
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
    [<ExcelFunction(Name="_TRLCurrency_Equals", Description="Create a TRLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TRLCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLCurrency",Description = "TRLCurrency")>] 
         trlcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLCurrency = Helper.toCell<TRLCurrency> trlcurrency "TRLCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((TRLCurrencyModel.Cast _TRLCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TRLCurrency.source + ".Equals") 
                                               [| _TRLCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLCurrency.cell
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
    [<ExcelFunction(Name="_TRLCurrency_format", Description="Create a TRLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TRLCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLCurrency",Description = "TRLCurrency")>] 
         trlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLCurrency = Helper.toCell<TRLCurrency> trlcurrency "TRLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((TRLCurrencyModel.Cast _TRLCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TRLCurrency.source + ".Format") 
                                               [| _TRLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLCurrency.cell
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
    [<ExcelFunction(Name="_TRLCurrency_fractionsPerUnit", Description="Create a TRLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TRLCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLCurrency",Description = "TRLCurrency")>] 
         trlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLCurrency = Helper.toCell<TRLCurrency> trlcurrency "TRLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((TRLCurrencyModel.Cast _TRLCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TRLCurrency.source + ".FractionsPerUnit") 
                                               [| _TRLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLCurrency.cell
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
    [<ExcelFunction(Name="_TRLCurrency_fractionSymbol", Description="Create a TRLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TRLCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLCurrency",Description = "TRLCurrency")>] 
         trlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLCurrency = Helper.toCell<TRLCurrency> trlcurrency "TRLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((TRLCurrencyModel.Cast _TRLCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TRLCurrency.source + ".FractionSymbol") 
                                               [| _TRLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLCurrency.cell
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
    [<ExcelFunction(Name="_TRLCurrency_name", Description="Create a TRLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TRLCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLCurrency",Description = "TRLCurrency")>] 
         trlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLCurrency = Helper.toCell<TRLCurrency> trlcurrency "TRLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((TRLCurrencyModel.Cast _TRLCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TRLCurrency.source + ".Name") 
                                               [| _TRLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLCurrency.cell
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
    [<ExcelFunction(Name="_TRLCurrency_numericCode", Description="Create a TRLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TRLCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLCurrency",Description = "TRLCurrency")>] 
         trlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLCurrency = Helper.toCell<TRLCurrency> trlcurrency "TRLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((TRLCurrencyModel.Cast _TRLCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TRLCurrency.source + ".NumericCode") 
                                               [| _TRLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLCurrency.cell
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
    [<ExcelFunction(Name="_TRLCurrency_rounding", Description="Create a TRLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TRLCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLCurrency",Description = "TRLCurrency")>] 
         trlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLCurrency = Helper.toCell<TRLCurrency> trlcurrency "TRLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((TRLCurrencyModel.Cast _TRLCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_TRLCurrency.source + ".Rounding") 
                                               [| _TRLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TRLCurrency> format
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
    [<ExcelFunction(Name="_TRLCurrency_symbol", Description="Create a TRLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TRLCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLCurrency",Description = "TRLCurrency")>] 
         trlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLCurrency = Helper.toCell<TRLCurrency> trlcurrency "TRLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((TRLCurrencyModel.Cast _TRLCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TRLCurrency.source + ".Symbol") 
                                               [| _TRLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLCurrency.cell
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
    [<ExcelFunction(Name="_TRLCurrency_ToString", Description="Create a TRLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TRLCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLCurrency",Description = "TRLCurrency")>] 
         trlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLCurrency = Helper.toCell<TRLCurrency> trlcurrency "TRLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((TRLCurrencyModel.Cast _TRLCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TRLCurrency.source + ".ToString") 
                                               [| _TRLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLCurrency.cell
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
    [<ExcelFunction(Name="_TRLCurrency_triangulationCurrency", Description="Create a TRLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TRLCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRLCurrency",Description = "TRLCurrency")>] 
         trlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRLCurrency = Helper.toCell<TRLCurrency> trlcurrency "TRLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((TRLCurrencyModel.Cast _TRLCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_TRLCurrency.source + ".TriangulationCurrency") 
                                               [| _TRLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRLCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TRLCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_TRLCurrency_Range", Description="Create a range of TRLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TRLCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TRLCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<TRLCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<TRLCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<TRLCurrency>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
