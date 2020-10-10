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
module GBPCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GBPCurrency", Description="Create a GBPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.GBPCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GBPCurrency>) l

                let source () = Helper.sourceFold "Fun.GBPCurrency ()" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GBPCurrency> format
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
    [<ExcelFunction(Name="_GBPCurrency_code", Description="Create a GBPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPCurrency",Description = "Reference to GBPCurrency")>] 
         gbpcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPCurrency = Helper.toCell<GBPCurrency> gbpcurrency "GBPCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((GBPCurrencyModel.Cast _GBPCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GBPCurrency.source + ".Code") 
                                               [| _GBPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPCurrency.cell
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
    [<ExcelFunction(Name="_GBPCurrency_empty", Description="Create a GBPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPCurrency",Description = "Reference to GBPCurrency")>] 
         gbpcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPCurrency = Helper.toCell<GBPCurrency> gbpcurrency "GBPCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((GBPCurrencyModel.Cast _GBPCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GBPCurrency.source + ".Empty") 
                                               [| _GBPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPCurrency.cell
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
    [<ExcelFunction(Name="_GBPCurrency_Equals", Description="Create a GBPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPCurrency",Description = "Reference to GBPCurrency")>] 
         gbpcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPCurrency = Helper.toCell<GBPCurrency> gbpcurrency "GBPCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((GBPCurrencyModel.Cast _GBPCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GBPCurrency.source + ".Equals") 
                                               [| _GBPCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPCurrency.cell
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
    [<ExcelFunction(Name="_GBPCurrency_format", Description="Create a GBPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPCurrency",Description = "Reference to GBPCurrency")>] 
         gbpcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPCurrency = Helper.toCell<GBPCurrency> gbpcurrency "GBPCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((GBPCurrencyModel.Cast _GBPCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GBPCurrency.source + ".Format") 
                                               [| _GBPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPCurrency.cell
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
    [<ExcelFunction(Name="_GBPCurrency_fractionsPerUnit", Description="Create a GBPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPCurrency",Description = "Reference to GBPCurrency")>] 
         gbpcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPCurrency = Helper.toCell<GBPCurrency> gbpcurrency "GBPCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((GBPCurrencyModel.Cast _GBPCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GBPCurrency.source + ".FractionsPerUnit") 
                                               [| _GBPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPCurrency.cell
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
    [<ExcelFunction(Name="_GBPCurrency_fractionSymbol", Description="Create a GBPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPCurrency",Description = "Reference to GBPCurrency")>] 
         gbpcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPCurrency = Helper.toCell<GBPCurrency> gbpcurrency "GBPCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((GBPCurrencyModel.Cast _GBPCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GBPCurrency.source + ".FractionSymbol") 
                                               [| _GBPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPCurrency.cell
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
    [<ExcelFunction(Name="_GBPCurrency_name", Description="Create a GBPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPCurrency",Description = "Reference to GBPCurrency")>] 
         gbpcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPCurrency = Helper.toCell<GBPCurrency> gbpcurrency "GBPCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((GBPCurrencyModel.Cast _GBPCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GBPCurrency.source + ".Name") 
                                               [| _GBPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPCurrency.cell
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
    [<ExcelFunction(Name="_GBPCurrency_numericCode", Description="Create a GBPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPCurrency",Description = "Reference to GBPCurrency")>] 
         gbpcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPCurrency = Helper.toCell<GBPCurrency> gbpcurrency "GBPCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((GBPCurrencyModel.Cast _GBPCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GBPCurrency.source + ".NumericCode") 
                                               [| _GBPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPCurrency.cell
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
    [<ExcelFunction(Name="_GBPCurrency_rounding", Description="Create a GBPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPCurrency",Description = "Reference to GBPCurrency")>] 
         gbpcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPCurrency = Helper.toCell<GBPCurrency> gbpcurrency "GBPCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((GBPCurrencyModel.Cast _GBPCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_GBPCurrency.source + ".Rounding") 
                                               [| _GBPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GBPCurrency> format
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
    [<ExcelFunction(Name="_GBPCurrency_symbol", Description="Create a GBPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPCurrency",Description = "Reference to GBPCurrency")>] 
         gbpcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPCurrency = Helper.toCell<GBPCurrency> gbpcurrency "GBPCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((GBPCurrencyModel.Cast _GBPCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GBPCurrency.source + ".Symbol") 
                                               [| _GBPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPCurrency.cell
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
    [<ExcelFunction(Name="_GBPCurrency_ToString", Description="Create a GBPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPCurrency",Description = "Reference to GBPCurrency")>] 
         gbpcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPCurrency = Helper.toCell<GBPCurrency> gbpcurrency "GBPCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((GBPCurrencyModel.Cast _GBPCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GBPCurrency.source + ".ToString") 
                                               [| _GBPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPCurrency.cell
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
    [<ExcelFunction(Name="_GBPCurrency_triangulationCurrency", Description="Create a GBPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPCurrency",Description = "Reference to GBPCurrency")>] 
         gbpcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPCurrency = Helper.toCell<GBPCurrency> gbpcurrency "GBPCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((GBPCurrencyModel.Cast _GBPCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_GBPCurrency.source + ".TriangulationCurrency") 
                                               [| _GBPCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GBPCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_GBPCurrency_Range", Description="Create a range of GBPCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GBPCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GBPCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GBPCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<GBPCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<GBPCurrency>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
