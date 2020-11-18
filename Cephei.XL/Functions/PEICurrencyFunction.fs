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
  Peruvian inti   The ISO three-letter code was PEI. It was divided in 100 centimos. A numeric code is not available as per ISO 3166-1, we assign 998 as a user-defined code.  Obsoleted by the nuevo sol since July 1991.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module PEICurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_PEICurrency", Description="Create a PEICurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PEICurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.PEICurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PEICurrency>) l

                let source () = Helper.sourceFold "Fun.PEICurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PEICurrency> format
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
    [<ExcelFunction(Name="_PEICurrency_code", Description="Create a PEICurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PEICurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PEICurrency",Description = "PEICurrency")>] 
         peicurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PEICurrency = Helper.toCell<PEICurrency> peicurrency "PEICurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PEICurrencyModel.Cast _PEICurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PEICurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PEICurrency.cell
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
    [<ExcelFunction(Name="_PEICurrency_empty", Description="Create a PEICurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PEICurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PEICurrency",Description = "PEICurrency")>] 
         peicurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PEICurrency = Helper.toCell<PEICurrency> peicurrency "PEICurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PEICurrencyModel.Cast _PEICurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PEICurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PEICurrency.cell
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
    [<ExcelFunction(Name="_PEICurrency_Equals", Description="Create a PEICurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PEICurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PEICurrency",Description = "PEICurrency")>] 
         peicurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PEICurrency = Helper.toCell<PEICurrency> peicurrency "PEICurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((PEICurrencyModel.Cast _PEICurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PEICurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PEICurrency.cell
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
    [<ExcelFunction(Name="_PEICurrency_format", Description="Create a PEICurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PEICurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PEICurrency",Description = "PEICurrency")>] 
         peicurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PEICurrency = Helper.toCell<PEICurrency> peicurrency "PEICurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PEICurrencyModel.Cast _PEICurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PEICurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PEICurrency.cell
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
    [<ExcelFunction(Name="_PEICurrency_fractionsPerUnit", Description="Create a PEICurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PEICurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PEICurrency",Description = "PEICurrency")>] 
         peicurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PEICurrency = Helper.toCell<PEICurrency> peicurrency "PEICurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PEICurrencyModel.Cast _PEICurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PEICurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PEICurrency.cell
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
    [<ExcelFunction(Name="_PEICurrency_fractionSymbol", Description="Create a PEICurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PEICurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PEICurrency",Description = "PEICurrency")>] 
         peicurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PEICurrency = Helper.toCell<PEICurrency> peicurrency "PEICurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PEICurrencyModel.Cast _PEICurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PEICurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PEICurrency.cell
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
    [<ExcelFunction(Name="_PEICurrency_name", Description="Create a PEICurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PEICurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PEICurrency",Description = "PEICurrency")>] 
         peicurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PEICurrency = Helper.toCell<PEICurrency> peicurrency "PEICurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PEICurrencyModel.Cast _PEICurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PEICurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PEICurrency.cell
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
    [<ExcelFunction(Name="_PEICurrency_numericCode", Description="Create a PEICurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PEICurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PEICurrency",Description = "PEICurrency")>] 
         peicurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PEICurrency = Helper.toCell<PEICurrency> peicurrency "PEICurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PEICurrencyModel.Cast _PEICurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PEICurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PEICurrency.cell
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
    [<ExcelFunction(Name="_PEICurrency_rounding", Description="Create a PEICurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PEICurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PEICurrency",Description = "PEICurrency")>] 
         peicurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PEICurrency = Helper.toCell<PEICurrency> peicurrency "PEICurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PEICurrencyModel.Cast _PEICurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_PEICurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PEICurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PEICurrency> format
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
    [<ExcelFunction(Name="_PEICurrency_symbol", Description="Create a PEICurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PEICurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PEICurrency",Description = "PEICurrency")>] 
         peicurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PEICurrency = Helper.toCell<PEICurrency> peicurrency "PEICurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PEICurrencyModel.Cast _PEICurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PEICurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PEICurrency.cell
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
    [<ExcelFunction(Name="_PEICurrency_ToString", Description="Create a PEICurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PEICurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PEICurrency",Description = "PEICurrency")>] 
         peicurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PEICurrency = Helper.toCell<PEICurrency> peicurrency "PEICurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PEICurrencyModel.Cast _PEICurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PEICurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PEICurrency.cell
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
    [<ExcelFunction(Name="_PEICurrency_triangulationCurrency", Description="Create a PEICurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PEICurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PEICurrency",Description = "PEICurrency")>] 
         peicurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PEICurrency = Helper.toCell<PEICurrency> peicurrency "PEICurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((PEICurrencyModel.Cast _PEICurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_PEICurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PEICurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PEICurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_PEICurrency_Range", Description="Create a range of PEICurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PEICurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PEICurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<PEICurrency> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<PEICurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<PEICurrency>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
