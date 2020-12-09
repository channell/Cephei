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
  Peruvian sol   The ISO three-letter code was PEH. A numeric code is not available as per ISO 3166-1, we assign 999 as a user-defined code. It was divided in 100 centavos.  Obsoleted by the inti since February 1985.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module PEHCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_PEHCurrency", Description="Create a PEHCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PEHCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.PEHCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PEHCurrency>) l

                let source () = Helper.sourceFold "Fun.PEHCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PEHCurrency> format
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
    [<ExcelFunction(Name="_PEHCurrency_code", Description="Create a PEHCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PEHCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PEHCurrency",Description = "PEHCurrency")>] 
         pehcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PEHCurrency = Helper.toCell<PEHCurrency> pehcurrency "PEHCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PEHCurrencyModel.Cast _PEHCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PEHCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PEHCurrency.cell
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
    [<ExcelFunction(Name="_PEHCurrency_empty", Description="Create a PEHCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PEHCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PEHCurrency",Description = "PEHCurrency")>] 
         pehcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PEHCurrency = Helper.toCell<PEHCurrency> pehcurrency "PEHCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PEHCurrencyModel.Cast _PEHCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PEHCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PEHCurrency.cell
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
    [<ExcelFunction(Name="_PEHCurrency_Equals", Description="Create a PEHCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PEHCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PEHCurrency",Description = "PEHCurrency")>] 
         pehcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PEHCurrency = Helper.toCell<PEHCurrency> pehcurrency "PEHCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((PEHCurrencyModel.Cast _PEHCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PEHCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PEHCurrency.cell
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
    [<ExcelFunction(Name="_PEHCurrency_format", Description="Create a PEHCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PEHCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PEHCurrency",Description = "PEHCurrency")>] 
         pehcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PEHCurrency = Helper.toCell<PEHCurrency> pehcurrency "PEHCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PEHCurrencyModel.Cast _PEHCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PEHCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PEHCurrency.cell
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
    [<ExcelFunction(Name="_PEHCurrency_fractionsPerUnit", Description="Create a PEHCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PEHCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PEHCurrency",Description = "PEHCurrency")>] 
         pehcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PEHCurrency = Helper.toCell<PEHCurrency> pehcurrency "PEHCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PEHCurrencyModel.Cast _PEHCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PEHCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PEHCurrency.cell
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
    [<ExcelFunction(Name="_PEHCurrency_fractionSymbol", Description="Create a PEHCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PEHCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PEHCurrency",Description = "PEHCurrency")>] 
         pehcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PEHCurrency = Helper.toCell<PEHCurrency> pehcurrency "PEHCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PEHCurrencyModel.Cast _PEHCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PEHCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PEHCurrency.cell
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
    [<ExcelFunction(Name="_PEHCurrency_name", Description="Create a PEHCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PEHCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PEHCurrency",Description = "PEHCurrency")>] 
         pehcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PEHCurrency = Helper.toCell<PEHCurrency> pehcurrency "PEHCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PEHCurrencyModel.Cast _PEHCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PEHCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PEHCurrency.cell
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
    [<ExcelFunction(Name="_PEHCurrency_numericCode", Description="Create a PEHCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PEHCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PEHCurrency",Description = "PEHCurrency")>] 
         pehcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PEHCurrency = Helper.toCell<PEHCurrency> pehcurrency "PEHCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PEHCurrencyModel.Cast _PEHCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PEHCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PEHCurrency.cell
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
    [<ExcelFunction(Name="_PEHCurrency_rounding", Description="Create a PEHCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PEHCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PEHCurrency",Description = "PEHCurrency")>] 
         pehcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PEHCurrency = Helper.toCell<PEHCurrency> pehcurrency "PEHCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PEHCurrencyModel.Cast _PEHCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_PEHCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PEHCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PEHCurrency> format
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
    [<ExcelFunction(Name="_PEHCurrency_symbol", Description="Create a PEHCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PEHCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PEHCurrency",Description = "PEHCurrency")>] 
         pehcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PEHCurrency = Helper.toCell<PEHCurrency> pehcurrency "PEHCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PEHCurrencyModel.Cast _PEHCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PEHCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PEHCurrency.cell
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
    [<ExcelFunction(Name="_PEHCurrency_ToString", Description="Create a PEHCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PEHCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PEHCurrency",Description = "PEHCurrency")>] 
         pehcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PEHCurrency = Helper.toCell<PEHCurrency> pehcurrency "PEHCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PEHCurrencyModel.Cast _PEHCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PEHCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PEHCurrency.cell
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
    [<ExcelFunction(Name="_PEHCurrency_triangulationCurrency", Description="Create a PEHCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PEHCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PEHCurrency",Description = "PEHCurrency")>] 
         pehcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PEHCurrency = Helper.toCell<PEHCurrency> pehcurrency "PEHCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PEHCurrencyModel.Cast _PEHCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_PEHCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PEHCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PEHCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_PEHCurrency_Range", Description="Create a range of PEHCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PEHCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PEHCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<PEHCurrency> (c)) :> ICell
                let format (i : Generic.List<ICell<PEHCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<PEHCurrency>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
