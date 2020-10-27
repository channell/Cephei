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
    [<ExcelFunction(Name="_PENCurrency", Description="Create a PENCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PENCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "PENCurrency")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.PENCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PENCurrency>) l

                let source () = Helper.sourceFold "Fun.PENCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_PENCurrency_code", Description="Create a PENCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PENCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PENCurrency",Description = "PENCurrency")>] 
         pencurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PENCurrency = Helper.toCell<PENCurrency> pencurrency "PENCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PENCurrencyModel.Cast _PENCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PENCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PENCurrency.cell
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
    [<ExcelFunction(Name="_PENCurrency_empty", Description="Create a PENCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PENCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PENCurrency",Description = "PENCurrency")>] 
         pencurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PENCurrency = Helper.toCell<PENCurrency> pencurrency "PENCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PENCurrencyModel.Cast _PENCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PENCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PENCurrency.cell
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
    [<ExcelFunction(Name="_PENCurrency_Equals", Description="Create a PENCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PENCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PENCurrency",Description = "PENCurrency")>] 
         pencurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PENCurrency = Helper.toCell<PENCurrency> pencurrency "PENCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((PENCurrencyModel.Cast _PENCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PENCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PENCurrency.cell
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
    [<ExcelFunction(Name="_PENCurrency_format", Description="Create a PENCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PENCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PENCurrency",Description = "PENCurrency")>] 
         pencurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PENCurrency = Helper.toCell<PENCurrency> pencurrency "PENCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PENCurrencyModel.Cast _PENCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PENCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PENCurrency.cell
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
    [<ExcelFunction(Name="_PENCurrency_fractionsPerUnit", Description="Create a PENCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PENCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PENCurrency",Description = "PENCurrency")>] 
         pencurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PENCurrency = Helper.toCell<PENCurrency> pencurrency "PENCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PENCurrencyModel.Cast _PENCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PENCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PENCurrency.cell
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
    [<ExcelFunction(Name="_PENCurrency_fractionSymbol", Description="Create a PENCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PENCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PENCurrency",Description = "PENCurrency")>] 
         pencurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PENCurrency = Helper.toCell<PENCurrency> pencurrency "PENCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PENCurrencyModel.Cast _PENCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PENCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PENCurrency.cell
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
    [<ExcelFunction(Name="_PENCurrency_name", Description="Create a PENCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PENCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PENCurrency",Description = "PENCurrency")>] 
         pencurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PENCurrency = Helper.toCell<PENCurrency> pencurrency "PENCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PENCurrencyModel.Cast _PENCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PENCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PENCurrency.cell
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
    [<ExcelFunction(Name="_PENCurrency_numericCode", Description="Create a PENCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PENCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PENCurrency",Description = "PENCurrency")>] 
         pencurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PENCurrency = Helper.toCell<PENCurrency> pencurrency "PENCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PENCurrencyModel.Cast _PENCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PENCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PENCurrency.cell
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
    [<ExcelFunction(Name="_PENCurrency_rounding", Description="Create a PENCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PENCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PENCurrency",Description = "PENCurrency")>] 
         pencurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PENCurrency = Helper.toCell<PENCurrency> pencurrency "PENCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PENCurrencyModel.Cast _PENCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_PENCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PENCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_PENCurrency_symbol", Description="Create a PENCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PENCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PENCurrency",Description = "PENCurrency")>] 
         pencurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PENCurrency = Helper.toCell<PENCurrency> pencurrency "PENCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PENCurrencyModel.Cast _PENCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PENCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PENCurrency.cell
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
    [<ExcelFunction(Name="_PENCurrency_ToString", Description="Create a PENCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PENCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PENCurrency",Description = "PENCurrency")>] 
         pencurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PENCurrency = Helper.toCell<PENCurrency> pencurrency "PENCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PENCurrencyModel.Cast _PENCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PENCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PENCurrency.cell
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
    [<ExcelFunction(Name="_PENCurrency_triangulationCurrency", Description="Create a PENCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PENCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PENCurrency",Description = "PENCurrency")>] 
         pencurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PENCurrency = Helper.toCell<PENCurrency> pencurrency "PENCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PENCurrencyModel.Cast _PENCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_PENCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PENCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PENCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_PENCurrency_Range", Description="Create a range of PENCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PENCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
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
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<PENCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<PENCurrency>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
