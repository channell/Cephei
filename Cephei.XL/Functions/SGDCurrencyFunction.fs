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
  The ISO three-letter code is SGD; the numeric code is 702. It is divided in 100 cents.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module SGDCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SGDCurrency", Description="Create a SGDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SGDCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "SGDCurrency")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.SGDCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SGDCurrency>) l

                let source () = Helper.sourceFold "Fun.SGDCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SGDCurrency> format
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
    [<ExcelFunction(Name="_SGDCurrency_code", Description="Create a SGDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SGDCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SGDCurrency",Description = "SGDCurrency")>] 
         sgdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SGDCurrency = Helper.toCell<SGDCurrency> sgdcurrency "SGDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((SGDCurrencyModel.Cast _SGDCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SGDCurrency.source + ".Code") 
                                               [| _SGDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SGDCurrency.cell
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
    [<ExcelFunction(Name="_SGDCurrency_empty", Description="Create a SGDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SGDCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SGDCurrency",Description = "SGDCurrency")>] 
         sgdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SGDCurrency = Helper.toCell<SGDCurrency> sgdcurrency "SGDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((SGDCurrencyModel.Cast _SGDCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SGDCurrency.source + ".Empty") 
                                               [| _SGDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SGDCurrency.cell
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
    [<ExcelFunction(Name="_SGDCurrency_Equals", Description="Create a SGDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SGDCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SGDCurrency",Description = "SGDCurrency")>] 
         sgdcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SGDCurrency = Helper.toCell<SGDCurrency> sgdcurrency "SGDCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((SGDCurrencyModel.Cast _SGDCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SGDCurrency.source + ".Equals") 
                                               [| _SGDCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SGDCurrency.cell
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
    [<ExcelFunction(Name="_SGDCurrency_format", Description="Create a SGDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SGDCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SGDCurrency",Description = "SGDCurrency")>] 
         sgdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SGDCurrency = Helper.toCell<SGDCurrency> sgdcurrency "SGDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((SGDCurrencyModel.Cast _SGDCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SGDCurrency.source + ".Format") 
                                               [| _SGDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SGDCurrency.cell
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
    [<ExcelFunction(Name="_SGDCurrency_fractionsPerUnit", Description="Create a SGDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SGDCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SGDCurrency",Description = "SGDCurrency")>] 
         sgdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SGDCurrency = Helper.toCell<SGDCurrency> sgdcurrency "SGDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((SGDCurrencyModel.Cast _SGDCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SGDCurrency.source + ".FractionsPerUnit") 
                                               [| _SGDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SGDCurrency.cell
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
    [<ExcelFunction(Name="_SGDCurrency_fractionSymbol", Description="Create a SGDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SGDCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SGDCurrency",Description = "SGDCurrency")>] 
         sgdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SGDCurrency = Helper.toCell<SGDCurrency> sgdcurrency "SGDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((SGDCurrencyModel.Cast _SGDCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SGDCurrency.source + ".FractionSymbol") 
                                               [| _SGDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SGDCurrency.cell
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
    [<ExcelFunction(Name="_SGDCurrency_name", Description="Create a SGDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SGDCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SGDCurrency",Description = "SGDCurrency")>] 
         sgdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SGDCurrency = Helper.toCell<SGDCurrency> sgdcurrency "SGDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((SGDCurrencyModel.Cast _SGDCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SGDCurrency.source + ".Name") 
                                               [| _SGDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SGDCurrency.cell
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
    [<ExcelFunction(Name="_SGDCurrency_numericCode", Description="Create a SGDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SGDCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SGDCurrency",Description = "SGDCurrency")>] 
         sgdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SGDCurrency = Helper.toCell<SGDCurrency> sgdcurrency "SGDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((SGDCurrencyModel.Cast _SGDCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SGDCurrency.source + ".NumericCode") 
                                               [| _SGDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SGDCurrency.cell
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
    [<ExcelFunction(Name="_SGDCurrency_rounding", Description="Create a SGDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SGDCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Rounding")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SGDCurrency",Description = "SGDCurrency")>] 
         sgdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SGDCurrency = Helper.toCell<SGDCurrency> sgdcurrency "SGDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((SGDCurrencyModel.Cast _SGDCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_SGDCurrency.source + ".Rounding") 
                                               [| _SGDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SGDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SGDCurrency> format
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
    [<ExcelFunction(Name="_SGDCurrency_symbol", Description="Create a SGDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SGDCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SGDCurrency",Description = "SGDCurrency")>] 
         sgdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SGDCurrency = Helper.toCell<SGDCurrency> sgdcurrency "SGDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((SGDCurrencyModel.Cast _SGDCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SGDCurrency.source + ".Symbol") 
                                               [| _SGDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SGDCurrency.cell
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
    [<ExcelFunction(Name="_SGDCurrency_ToString", Description="Create a SGDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SGDCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SGDCurrency",Description = "SGDCurrency")>] 
         sgdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SGDCurrency = Helper.toCell<SGDCurrency> sgdcurrency "SGDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((SGDCurrencyModel.Cast _SGDCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SGDCurrency.source + ".ToString") 
                                               [| _SGDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SGDCurrency.cell
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
    [<ExcelFunction(Name="_SGDCurrency_triangulationCurrency", Description="Create a SGDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SGDCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SGDCurrency",Description = "SGDCurrency")>] 
         sgdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SGDCurrency = Helper.toCell<SGDCurrency> sgdcurrency "SGDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((SGDCurrencyModel.Cast _SGDCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_SGDCurrency.source + ".TriangulationCurrency") 
                                               [| _SGDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SGDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SGDCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_SGDCurrency_Range", Description="Create a range of SGDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SGDCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SGDCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SGDCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<SGDCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<SGDCurrency>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
