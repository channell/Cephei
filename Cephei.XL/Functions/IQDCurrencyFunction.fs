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
  The ISO three-letter code is IQD; the numeric code is 368. It is divided in 1000 fils.  currencies
  </summary> *)
[<AutoSerializable(true)>]
module IQDCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_IQDCurrency", Description="Create a IQDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IQDCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.IQDCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IQDCurrency>) l

                let source = Helper.sourceFold "Fun.IQDCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IQDCurrency> format
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
    [<ExcelFunction(Name="_IQDCurrency_code", Description="Create a IQDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IQDCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IQDCurrency",Description = "Reference to IQDCurrency")>] 
         iqdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IQDCurrency = Helper.toCell<IQDCurrency> iqdcurrency "IQDCurrency"  
                let builder () = withMnemonic mnemonic ((IQDCurrencyModel.Cast _IQDCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IQDCurrency.source + ".Code") 
                                               [| _IQDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IQDCurrency.cell
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
    [<ExcelFunction(Name="_IQDCurrency_empty", Description="Create a IQDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IQDCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IQDCurrency",Description = "Reference to IQDCurrency")>] 
         iqdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IQDCurrency = Helper.toCell<IQDCurrency> iqdcurrency "IQDCurrency"  
                let builder () = withMnemonic mnemonic ((IQDCurrencyModel.Cast _IQDCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IQDCurrency.source + ".Empty") 
                                               [| _IQDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IQDCurrency.cell
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
    [<ExcelFunction(Name="_IQDCurrency_Equals", Description="Create a IQDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IQDCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IQDCurrency",Description = "Reference to IQDCurrency")>] 
         iqdcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IQDCurrency = Helper.toCell<IQDCurrency> iqdcurrency "IQDCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((IQDCurrencyModel.Cast _IQDCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IQDCurrency.source + ".Equals") 
                                               [| _IQDCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IQDCurrency.cell
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
    [<ExcelFunction(Name="_IQDCurrency_format", Description="Create a IQDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IQDCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IQDCurrency",Description = "Reference to IQDCurrency")>] 
         iqdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IQDCurrency = Helper.toCell<IQDCurrency> iqdcurrency "IQDCurrency"  
                let builder () = withMnemonic mnemonic ((IQDCurrencyModel.Cast _IQDCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IQDCurrency.source + ".Format") 
                                               [| _IQDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IQDCurrency.cell
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
    [<ExcelFunction(Name="_IQDCurrency_fractionsPerUnit", Description="Create a IQDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IQDCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IQDCurrency",Description = "Reference to IQDCurrency")>] 
         iqdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IQDCurrency = Helper.toCell<IQDCurrency> iqdcurrency "IQDCurrency"  
                let builder () = withMnemonic mnemonic ((IQDCurrencyModel.Cast _IQDCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_IQDCurrency.source + ".FractionsPerUnit") 
                                               [| _IQDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IQDCurrency.cell
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
    [<ExcelFunction(Name="_IQDCurrency_fractionSymbol", Description="Create a IQDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IQDCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IQDCurrency",Description = "Reference to IQDCurrency")>] 
         iqdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IQDCurrency = Helper.toCell<IQDCurrency> iqdcurrency "IQDCurrency"  
                let builder () = withMnemonic mnemonic ((IQDCurrencyModel.Cast _IQDCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IQDCurrency.source + ".FractionSymbol") 
                                               [| _IQDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IQDCurrency.cell
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
    [<ExcelFunction(Name="_IQDCurrency_name", Description="Create a IQDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IQDCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IQDCurrency",Description = "Reference to IQDCurrency")>] 
         iqdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IQDCurrency = Helper.toCell<IQDCurrency> iqdcurrency "IQDCurrency"  
                let builder () = withMnemonic mnemonic ((IQDCurrencyModel.Cast _IQDCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IQDCurrency.source + ".Name") 
                                               [| _IQDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IQDCurrency.cell
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
    [<ExcelFunction(Name="_IQDCurrency_numericCode", Description="Create a IQDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IQDCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IQDCurrency",Description = "Reference to IQDCurrency")>] 
         iqdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IQDCurrency = Helper.toCell<IQDCurrency> iqdcurrency "IQDCurrency"  
                let builder () = withMnemonic mnemonic ((IQDCurrencyModel.Cast _IQDCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_IQDCurrency.source + ".NumericCode") 
                                               [| _IQDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IQDCurrency.cell
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
    [<ExcelFunction(Name="_IQDCurrency_rounding", Description="Create a IQDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IQDCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IQDCurrency",Description = "Reference to IQDCurrency")>] 
         iqdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IQDCurrency = Helper.toCell<IQDCurrency> iqdcurrency "IQDCurrency"  
                let builder () = withMnemonic mnemonic ((IQDCurrencyModel.Cast _IQDCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_IQDCurrency.source + ".Rounding") 
                                               [| _IQDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IQDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IQDCurrency> format
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
    [<ExcelFunction(Name="_IQDCurrency_symbol", Description="Create a IQDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IQDCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IQDCurrency",Description = "Reference to IQDCurrency")>] 
         iqdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IQDCurrency = Helper.toCell<IQDCurrency> iqdcurrency "IQDCurrency"  
                let builder () = withMnemonic mnemonic ((IQDCurrencyModel.Cast _IQDCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IQDCurrency.source + ".Symbol") 
                                               [| _IQDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IQDCurrency.cell
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
    [<ExcelFunction(Name="_IQDCurrency_ToString", Description="Create a IQDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IQDCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IQDCurrency",Description = "Reference to IQDCurrency")>] 
         iqdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IQDCurrency = Helper.toCell<IQDCurrency> iqdcurrency "IQDCurrency"  
                let builder () = withMnemonic mnemonic ((IQDCurrencyModel.Cast _IQDCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IQDCurrency.source + ".ToString") 
                                               [| _IQDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IQDCurrency.cell
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
    [<ExcelFunction(Name="_IQDCurrency_triangulationCurrency", Description="Create a IQDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IQDCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IQDCurrency",Description = "Reference to IQDCurrency")>] 
         iqdcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IQDCurrency = Helper.toCell<IQDCurrency> iqdcurrency "IQDCurrency"  
                let builder () = withMnemonic mnemonic ((IQDCurrencyModel.Cast _IQDCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_IQDCurrency.source + ".TriangulationCurrency") 
                                               [| _IQDCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IQDCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IQDCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_IQDCurrency_Range", Description="Create a range of IQDCurrency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IQDCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the IQDCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<IQDCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<IQDCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<IQDCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<IQDCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
