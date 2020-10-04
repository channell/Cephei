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
module TRYCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_TRYCurrency", Description="Create a TRYCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TRYCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.TRYCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TRYCurrency>) l

                let source = Helper.sourceFold "Fun.TRYCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TRYCurrency> format
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
    [<ExcelFunction(Name="_TRYCurrency_code", Description="Create a TRYCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TRYCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRYCurrency",Description = "Reference to TRYCurrency")>] 
         trycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRYCurrency = Helper.toCell<TRYCurrency> trycurrency "TRYCurrency"  
                let builder () = withMnemonic mnemonic ((TRYCurrencyModel.Cast _TRYCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TRYCurrency.source + ".Code") 
                                               [| _TRYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRYCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_TRYCurrency_empty", Description="Create a TRYCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TRYCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRYCurrency",Description = "Reference to TRYCurrency")>] 
         trycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRYCurrency = Helper.toCell<TRYCurrency> trycurrency "TRYCurrency"  
                let builder () = withMnemonic mnemonic ((TRYCurrencyModel.Cast _TRYCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TRYCurrency.source + ".Empty") 
                                               [| _TRYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRYCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_TRYCurrency_Equals", Description="Create a TRYCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TRYCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRYCurrency",Description = "Reference to TRYCurrency")>] 
         trycurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRYCurrency = Helper.toCell<TRYCurrency> trycurrency "TRYCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((TRYCurrencyModel.Cast _TRYCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TRYCurrency.source + ".Equals") 
                                               [| _TRYCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRYCurrency.cell
                                ;  _o.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_TRYCurrency_format", Description="Create a TRYCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TRYCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRYCurrency",Description = "Reference to TRYCurrency")>] 
         trycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRYCurrency = Helper.toCell<TRYCurrency> trycurrency "TRYCurrency"  
                let builder () = withMnemonic mnemonic ((TRYCurrencyModel.Cast _TRYCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TRYCurrency.source + ".Format") 
                                               [| _TRYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRYCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_TRYCurrency_fractionsPerUnit", Description="Create a TRYCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TRYCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRYCurrency",Description = "Reference to TRYCurrency")>] 
         trycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRYCurrency = Helper.toCell<TRYCurrency> trycurrency "TRYCurrency"  
                let builder () = withMnemonic mnemonic ((TRYCurrencyModel.Cast _TRYCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_TRYCurrency.source + ".FractionsPerUnit") 
                                               [| _TRYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRYCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_TRYCurrency_fractionSymbol", Description="Create a TRYCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TRYCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRYCurrency",Description = "Reference to TRYCurrency")>] 
         trycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRYCurrency = Helper.toCell<TRYCurrency> trycurrency "TRYCurrency"  
                let builder () = withMnemonic mnemonic ((TRYCurrencyModel.Cast _TRYCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TRYCurrency.source + ".FractionSymbol") 
                                               [| _TRYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRYCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_TRYCurrency_name", Description="Create a TRYCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TRYCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRYCurrency",Description = "Reference to TRYCurrency")>] 
         trycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRYCurrency = Helper.toCell<TRYCurrency> trycurrency "TRYCurrency"  
                let builder () = withMnemonic mnemonic ((TRYCurrencyModel.Cast _TRYCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TRYCurrency.source + ".Name") 
                                               [| _TRYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRYCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_TRYCurrency_numericCode", Description="Create a TRYCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TRYCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRYCurrency",Description = "Reference to TRYCurrency")>] 
         trycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRYCurrency = Helper.toCell<TRYCurrency> trycurrency "TRYCurrency"  
                let builder () = withMnemonic mnemonic ((TRYCurrencyModel.Cast _TRYCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_TRYCurrency.source + ".NumericCode") 
                                               [| _TRYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRYCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_TRYCurrency_rounding", Description="Create a TRYCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TRYCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRYCurrency",Description = "Reference to TRYCurrency")>] 
         trycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRYCurrency = Helper.toCell<TRYCurrency> trycurrency "TRYCurrency"  
                let builder () = withMnemonic mnemonic ((TRYCurrencyModel.Cast _TRYCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_TRYCurrency.source + ".Rounding") 
                                               [| _TRYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRYCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TRYCurrency> format
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
    [<ExcelFunction(Name="_TRYCurrency_symbol", Description="Create a TRYCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TRYCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRYCurrency",Description = "Reference to TRYCurrency")>] 
         trycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRYCurrency = Helper.toCell<TRYCurrency> trycurrency "TRYCurrency"  
                let builder () = withMnemonic mnemonic ((TRYCurrencyModel.Cast _TRYCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TRYCurrency.source + ".Symbol") 
                                               [| _TRYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRYCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_TRYCurrency_ToString", Description="Create a TRYCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TRYCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRYCurrency",Description = "Reference to TRYCurrency")>] 
         trycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRYCurrency = Helper.toCell<TRYCurrency> trycurrency "TRYCurrency"  
                let builder () = withMnemonic mnemonic ((TRYCurrencyModel.Cast _TRYCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TRYCurrency.source + ".ToString") 
                                               [| _TRYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRYCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_TRYCurrency_triangulationCurrency", Description="Create a TRYCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TRYCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TRYCurrency",Description = "Reference to TRYCurrency")>] 
         trycurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TRYCurrency = Helper.toCell<TRYCurrency> trycurrency "TRYCurrency"  
                let builder () = withMnemonic mnemonic ((TRYCurrencyModel.Cast _TRYCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_TRYCurrency.source + ".TriangulationCurrency") 
                                               [| _TRYCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TRYCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TRYCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_TRYCurrency_Range", Description="Create a range of TRYCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TRYCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the TRYCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TRYCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<TRYCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<TRYCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<TRYCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
