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
  %Currency specification
  </summary> *)
[<AutoSerializable(true)>]
module CurrencyFunction =

    (*
        ! currency name, e.g, "U.S. Dollar"
    *)
    [<ExcelFunction(Name="_Currency_code", Description="Create a Currency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Currency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Currency",Description = "Reference to Currency")>] 
         currency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Currency = Helper.toCell<Currency> currency "Currency"  
                let builder () = withMnemonic mnemonic ((CurrencyModel.Cast _Currency.cell).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Currency.source + ".Code") 
                                               [| _Currency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Currency.cell
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
    [<ExcelFunction(Name="_Currency1", Description="Create a Currency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Currency_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="name",Description = "Reference to name")>] 
         name : obj)
        ([<ExcelArgument(Name="code",Description = "Reference to code")>] 
         code : obj)
        ([<ExcelArgument(Name="numericCode",Description = "Reference to numericCode")>] 
         numericCode : obj)
        ([<ExcelArgument(Name="symbol",Description = "Reference to symbol")>] 
         symbol : obj)
        ([<ExcelArgument(Name="fractionSymbol",Description = "Reference to fractionSymbol")>] 
         fractionSymbol : obj)
        ([<ExcelArgument(Name="fractionsPerUnit",Description = "Reference to fractionsPerUnit")>] 
         fractionsPerUnit : obj)
        ([<ExcelArgument(Name="rounding",Description = "Reference to rounding")>] 
         rounding : obj)
        ([<ExcelArgument(Name="formatString",Description = "Reference to formatString")>] 
         formatString : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _name = Helper.toCell<string> name "name" 
                let _code = Helper.toCell<string> code "code" 
                let _numericCode = Helper.toCell<int> numericCode "numericCode" 
                let _symbol = Helper.toCell<string> symbol "symbol" 
                let _fractionSymbol = Helper.toCell<string> fractionSymbol "fractionSymbol" 
                let _fractionsPerUnit = Helper.toCell<int> fractionsPerUnit "fractionsPerUnit" 
                let _rounding = Helper.toCell<Rounding> rounding "rounding" 
                let _formatString = Helper.toCell<string> formatString "formatString" 
                let builder () = withMnemonic mnemonic (Fun.Currency1 
                                                            _name.cell 
                                                            _code.cell 
                                                            _numericCode.cell 
                                                            _symbol.cell 
                                                            _fractionSymbol.cell 
                                                            _fractionsPerUnit.cell 
                                                            _rounding.cell 
                                                            _formatString.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold "Fun.Currency1" 
                                               [| _name.source
                                               ;  _code.source
                                               ;  _numericCode.source
                                               ;  _symbol.source
                                               ;  _fractionSymbol.source
                                               ;  _fractionsPerUnit.source
                                               ;  _rounding.source
                                               ;  _formatString.source
                                               |]
                let hash = Helper.hashFold 
                                [| _name.cell
                                ;  _code.cell
                                ;  _numericCode.cell
                                ;  _symbol.cell
                                ;  _fractionSymbol.cell
                                ;  _fractionsPerUnit.cell
                                ;  _rounding.cell
                                ;  _formatString.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Currency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        default constructor Instances built via this constructor have undefined behavior. Such instances can only act as placeholders and must be reassigned to a valid currency before being used.
    *)
    [<ExcelFunction(Name="_Currency", Description="Create a Currency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Currency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Currency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold "Fun.Currency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Currency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Currency2", Description="Create a Currency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Currency_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="name",Description = "Reference to name")>] 
         name : obj)
        ([<ExcelArgument(Name="code",Description = "Reference to code")>] 
         code : obj)
        ([<ExcelArgument(Name="numericCode",Description = "Reference to numericCode")>] 
         numericCode : obj)
        ([<ExcelArgument(Name="symbol",Description = "Reference to symbol")>] 
         symbol : obj)
        ([<ExcelArgument(Name="fractionSymbol",Description = "Reference to fractionSymbol")>] 
         fractionSymbol : obj)
        ([<ExcelArgument(Name="fractionsPerUnit",Description = "Reference to fractionsPerUnit")>] 
         fractionsPerUnit : obj)
        ([<ExcelArgument(Name="rounding",Description = "Reference to rounding")>] 
         rounding : obj)
        ([<ExcelArgument(Name="formatString",Description = "Reference to formatString")>] 
         formatString : obj)
        ([<ExcelArgument(Name="triangulationCurrency",Description = "Reference to triangulationCurrency")>] 
         triangulationCurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _name = Helper.toCell<string> name "name" 
                let _code = Helper.toCell<string> code "code" 
                let _numericCode = Helper.toCell<int> numericCode "numericCode" 
                let _symbol = Helper.toCell<string> symbol "symbol" 
                let _fractionSymbol = Helper.toCell<string> fractionSymbol "fractionSymbol" 
                let _fractionsPerUnit = Helper.toCell<int> fractionsPerUnit "fractionsPerUnit" 
                let _rounding = Helper.toCell<Rounding> rounding "rounding" 
                let _formatString = Helper.toCell<string> formatString "formatString" 
                let _triangulationCurrency = Helper.toCell<Currency> triangulationCurrency "triangulationCurrency" 
                let builder () = withMnemonic mnemonic (Fun.Currency2 
                                                            _name.cell 
                                                            _code.cell 
                                                            _numericCode.cell 
                                                            _symbol.cell 
                                                            _fractionSymbol.cell 
                                                            _fractionsPerUnit.cell 
                                                            _rounding.cell 
                                                            _formatString.cell 
                                                            _triangulationCurrency.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold "Fun.Currency2" 
                                               [| _name.source
                                               ;  _code.source
                                               ;  _numericCode.source
                                               ;  _symbol.source
                                               ;  _fractionSymbol.source
                                               ;  _fractionsPerUnit.source
                                               ;  _rounding.source
                                               ;  _formatString.source
                                               ;  _triangulationCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _name.cell
                                ;  _code.cell
                                ;  _numericCode.cell
                                ;  _symbol.cell
                                ;  _fractionSymbol.cell
                                ;  _fractionsPerUnit.cell
                                ;  _rounding.cell
                                ;  _formatString.cell
                                ;  _triangulationCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Currency> format
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
    [<ExcelFunction(Name="_Currency_empty", Description="Create a Currency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Currency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Currency",Description = "Reference to Currency")>] 
         currency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Currency = Helper.toCell<Currency> currency "Currency"  
                let builder () = withMnemonic mnemonic ((CurrencyModel.Cast _Currency.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Currency.source + ".Empty") 
                                               [| _Currency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Currency.cell
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
    [<ExcelFunction(Name="_Currency_Equals", Description="Create a Currency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Currency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Currency",Description = "Reference to Currency")>] 
         currency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Currency = Helper.toCell<Currency> currency "Currency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((CurrencyModel.Cast _Currency.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Currency.source + ".Equals") 
                                               [| _Currency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Currency.cell
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
    [<ExcelFunction(Name="_Currency_format", Description="Create a Currency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Currency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Currency",Description = "Reference to Currency")>] 
         currency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Currency = Helper.toCell<Currency> currency "Currency"  
                let builder () = withMnemonic mnemonic ((CurrencyModel.Cast _Currency.cell).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Currency.source + ".Format") 
                                               [| _Currency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Currency.cell
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
    [<ExcelFunction(Name="_Currency_fractionsPerUnit", Description="Create a Currency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Currency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Currency",Description = "Reference to Currency")>] 
         currency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Currency = Helper.toCell<Currency> currency "Currency"  
                let builder () = withMnemonic mnemonic ((CurrencyModel.Cast _Currency.cell).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Currency.source + ".FractionsPerUnit") 
                                               [| _Currency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Currency.cell
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
    [<ExcelFunction(Name="_Currency_fractionSymbol", Description="Create a Currency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Currency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Currency",Description = "Reference to Currency")>] 
         currency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Currency = Helper.toCell<Currency> currency "Currency"  
                let builder () = withMnemonic mnemonic ((CurrencyModel.Cast _Currency.cell).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Currency.source + ".FractionSymbol") 
                                               [| _Currency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Currency.cell
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
    [<ExcelFunction(Name="_Currency_name", Description="Create a Currency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Currency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Currency",Description = "Reference to Currency")>] 
         currency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Currency = Helper.toCell<Currency> currency "Currency"  
                let builder () = withMnemonic mnemonic ((CurrencyModel.Cast _Currency.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Currency.source + ".Name") 
                                               [| _Currency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Currency.cell
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
    [<ExcelFunction(Name="_Currency_numericCode", Description="Create a Currency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Currency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Currency",Description = "Reference to Currency")>] 
         currency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Currency = Helper.toCell<Currency> currency "Currency"  
                let builder () = withMnemonic mnemonic ((CurrencyModel.Cast _Currency.cell).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Currency.source + ".NumericCode") 
                                               [| _Currency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Currency.cell
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
    [<ExcelFunction(Name="_Currency_rounding", Description="Create a Currency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Currency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Currency",Description = "Reference to Currency")>] 
         currency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Currency = Helper.toCell<Currency> currency "Currency"  
                let builder () = withMnemonic mnemonic ((CurrencyModel.Cast _Currency.cell).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_Currency.source + ".Rounding") 
                                               [| _Currency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Currency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Currency> format
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
    [<ExcelFunction(Name="_Currency_symbol", Description="Create a Currency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Currency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Currency",Description = "Reference to Currency")>] 
         currency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Currency = Helper.toCell<Currency> currency "Currency"  
                let builder () = withMnemonic mnemonic ((CurrencyModel.Cast _Currency.cell).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Currency.source + ".Symbol") 
                                               [| _Currency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Currency.cell
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
    [<ExcelFunction(Name="_Currency_ToString", Description="Create a Currency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Currency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Currency",Description = "Reference to Currency")>] 
         currency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Currency = Helper.toCell<Currency> currency "Currency"  
                let builder () = withMnemonic mnemonic ((CurrencyModel.Cast _Currency.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Currency.source + ".ToString") 
                                               [| _Currency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Currency.cell
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
    [<ExcelFunction(Name="_Currency_triangulationCurrency", Description="Create a Currency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Currency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Currency",Description = "Reference to Currency")>] 
         currency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Currency = Helper.toCell<Currency> currency "Currency"  
                let builder () = withMnemonic mnemonic ((CurrencyModel.Cast _Currency.cell).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_Currency.source + ".TriangulationCurrency") 
                                               [| _Currency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Currency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Currency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_Currency_Range", Description="Create a range of Currency",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Currency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Currency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Currency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Currency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Currency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Currency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
