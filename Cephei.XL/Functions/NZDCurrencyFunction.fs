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
  New Zealand dollar   The ISO three-letter code is NZD; the numeric code is 554. It is divided in 100 cents.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module NZDCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_NZDCurrency", Description="Create a NZDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.NZDCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NZDCurrency>) l

                let source () = Helper.sourceFold "Fun.NZDCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NZDCurrency> format
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
    [<ExcelFunction(Name="_NZDCurrency_code", Description="Create a NZDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDCurrency",Description = "NZDCurrency")>] 
         nzdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDCurrency = Helper.toCell<NZDCurrency> nzdcurrency "NZDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((NZDCurrencyModel.Cast _NZDCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NZDCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NZDCurrency.cell
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
    [<ExcelFunction(Name="_NZDCurrency_empty", Description="Create a NZDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDCurrency",Description = "NZDCurrency")>] 
         nzdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDCurrency = Helper.toCell<NZDCurrency> nzdcurrency "NZDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((NZDCurrencyModel.Cast _NZDCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NZDCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NZDCurrency.cell
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
    [<ExcelFunction(Name="_NZDCurrency_Equals", Description="Create a NZDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDCurrency",Description = "NZDCurrency")>] 
         nzdcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDCurrency = Helper.toCell<NZDCurrency> nzdcurrency "NZDCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((NZDCurrencyModel.Cast _NZDCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NZDCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDCurrency.cell
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
    [<ExcelFunction(Name="_NZDCurrency_format", Description="Create a NZDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDCurrency",Description = "NZDCurrency")>] 
         nzdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDCurrency = Helper.toCell<NZDCurrency> nzdcurrency "NZDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((NZDCurrencyModel.Cast _NZDCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NZDCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NZDCurrency.cell
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
    [<ExcelFunction(Name="_NZDCurrency_fractionsPerUnit", Description="Create a NZDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDCurrency",Description = "NZDCurrency")>] 
         nzdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDCurrency = Helper.toCell<NZDCurrency> nzdcurrency "NZDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((NZDCurrencyModel.Cast _NZDCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NZDCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NZDCurrency.cell
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
    [<ExcelFunction(Name="_NZDCurrency_fractionSymbol", Description="Create a NZDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDCurrency",Description = "NZDCurrency")>] 
         nzdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDCurrency = Helper.toCell<NZDCurrency> nzdcurrency "NZDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((NZDCurrencyModel.Cast _NZDCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NZDCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NZDCurrency.cell
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
    [<ExcelFunction(Name="_NZDCurrency_name", Description="Create a NZDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDCurrency",Description = "NZDCurrency")>] 
         nzdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDCurrency = Helper.toCell<NZDCurrency> nzdcurrency "NZDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((NZDCurrencyModel.Cast _NZDCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NZDCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NZDCurrency.cell
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
    [<ExcelFunction(Name="_NZDCurrency_numericCode", Description="Create a NZDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDCurrency",Description = "NZDCurrency")>] 
         nzdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDCurrency = Helper.toCell<NZDCurrency> nzdcurrency "NZDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((NZDCurrencyModel.Cast _NZDCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NZDCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NZDCurrency.cell
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
    [<ExcelFunction(Name="_NZDCurrency_rounding", Description="Create a NZDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDCurrency",Description = "NZDCurrency")>] 
         nzdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDCurrency = Helper.toCell<NZDCurrency> nzdcurrency "NZDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((NZDCurrencyModel.Cast _NZDCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_NZDCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NZDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NZDCurrency> format
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
    [<ExcelFunction(Name="_NZDCurrency_symbol", Description="Create a NZDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDCurrency",Description = "NZDCurrency")>] 
         nzdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDCurrency = Helper.toCell<NZDCurrency> nzdcurrency "NZDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((NZDCurrencyModel.Cast _NZDCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NZDCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NZDCurrency.cell
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
    [<ExcelFunction(Name="_NZDCurrency_ToString", Description="Create a NZDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDCurrency",Description = "NZDCurrency")>] 
         nzdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDCurrency = Helper.toCell<NZDCurrency> nzdcurrency "NZDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((NZDCurrencyModel.Cast _NZDCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NZDCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NZDCurrency.cell
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
    [<ExcelFunction(Name="_NZDCurrency_triangulationCurrency", Description="Create a NZDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDCurrency",Description = "NZDCurrency")>] 
         nzdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDCurrency = Helper.toCell<NZDCurrency> nzdcurrency "NZDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((NZDCurrencyModel.Cast _NZDCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_NZDCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NZDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NZDCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_NZDCurrency_Range", Description="Create a range of NZDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<NZDCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<NZDCurrency> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<NZDCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<NZDCurrency>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
