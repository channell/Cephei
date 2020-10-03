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
module ISKCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ISKCurrency", Description="Create a ISKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ISKCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.ISKCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ISKCurrency>) l

                let source = Helper.sourceFold "Fun.ISKCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ISKCurrency> format
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
    [<ExcelFunction(Name="_ISKCurrency_code", Description="Create a ISKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ISKCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ISKCurrency",Description = "Reference to ISKCurrency")>] 
         iskcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ISKCurrency = Helper.toCell<ISKCurrency> iskcurrency "ISKCurrency"  
                let builder () = withMnemonic mnemonic ((ISKCurrencyModel.Cast _ISKCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ISKCurrency.source + ".Code") 
                                               [| _ISKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ISKCurrency.cell
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
    [<ExcelFunction(Name="_ISKCurrency_empty", Description="Create a ISKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ISKCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ISKCurrency",Description = "Reference to ISKCurrency")>] 
         iskcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ISKCurrency = Helper.toCell<ISKCurrency> iskcurrency "ISKCurrency"  
                let builder () = withMnemonic mnemonic ((ISKCurrencyModel.Cast _ISKCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ISKCurrency.source + ".Empty") 
                                               [| _ISKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ISKCurrency.cell
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
    [<ExcelFunction(Name="_ISKCurrency_Equals", Description="Create a ISKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ISKCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ISKCurrency",Description = "Reference to ISKCurrency")>] 
         iskcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ISKCurrency = Helper.toCell<ISKCurrency> iskcurrency "ISKCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((ISKCurrencyModel.Cast _ISKCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ISKCurrency.source + ".Equals") 
                                               [| _ISKCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ISKCurrency.cell
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
    [<ExcelFunction(Name="_ISKCurrency_format", Description="Create a ISKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ISKCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ISKCurrency",Description = "Reference to ISKCurrency")>] 
         iskcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ISKCurrency = Helper.toCell<ISKCurrency> iskcurrency "ISKCurrency"  
                let builder () = withMnemonic mnemonic ((ISKCurrencyModel.Cast _ISKCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ISKCurrency.source + ".Format") 
                                               [| _ISKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ISKCurrency.cell
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
    [<ExcelFunction(Name="_ISKCurrency_fractionsPerUnit", Description="Create a ISKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ISKCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ISKCurrency",Description = "Reference to ISKCurrency")>] 
         iskcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ISKCurrency = Helper.toCell<ISKCurrency> iskcurrency "ISKCurrency"  
                let builder () = withMnemonic mnemonic ((ISKCurrencyModel.Cast _ISKCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ISKCurrency.source + ".FractionsPerUnit") 
                                               [| _ISKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ISKCurrency.cell
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
    [<ExcelFunction(Name="_ISKCurrency_fractionSymbol", Description="Create a ISKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ISKCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ISKCurrency",Description = "Reference to ISKCurrency")>] 
         iskcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ISKCurrency = Helper.toCell<ISKCurrency> iskcurrency "ISKCurrency"  
                let builder () = withMnemonic mnemonic ((ISKCurrencyModel.Cast _ISKCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ISKCurrency.source + ".FractionSymbol") 
                                               [| _ISKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ISKCurrency.cell
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
    [<ExcelFunction(Name="_ISKCurrency_name", Description="Create a ISKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ISKCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ISKCurrency",Description = "Reference to ISKCurrency")>] 
         iskcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ISKCurrency = Helper.toCell<ISKCurrency> iskcurrency "ISKCurrency"  
                let builder () = withMnemonic mnemonic ((ISKCurrencyModel.Cast _ISKCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ISKCurrency.source + ".Name") 
                                               [| _ISKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ISKCurrency.cell
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
    [<ExcelFunction(Name="_ISKCurrency_numericCode", Description="Create a ISKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ISKCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ISKCurrency",Description = "Reference to ISKCurrency")>] 
         iskcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ISKCurrency = Helper.toCell<ISKCurrency> iskcurrency "ISKCurrency"  
                let builder () = withMnemonic mnemonic ((ISKCurrencyModel.Cast _ISKCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ISKCurrency.source + ".NumericCode") 
                                               [| _ISKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ISKCurrency.cell
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
    [<ExcelFunction(Name="_ISKCurrency_rounding", Description="Create a ISKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ISKCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ISKCurrency",Description = "Reference to ISKCurrency")>] 
         iskcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ISKCurrency = Helper.toCell<ISKCurrency> iskcurrency "ISKCurrency"  
                let builder () = withMnemonic mnemonic ((ISKCurrencyModel.Cast _ISKCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_ISKCurrency.source + ".Rounding") 
                                               [| _ISKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ISKCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ISKCurrency> format
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
    [<ExcelFunction(Name="_ISKCurrency_symbol", Description="Create a ISKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ISKCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ISKCurrency",Description = "Reference to ISKCurrency")>] 
         iskcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ISKCurrency = Helper.toCell<ISKCurrency> iskcurrency "ISKCurrency"  
                let builder () = withMnemonic mnemonic ((ISKCurrencyModel.Cast _ISKCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ISKCurrency.source + ".Symbol") 
                                               [| _ISKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ISKCurrency.cell
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
    [<ExcelFunction(Name="_ISKCurrency_ToString", Description="Create a ISKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ISKCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ISKCurrency",Description = "Reference to ISKCurrency")>] 
         iskcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ISKCurrency = Helper.toCell<ISKCurrency> iskcurrency "ISKCurrency"  
                let builder () = withMnemonic mnemonic ((ISKCurrencyModel.Cast _ISKCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ISKCurrency.source + ".ToString") 
                                               [| _ISKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ISKCurrency.cell
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
    [<ExcelFunction(Name="_ISKCurrency_triangulationCurrency", Description="Create a ISKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ISKCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ISKCurrency",Description = "Reference to ISKCurrency")>] 
         iskcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ISKCurrency = Helper.toCell<ISKCurrency> iskcurrency "ISKCurrency"  
                let builder () = withMnemonic mnemonic ((ISKCurrencyModel.Cast _ISKCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_ISKCurrency.source + ".TriangulationCurrency") 
                                               [| _ISKCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ISKCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ISKCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_ISKCurrency_Range", Description="Create a range of ISKCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ISKCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ISKCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ISKCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ISKCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ISKCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ISKCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
