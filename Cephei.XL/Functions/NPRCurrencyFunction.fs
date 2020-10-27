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
  The ISO three-letter code is NPR; the numeric code is 524. It is divided in 100 paise.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module NPRCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_NPRCurrency", Description="Create a NPRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NPRCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "NPRCurrency")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.NPRCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NPRCurrency>) l

                let source () = Helper.sourceFold "Fun.NPRCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NPRCurrency> format
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
    [<ExcelFunction(Name="_NPRCurrency_code", Description="Create a NPRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NPRCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NPRCurrency",Description = "NPRCurrency")>] 
         nprcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NPRCurrency = Helper.toCell<NPRCurrency> nprcurrency "NPRCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((NPRCurrencyModel.Cast _NPRCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NPRCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NPRCurrency.cell
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
    [<ExcelFunction(Name="_NPRCurrency_empty", Description="Create a NPRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NPRCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NPRCurrency",Description = "NPRCurrency")>] 
         nprcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NPRCurrency = Helper.toCell<NPRCurrency> nprcurrency "NPRCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((NPRCurrencyModel.Cast _NPRCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NPRCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NPRCurrency.cell
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
    [<ExcelFunction(Name="_NPRCurrency_Equals", Description="Create a NPRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NPRCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NPRCurrency",Description = "NPRCurrency")>] 
         nprcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NPRCurrency = Helper.toCell<NPRCurrency> nprcurrency "NPRCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((NPRCurrencyModel.Cast _NPRCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NPRCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NPRCurrency.cell
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
    [<ExcelFunction(Name="_NPRCurrency_format", Description="Create a NPRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NPRCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NPRCurrency",Description = "NPRCurrency")>] 
         nprcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NPRCurrency = Helper.toCell<NPRCurrency> nprcurrency "NPRCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((NPRCurrencyModel.Cast _NPRCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NPRCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NPRCurrency.cell
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
    [<ExcelFunction(Name="_NPRCurrency_fractionsPerUnit", Description="Create a NPRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NPRCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NPRCurrency",Description = "NPRCurrency")>] 
         nprcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NPRCurrency = Helper.toCell<NPRCurrency> nprcurrency "NPRCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((NPRCurrencyModel.Cast _NPRCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NPRCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NPRCurrency.cell
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
    [<ExcelFunction(Name="_NPRCurrency_fractionSymbol", Description="Create a NPRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NPRCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NPRCurrency",Description = "NPRCurrency")>] 
         nprcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NPRCurrency = Helper.toCell<NPRCurrency> nprcurrency "NPRCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((NPRCurrencyModel.Cast _NPRCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NPRCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NPRCurrency.cell
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
    [<ExcelFunction(Name="_NPRCurrency_name", Description="Create a NPRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NPRCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NPRCurrency",Description = "NPRCurrency")>] 
         nprcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NPRCurrency = Helper.toCell<NPRCurrency> nprcurrency "NPRCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((NPRCurrencyModel.Cast _NPRCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NPRCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NPRCurrency.cell
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
    [<ExcelFunction(Name="_NPRCurrency_numericCode", Description="Create a NPRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NPRCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NPRCurrency",Description = "NPRCurrency")>] 
         nprcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NPRCurrency = Helper.toCell<NPRCurrency> nprcurrency "NPRCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((NPRCurrencyModel.Cast _NPRCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NPRCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NPRCurrency.cell
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
    [<ExcelFunction(Name="_NPRCurrency_rounding", Description="Create a NPRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NPRCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NPRCurrency",Description = "NPRCurrency")>] 
         nprcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NPRCurrency = Helper.toCell<NPRCurrency> nprcurrency "NPRCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((NPRCurrencyModel.Cast _NPRCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_NPRCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NPRCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NPRCurrency> format
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
    [<ExcelFunction(Name="_NPRCurrency_symbol", Description="Create a NPRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NPRCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NPRCurrency",Description = "NPRCurrency")>] 
         nprcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NPRCurrency = Helper.toCell<NPRCurrency> nprcurrency "NPRCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((NPRCurrencyModel.Cast _NPRCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NPRCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NPRCurrency.cell
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
    [<ExcelFunction(Name="_NPRCurrency_ToString", Description="Create a NPRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NPRCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NPRCurrency",Description = "NPRCurrency")>] 
         nprcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NPRCurrency = Helper.toCell<NPRCurrency> nprcurrency "NPRCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((NPRCurrencyModel.Cast _NPRCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NPRCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NPRCurrency.cell
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
    [<ExcelFunction(Name="_NPRCurrency_triangulationCurrency", Description="Create a NPRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NPRCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NPRCurrency",Description = "NPRCurrency")>] 
         nprcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NPRCurrency = Helper.toCell<NPRCurrency> nprcurrency "NPRCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((NPRCurrencyModel.Cast _NPRCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_NPRCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NPRCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NPRCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_NPRCurrency_Range", Description="Create a range of NPRCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NPRCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<NPRCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<NPRCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<NPRCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<NPRCurrency>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
