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
module GRDCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GRDCurrency", Description="Create a GRDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GRDCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.GRDCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GRDCurrency>) l

                let source () = Helper.sourceFold "Fun.GRDCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GRDCurrency> format
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
    [<ExcelFunction(Name="_GRDCurrency_code", Description="Create a GRDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GRDCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GRDCurrency",Description = "GRDCurrency")>] 
         grdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GRDCurrency = Helper.toCell<GRDCurrency> grdcurrency "GRDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((GRDCurrencyModel.Cast _GRDCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GRDCurrency.source + ".Code") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GRDCurrency.cell
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
    [<ExcelFunction(Name="_GRDCurrency_empty", Description="Create a GRDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GRDCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GRDCurrency",Description = "GRDCurrency")>] 
         grdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GRDCurrency = Helper.toCell<GRDCurrency> grdcurrency "GRDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((GRDCurrencyModel.Cast _GRDCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GRDCurrency.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GRDCurrency.cell
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
    [<ExcelFunction(Name="_GRDCurrency_Equals", Description="Create a GRDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GRDCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GRDCurrency",Description = "GRDCurrency")>] 
         grdcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GRDCurrency = Helper.toCell<GRDCurrency> grdcurrency "GRDCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((GRDCurrencyModel.Cast _GRDCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GRDCurrency.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GRDCurrency.cell
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
    [<ExcelFunction(Name="_GRDCurrency_format", Description="Create a GRDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GRDCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GRDCurrency",Description = "GRDCurrency")>] 
         grdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GRDCurrency = Helper.toCell<GRDCurrency> grdcurrency "GRDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((GRDCurrencyModel.Cast _GRDCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GRDCurrency.source + ".Format") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GRDCurrency.cell
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
    [<ExcelFunction(Name="_GRDCurrency_fractionsPerUnit", Description="Create a GRDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GRDCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GRDCurrency",Description = "GRDCurrency")>] 
         grdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GRDCurrency = Helper.toCell<GRDCurrency> grdcurrency "GRDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((GRDCurrencyModel.Cast _GRDCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GRDCurrency.source + ".FractionsPerUnit") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GRDCurrency.cell
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
    [<ExcelFunction(Name="_GRDCurrency_fractionSymbol", Description="Create a GRDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GRDCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GRDCurrency",Description = "GRDCurrency")>] 
         grdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GRDCurrency = Helper.toCell<GRDCurrency> grdcurrency "GRDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((GRDCurrencyModel.Cast _GRDCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GRDCurrency.source + ".FractionSymbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GRDCurrency.cell
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
    [<ExcelFunction(Name="_GRDCurrency_name", Description="Create a GRDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GRDCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GRDCurrency",Description = "GRDCurrency")>] 
         grdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GRDCurrency = Helper.toCell<GRDCurrency> grdcurrency "GRDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((GRDCurrencyModel.Cast _GRDCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GRDCurrency.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GRDCurrency.cell
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
    [<ExcelFunction(Name="_GRDCurrency_numericCode", Description="Create a GRDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GRDCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GRDCurrency",Description = "GRDCurrency")>] 
         grdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GRDCurrency = Helper.toCell<GRDCurrency> grdcurrency "GRDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((GRDCurrencyModel.Cast _GRDCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GRDCurrency.source + ".NumericCode") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GRDCurrency.cell
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
    [<ExcelFunction(Name="_GRDCurrency_rounding", Description="Create a GRDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GRDCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GRDCurrency",Description = "GRDCurrency")>] 
         grdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GRDCurrency = Helper.toCell<GRDCurrency> grdcurrency "GRDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((GRDCurrencyModel.Cast _GRDCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source () = Helper.sourceFold (_GRDCurrency.source + ".Rounding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GRDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GRDCurrency> format
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
    [<ExcelFunction(Name="_GRDCurrency_symbol", Description="Create a GRDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GRDCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GRDCurrency",Description = "GRDCurrency")>] 
         grdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GRDCurrency = Helper.toCell<GRDCurrency> grdcurrency "GRDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((GRDCurrencyModel.Cast _GRDCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GRDCurrency.source + ".Symbol") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GRDCurrency.cell
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
    [<ExcelFunction(Name="_GRDCurrency_ToString", Description="Create a GRDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GRDCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GRDCurrency",Description = "GRDCurrency")>] 
         grdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GRDCurrency = Helper.toCell<GRDCurrency> grdcurrency "GRDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((GRDCurrencyModel.Cast _GRDCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GRDCurrency.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GRDCurrency.cell
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
    [<ExcelFunction(Name="_GRDCurrency_triangulationCurrency", Description="Create a GRDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GRDCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GRDCurrency",Description = "GRDCurrency")>] 
         grdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GRDCurrency = Helper.toCell<GRDCurrency> grdcurrency "GRDCurrency"  
                let builder (current : ICell) = withMnemonic mnemonic ((GRDCurrencyModel.Cast _GRDCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_GRDCurrency.source + ".TriangulationCurrency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GRDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GRDCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_GRDCurrency_Range", Description="Create a range of GRDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GRDCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GRDCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<GRDCurrency> (c)) :> ICell
                let format (i : Generic.List<ICell<GRDCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<GRDCurrency>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
