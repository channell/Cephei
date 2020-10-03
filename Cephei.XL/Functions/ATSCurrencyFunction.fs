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
Austrian shilling The ISO three-letter code was ATS; the numeric code was 40. It was divided in 100 groschen. Obsoleted by the Euro since 1999.
  </summary> *)
[<AutoSerializable(true)>]
module ATSCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ATSCurrency", Description="Create a ATSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ATSCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.ATSCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ATSCurrency>) l

                let source = Helper.sourceFold "Fun.ATSCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ATSCurrency> format
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
    [<ExcelFunction(Name="_ATSCurrency_code", Description="Create a ATSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ATSCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ATSCurrency",Description = "Reference to ATSCurrency")>] 
         atscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ATSCurrency = Helper.toCell<ATSCurrency> atscurrency "ATSCurrency"  
                let builder () = withMnemonic mnemonic ((ATSCurrencyModel.Cast _ATSCurrency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ATSCurrency.source + ".Code") 
                                               [| _ATSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ATSCurrency.cell
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
    [<ExcelFunction(Name="_ATSCurrency_empty", Description="Create a ATSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ATSCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ATSCurrency",Description = "Reference to ATSCurrency")>] 
         atscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ATSCurrency = Helper.toCell<ATSCurrency> atscurrency "ATSCurrency"  
                let builder () = withMnemonic mnemonic ((ATSCurrencyModel.Cast _ATSCurrency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ATSCurrency.source + ".Empty") 
                                               [| _ATSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ATSCurrency.cell
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
    [<ExcelFunction(Name="_ATSCurrency_Equals", Description="Create a ATSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ATSCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ATSCurrency",Description = "Reference to ATSCurrency")>] 
         atscurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ATSCurrency = Helper.toCell<ATSCurrency> atscurrency "ATSCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((ATSCurrencyModel.Cast _ATSCurrency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ATSCurrency.source + ".Equals") 
                                               [| _ATSCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ATSCurrency.cell
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
    [<ExcelFunction(Name="_ATSCurrency_format", Description="Create a ATSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ATSCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ATSCurrency",Description = "Reference to ATSCurrency")>] 
         atscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ATSCurrency = Helper.toCell<ATSCurrency> atscurrency "ATSCurrency"  
                let builder () = withMnemonic mnemonic ((ATSCurrencyModel.Cast _ATSCurrency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ATSCurrency.source + ".Format") 
                                               [| _ATSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ATSCurrency.cell
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
    [<ExcelFunction(Name="_ATSCurrency_fractionsPerUnit", Description="Create a ATSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ATSCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ATSCurrency",Description = "Reference to ATSCurrency")>] 
         atscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ATSCurrency = Helper.toCell<ATSCurrency> atscurrency "ATSCurrency"  
                let builder () = withMnemonic mnemonic ((ATSCurrencyModel.Cast _ATSCurrency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ATSCurrency.source + ".FractionsPerUnit") 
                                               [| _ATSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ATSCurrency.cell
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
    [<ExcelFunction(Name="_ATSCurrency_fractionSymbol", Description="Create a ATSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ATSCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ATSCurrency",Description = "Reference to ATSCurrency")>] 
         atscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ATSCurrency = Helper.toCell<ATSCurrency> atscurrency "ATSCurrency"  
                let builder () = withMnemonic mnemonic ((ATSCurrencyModel.Cast _ATSCurrency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ATSCurrency.source + ".FractionSymbol") 
                                               [| _ATSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ATSCurrency.cell
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
    [<ExcelFunction(Name="_ATSCurrency_name", Description="Create a ATSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ATSCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ATSCurrency",Description = "Reference to ATSCurrency")>] 
         atscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ATSCurrency = Helper.toCell<ATSCurrency> atscurrency "ATSCurrency"  
                let builder () = withMnemonic mnemonic ((ATSCurrencyModel.Cast _ATSCurrency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ATSCurrency.source + ".Name") 
                                               [| _ATSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ATSCurrency.cell
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
    [<ExcelFunction(Name="_ATSCurrency_numericCode", Description="Create a ATSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ATSCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ATSCurrency",Description = "Reference to ATSCurrency")>] 
         atscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ATSCurrency = Helper.toCell<ATSCurrency> atscurrency "ATSCurrency"  
                let builder () = withMnemonic mnemonic ((ATSCurrencyModel.Cast _ATSCurrency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ATSCurrency.source + ".NumericCode") 
                                               [| _ATSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ATSCurrency.cell
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
    [<ExcelFunction(Name="_ATSCurrency_rounding", Description="Create a ATSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ATSCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ATSCurrency",Description = "Reference to ATSCurrency")>] 
         atscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ATSCurrency = Helper.toCell<ATSCurrency> atscurrency "ATSCurrency"  
                let builder () = withMnemonic mnemonic ((ATSCurrencyModel.Cast _ATSCurrency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_ATSCurrency.source + ".Rounding") 
                                               [| _ATSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ATSCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ATSCurrency> format
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
    [<ExcelFunction(Name="_ATSCurrency_symbol", Description="Create a ATSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ATSCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ATSCurrency",Description = "Reference to ATSCurrency")>] 
         atscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ATSCurrency = Helper.toCell<ATSCurrency> atscurrency "ATSCurrency"  
                let builder () = withMnemonic mnemonic ((ATSCurrencyModel.Cast _ATSCurrency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ATSCurrency.source + ".Symbol") 
                                               [| _ATSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ATSCurrency.cell
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
    [<ExcelFunction(Name="_ATSCurrency_ToString", Description="Create a ATSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ATSCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ATSCurrency",Description = "Reference to ATSCurrency")>] 
         atscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ATSCurrency = Helper.toCell<ATSCurrency> atscurrency "ATSCurrency"  
                let builder () = withMnemonic mnemonic ((ATSCurrencyModel.Cast _ATSCurrency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ATSCurrency.source + ".ToString") 
                                               [| _ATSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ATSCurrency.cell
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
    [<ExcelFunction(Name="_ATSCurrency_triangulationCurrency", Description="Create a ATSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ATSCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ATSCurrency",Description = "Reference to ATSCurrency")>] 
         atscurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ATSCurrency = Helper.toCell<ATSCurrency> atscurrency "ATSCurrency"  
                let builder () = withMnemonic mnemonic ((ATSCurrencyModel.Cast _ATSCurrency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_ATSCurrency.source + ".TriangulationCurrency") 
                                               [| _ATSCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ATSCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ATSCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_ATSCurrency_Range", Description="Create a range of ATSCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ATSCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ATSCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ATSCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ATSCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ATSCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ATSCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
