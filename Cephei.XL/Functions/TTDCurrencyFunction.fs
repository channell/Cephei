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
  Trinidad & Tobago dollar   The ISO three-letter code is TTD; the numeric code is 780. It is divided in 100 cents.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module TTDCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_TTDCurrency", Description="Create a TTDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TTDCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.TTDCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TTDCurrency>) l

                let source () = Helper.sourceFold "Fun.TTDCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TTDCurrency> format
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
    [<ExcelFunction(Name="_TTDCurrency_code", Description="Create a TTDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TTDCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TTDCurrency",Description = "TTDCurrency")>] 
         ttdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TTDCurrency = Helper.toCell<TTDCurrency> ttdcurrency "TTDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((TTDCurrencyModel.Cast _TTDCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TTDCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TTDCurrency.cell
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
    [<ExcelFunction(Name="_TTDCurrency_empty", Description="Create a TTDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TTDCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TTDCurrency",Description = "TTDCurrency")>] 
         ttdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TTDCurrency = Helper.toCell<TTDCurrency> ttdcurrency "TTDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((TTDCurrencyModel.Cast _TTDCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TTDCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TTDCurrency.cell
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
    [<ExcelFunction(Name="_TTDCurrency_Equals", Description="Create a TTDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TTDCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TTDCurrency",Description = "TTDCurrency")>] 
         ttdcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TTDCurrency = Helper.toCell<TTDCurrency> ttdcurrency "TTDCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((TTDCurrencyModel.Cast _TTDCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TTDCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TTDCurrency.cell
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
    [<ExcelFunction(Name="_TTDCurrency_format", Description="Create a TTDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TTDCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TTDCurrency",Description = "TTDCurrency")>] 
         ttdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TTDCurrency = Helper.toCell<TTDCurrency> ttdcurrency "TTDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((TTDCurrencyModel.Cast _TTDCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TTDCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TTDCurrency.cell
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
    [<ExcelFunction(Name="_TTDCurrency_fractionsPerUnit", Description="Create a TTDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TTDCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TTDCurrency",Description = "TTDCurrency")>] 
         ttdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TTDCurrency = Helper.toCell<TTDCurrency> ttdcurrency "TTDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((TTDCurrencyModel.Cast _TTDCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TTDCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TTDCurrency.cell
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
    [<ExcelFunction(Name="_TTDCurrency_fractionSymbol", Description="Create a TTDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TTDCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TTDCurrency",Description = "TTDCurrency")>] 
         ttdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TTDCurrency = Helper.toCell<TTDCurrency> ttdcurrency "TTDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((TTDCurrencyModel.Cast _TTDCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TTDCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TTDCurrency.cell
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
    [<ExcelFunction(Name="_TTDCurrency_name", Description="Create a TTDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TTDCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TTDCurrency",Description = "TTDCurrency")>] 
         ttdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TTDCurrency = Helper.toCell<TTDCurrency> ttdcurrency "TTDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((TTDCurrencyModel.Cast _TTDCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TTDCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TTDCurrency.cell
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
    [<ExcelFunction(Name="_TTDCurrency_numericCode", Description="Create a TTDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TTDCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TTDCurrency",Description = "TTDCurrency")>] 
         ttdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TTDCurrency = Helper.toCell<TTDCurrency> ttdcurrency "TTDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((TTDCurrencyModel.Cast _TTDCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TTDCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TTDCurrency.cell
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
    [<ExcelFunction(Name="_TTDCurrency_rounding", Description="Create a TTDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TTDCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TTDCurrency",Description = "TTDCurrency")>] 
         ttdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TTDCurrency = Helper.toCell<TTDCurrency> ttdcurrency "TTDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((TTDCurrencyModel.Cast _TTDCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_TTDCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TTDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TTDCurrency> format
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
    [<ExcelFunction(Name="_TTDCurrency_symbol", Description="Create a TTDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TTDCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TTDCurrency",Description = "TTDCurrency")>] 
         ttdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TTDCurrency = Helper.toCell<TTDCurrency> ttdcurrency "TTDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((TTDCurrencyModel.Cast _TTDCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TTDCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TTDCurrency.cell
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
    [<ExcelFunction(Name="_TTDCurrency_ToString", Description="Create a TTDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TTDCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TTDCurrency",Description = "TTDCurrency")>] 
         ttdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TTDCurrency = Helper.toCell<TTDCurrency> ttdcurrency "TTDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((TTDCurrencyModel.Cast _TTDCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TTDCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TTDCurrency.cell
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
    [<ExcelFunction(Name="_TTDCurrency_triangulationCurrency", Description="Create a TTDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TTDCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TTDCurrency",Description = "TTDCurrency")>] 
         ttdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TTDCurrency = Helper.toCell<TTDCurrency> ttdcurrency "TTDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((TTDCurrencyModel.Cast _TTDCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_TTDCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TTDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TTDCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_TTDCurrency_Range", Description="Create a range of TTDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TTDCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TTDCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<TTDCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<TTDCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<TTDCurrency>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
