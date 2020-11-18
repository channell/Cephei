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
module ITLCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ITLCurrency", Description="Create a ITLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ITLCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.ITLCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ITLCurrency>) l

                let source () = Helper.sourceFold "Fun.ITLCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ITLCurrency> format
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
    [<ExcelFunction(Name="_ITLCurrency_code", Description="Create a ITLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ITLCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ITLCurrency",Description = "ITLCurrency")>] 
         itlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ITLCurrency = Helper.toCell<ITLCurrency> itlcurrency "ITLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((ITLCurrencyModel.Cast _ITLCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ITLCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ITLCurrency.cell
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
    [<ExcelFunction(Name="_ITLCurrency_empty", Description="Create a ITLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ITLCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ITLCurrency",Description = "ITLCurrency")>] 
         itlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ITLCurrency = Helper.toCell<ITLCurrency> itlcurrency "ITLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((ITLCurrencyModel.Cast _ITLCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ITLCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ITLCurrency.cell
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
    [<ExcelFunction(Name="_ITLCurrency_Equals", Description="Create a ITLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ITLCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ITLCurrency",Description = "ITLCurrency")>] 
         itlcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ITLCurrency = Helper.toCell<ITLCurrency> itlcurrency "ITLCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((ITLCurrencyModel.Cast _ITLCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ITLCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ITLCurrency.cell
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
    [<ExcelFunction(Name="_ITLCurrency_format", Description="Create a ITLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ITLCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ITLCurrency",Description = "ITLCurrency")>] 
         itlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ITLCurrency = Helper.toCell<ITLCurrency> itlcurrency "ITLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((ITLCurrencyModel.Cast _ITLCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ITLCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ITLCurrency.cell
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
    [<ExcelFunction(Name="_ITLCurrency_fractionsPerUnit", Description="Create a ITLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ITLCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ITLCurrency",Description = "ITLCurrency")>] 
         itlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ITLCurrency = Helper.toCell<ITLCurrency> itlcurrency "ITLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((ITLCurrencyModel.Cast _ITLCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ITLCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ITLCurrency.cell
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
    [<ExcelFunction(Name="_ITLCurrency_fractionSymbol", Description="Create a ITLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ITLCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ITLCurrency",Description = "ITLCurrency")>] 
         itlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ITLCurrency = Helper.toCell<ITLCurrency> itlcurrency "ITLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((ITLCurrencyModel.Cast _ITLCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ITLCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ITLCurrency.cell
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
    [<ExcelFunction(Name="_ITLCurrency_name", Description="Create a ITLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ITLCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ITLCurrency",Description = "ITLCurrency")>] 
         itlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ITLCurrency = Helper.toCell<ITLCurrency> itlcurrency "ITLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((ITLCurrencyModel.Cast _ITLCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ITLCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ITLCurrency.cell
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
    [<ExcelFunction(Name="_ITLCurrency_numericCode", Description="Create a ITLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ITLCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ITLCurrency",Description = "ITLCurrency")>] 
         itlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ITLCurrency = Helper.toCell<ITLCurrency> itlcurrency "ITLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((ITLCurrencyModel.Cast _ITLCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ITLCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ITLCurrency.cell
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
    [<ExcelFunction(Name="_ITLCurrency_rounding", Description="Create a ITLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ITLCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ITLCurrency",Description = "ITLCurrency")>] 
         itlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ITLCurrency = Helper.toCell<ITLCurrency> itlcurrency "ITLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((ITLCurrencyModel.Cast _ITLCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_ITLCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ITLCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ITLCurrency> format
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
    [<ExcelFunction(Name="_ITLCurrency_symbol", Description="Create a ITLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ITLCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ITLCurrency",Description = "ITLCurrency")>] 
         itlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ITLCurrency = Helper.toCell<ITLCurrency> itlcurrency "ITLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((ITLCurrencyModel.Cast _ITLCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ITLCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ITLCurrency.cell
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
    [<ExcelFunction(Name="_ITLCurrency_ToString", Description="Create a ITLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ITLCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ITLCurrency",Description = "ITLCurrency")>] 
         itlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ITLCurrency = Helper.toCell<ITLCurrency> itlcurrency "ITLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((ITLCurrencyModel.Cast _ITLCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ITLCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ITLCurrency.cell
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
    [<ExcelFunction(Name="_ITLCurrency_triangulationCurrency", Description="Create a ITLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ITLCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ITLCurrency",Description = "ITLCurrency")>] 
         itlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ITLCurrency = Helper.toCell<ITLCurrency> itlcurrency "ITLCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((ITLCurrencyModel.Cast _ITLCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_ITLCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ITLCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ITLCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_ITLCurrency_Range", Description="Create a range of ITLCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ITLCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ITLCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<ITLCurrency> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<ITLCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<ITLCurrency>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
