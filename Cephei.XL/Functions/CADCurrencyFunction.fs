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
  Canadian dollar   The ISO three-letter code is CAD; the numeric code is 124. It is divided into 100 cents.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module CADCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CADCurrency", Description="Create a CADCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "CADCurrency")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.CADCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CADCurrency>) l

                let source () = Helper.sourceFold "Fun.CADCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CADCurrency> format
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
    [<ExcelFunction(Name="_CADCurrency_code", Description="Create a CADCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADCurrency",Description = "CADCurrency")>] 
         cadcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADCurrency = Helper.toCell<CADCurrency> cadcurrency "CADCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CADCurrencyModel.Cast _CADCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CADCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CADCurrency.cell
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
    [<ExcelFunction(Name="_CADCurrency_empty", Description="Create a CADCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADCurrency",Description = "CADCurrency")>] 
         cadcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADCurrency = Helper.toCell<CADCurrency> cadcurrency "CADCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CADCurrencyModel.Cast _CADCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CADCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CADCurrency.cell
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
    [<ExcelFunction(Name="_CADCurrency_Equals", Description="Create a CADCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADCurrency",Description = "CADCurrency")>] 
         cadcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADCurrency = Helper.toCell<CADCurrency> cadcurrency "CADCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((CADCurrencyModel.Cast _CADCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CADCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADCurrency.cell
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
    [<ExcelFunction(Name="_CADCurrency_format", Description="Create a CADCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADCurrency",Description = "CADCurrency")>] 
         cadcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADCurrency = Helper.toCell<CADCurrency> cadcurrency "CADCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CADCurrencyModel.Cast _CADCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CADCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CADCurrency.cell
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
    [<ExcelFunction(Name="_CADCurrency_fractionsPerUnit", Description="Create a CADCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADCurrency",Description = "CADCurrency")>] 
         cadcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADCurrency = Helper.toCell<CADCurrency> cadcurrency "CADCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CADCurrencyModel.Cast _CADCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CADCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CADCurrency.cell
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
    [<ExcelFunction(Name="_CADCurrency_fractionSymbol", Description="Create a CADCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADCurrency",Description = "CADCurrency")>] 
         cadcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADCurrency = Helper.toCell<CADCurrency> cadcurrency "CADCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CADCurrencyModel.Cast _CADCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CADCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CADCurrency.cell
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
    [<ExcelFunction(Name="_CADCurrency_name", Description="Create a CADCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADCurrency",Description = "CADCurrency")>] 
         cadcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADCurrency = Helper.toCell<CADCurrency> cadcurrency "CADCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CADCurrencyModel.Cast _CADCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CADCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CADCurrency.cell
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
    [<ExcelFunction(Name="_CADCurrency_numericCode", Description="Create a CADCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADCurrency",Description = "CADCurrency")>] 
         cadcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADCurrency = Helper.toCell<CADCurrency> cadcurrency "CADCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CADCurrencyModel.Cast _CADCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CADCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CADCurrency.cell
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
    [<ExcelFunction(Name="_CADCurrency_rounding", Description="Create a CADCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADCurrency",Description = "CADCurrency")>] 
         cadcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADCurrency = Helper.toCell<CADCurrency> cadcurrency "CADCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CADCurrencyModel.Cast _CADCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_CADCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CADCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CADCurrency> format
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
    [<ExcelFunction(Name="_CADCurrency_symbol", Description="Create a CADCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADCurrency",Description = "CADCurrency")>] 
         cadcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADCurrency = Helper.toCell<CADCurrency> cadcurrency "CADCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CADCurrencyModel.Cast _CADCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CADCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CADCurrency.cell
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
    [<ExcelFunction(Name="_CADCurrency_ToString", Description="Create a CADCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADCurrency",Description = "CADCurrency")>] 
         cadcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADCurrency = Helper.toCell<CADCurrency> cadcurrency "CADCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CADCurrencyModel.Cast _CADCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CADCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CADCurrency.cell
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
    [<ExcelFunction(Name="_CADCurrency_triangulationCurrency", Description="Create a CADCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADCurrency",Description = "CADCurrency")>] 
         cadcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADCurrency = Helper.toCell<CADCurrency> cadcurrency "CADCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((CADCurrencyModel.Cast _CADCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_CADCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CADCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CADCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_CADCurrency_Range", Description="Create a range of CADCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CADCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CADCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CADCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<CADCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<CADCurrency>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
