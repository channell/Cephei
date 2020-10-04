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
  Brazilian real   The ISO three-letter code is BRL; the numeric code is 986. It is divided in 100 centavos.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module BRLCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BRLCurrency", Description="Create a BRLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BRLCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.BRLCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BRLCurrency>) l

                let source = Helper.sourceFold "Fun.BRLCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BRLCurrency> format
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
    [<ExcelFunction(Name="_BRLCurrency_code", Description="Create a BRLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BRLCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BRLCurrency",Description = "Reference to BRLCurrency")>] 
         brlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BRLCurrency = Helper.toCell<BRLCurrency> brlcurrency "BRLCurrency"  
                let builder () = withMnemonic mnemonic ((BRLCurrencyModel.Cast _BRLCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BRLCurrency.source + ".Code") 
                                               [| _BRLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BRLCurrency.cell
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
    [<ExcelFunction(Name="_BRLCurrency_empty", Description="Create a BRLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BRLCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BRLCurrency",Description = "Reference to BRLCurrency")>] 
         brlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BRLCurrency = Helper.toCell<BRLCurrency> brlcurrency "BRLCurrency"  
                let builder () = withMnemonic mnemonic ((BRLCurrencyModel.Cast _BRLCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BRLCurrency.source + ".Empty") 
                                               [| _BRLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BRLCurrency.cell
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
    [<ExcelFunction(Name="_BRLCurrency_Equals", Description="Create a BRLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BRLCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BRLCurrency",Description = "Reference to BRLCurrency")>] 
         brlcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BRLCurrency = Helper.toCell<BRLCurrency> brlcurrency "BRLCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((BRLCurrencyModel.Cast _BRLCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BRLCurrency.source + ".Equals") 
                                               [| _BRLCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BRLCurrency.cell
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
    [<ExcelFunction(Name="_BRLCurrency_format", Description="Create a BRLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BRLCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BRLCurrency",Description = "Reference to BRLCurrency")>] 
         brlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BRLCurrency = Helper.toCell<BRLCurrency> brlcurrency "BRLCurrency"  
                let builder () = withMnemonic mnemonic ((BRLCurrencyModel.Cast _BRLCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BRLCurrency.source + ".Format") 
                                               [| _BRLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BRLCurrency.cell
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
    [<ExcelFunction(Name="_BRLCurrency_fractionsPerUnit", Description="Create a BRLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BRLCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BRLCurrency",Description = "Reference to BRLCurrency")>] 
         brlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BRLCurrency = Helper.toCell<BRLCurrency> brlcurrency "BRLCurrency"  
                let builder () = withMnemonic mnemonic ((BRLCurrencyModel.Cast _BRLCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_BRLCurrency.source + ".FractionsPerUnit") 
                                               [| _BRLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BRLCurrency.cell
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
    [<ExcelFunction(Name="_BRLCurrency_fractionSymbol", Description="Create a BRLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BRLCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BRLCurrency",Description = "Reference to BRLCurrency")>] 
         brlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BRLCurrency = Helper.toCell<BRLCurrency> brlcurrency "BRLCurrency"  
                let builder () = withMnemonic mnemonic ((BRLCurrencyModel.Cast _BRLCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BRLCurrency.source + ".FractionSymbol") 
                                               [| _BRLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BRLCurrency.cell
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
    [<ExcelFunction(Name="_BRLCurrency_name", Description="Create a BRLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BRLCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BRLCurrency",Description = "Reference to BRLCurrency")>] 
         brlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BRLCurrency = Helper.toCell<BRLCurrency> brlcurrency "BRLCurrency"  
                let builder () = withMnemonic mnemonic ((BRLCurrencyModel.Cast _BRLCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BRLCurrency.source + ".Name") 
                                               [| _BRLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BRLCurrency.cell
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
    [<ExcelFunction(Name="_BRLCurrency_numericCode", Description="Create a BRLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BRLCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BRLCurrency",Description = "Reference to BRLCurrency")>] 
         brlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BRLCurrency = Helper.toCell<BRLCurrency> brlcurrency "BRLCurrency"  
                let builder () = withMnemonic mnemonic ((BRLCurrencyModel.Cast _BRLCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_BRLCurrency.source + ".NumericCode") 
                                               [| _BRLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BRLCurrency.cell
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
    [<ExcelFunction(Name="_BRLCurrency_rounding", Description="Create a BRLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BRLCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BRLCurrency",Description = "Reference to BRLCurrency")>] 
         brlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BRLCurrency = Helper.toCell<BRLCurrency> brlcurrency "BRLCurrency"  
                let builder () = withMnemonic mnemonic ((BRLCurrencyModel.Cast _BRLCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_BRLCurrency.source + ".Rounding") 
                                               [| _BRLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BRLCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BRLCurrency> format
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
    [<ExcelFunction(Name="_BRLCurrency_symbol", Description="Create a BRLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BRLCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BRLCurrency",Description = "Reference to BRLCurrency")>] 
         brlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BRLCurrency = Helper.toCell<BRLCurrency> brlcurrency "BRLCurrency"  
                let builder () = withMnemonic mnemonic ((BRLCurrencyModel.Cast _BRLCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BRLCurrency.source + ".Symbol") 
                                               [| _BRLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BRLCurrency.cell
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
    [<ExcelFunction(Name="_BRLCurrency_ToString", Description="Create a BRLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BRLCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BRLCurrency",Description = "Reference to BRLCurrency")>] 
         brlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BRLCurrency = Helper.toCell<BRLCurrency> brlcurrency "BRLCurrency"  
                let builder () = withMnemonic mnemonic ((BRLCurrencyModel.Cast _BRLCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BRLCurrency.source + ".ToString") 
                                               [| _BRLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BRLCurrency.cell
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
    [<ExcelFunction(Name="_BRLCurrency_triangulationCurrency", Description="Create a BRLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BRLCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BRLCurrency",Description = "Reference to BRLCurrency")>] 
         brlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BRLCurrency = Helper.toCell<BRLCurrency> brlcurrency "BRLCurrency"  
                let builder () = withMnemonic mnemonic ((BRLCurrencyModel.Cast _BRLCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_BRLCurrency.source + ".TriangulationCurrency") 
                                               [| _BRLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BRLCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BRLCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_BRLCurrency_Range", Description="Create a range of BRLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BRLCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BRLCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BRLCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BRLCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BRLCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BRLCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
