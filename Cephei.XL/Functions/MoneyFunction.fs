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
module MoneyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Money_currency", Description="Create a Money",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Money_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Money",Description = "Reference to Money")>] 
         money : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Money = Helper.toCell<Money> money "Money" true 
                let builder () = withMnemonic mnemonic ((_Money.cell :?> MoneyModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_Money.source + ".Currency") 
                                               [| _Money.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Money.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Money_Equals", Description="Create a Money",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Money_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Money",Description = "Reference to Money")>] 
         money : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Money = Helper.toCell<Money> money "Money" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_Money.cell :?> MoneyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Money.source + ".Equals") 
                                               [| _Money.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Money.cell
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
        
    *)
    [<ExcelFunction(Name="_Money1", Description="Create a Money",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Money_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="currency",Description = "Reference to currency")>] 
         currency : obj)
        ([<ExcelArgument(Name="value",Description = "Reference to value")>] 
         value : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _currency = Helper.toCell<Currency> currency "currency" true
                let _value = Helper.toCell<double> value "value" true
                let builder () = withMnemonic mnemonic (Fun.Money1 
                                                            _currency.cell 
                                                            _value.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Money>) l

                let source = Helper.sourceFold "Fun.Money1" 
                                               [| _currency.source
                                               ;  _value.source
                                               |]
                let hash = Helper.hashFold 
                                [| _currency.cell
                                ;  _value.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Money", Description="Create a Money",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Money_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Money ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Money>) l

                let source = Helper.sourceFold "Fun.Money" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Money2", Description="Create a Money",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Money_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="value",Description = "Reference to value")>] 
         value : obj)
        ([<ExcelArgument(Name="currency",Description = "Reference to currency")>] 
         currency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _value = Helper.toCell<double> value "value" true
                let _currency = Helper.toCell<Currency> currency "currency" true
                let builder () = withMnemonic mnemonic (Fun.Money2 
                                                            _value.cell 
                                                            _currency.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Money>) l

                let source = Helper.sourceFold "Fun.Money2" 
                                               [| _value.source
                                               ;  _currency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _value.cell
                                ;  _currency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Money_rounded", Description="Create a Money",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Money_rounded
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Money",Description = "Reference to Money")>] 
         money : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Money = Helper.toCell<Money> money "Money" true 
                let builder () = withMnemonic mnemonic ((_Money.cell :?> MoneyModel).Rounded
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Money>) l

                let source = Helper.sourceFold (_Money.source + ".Rounded") 
                                               [| _Money.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Money.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Money_ToString", Description="Create a Money",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Money_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Money",Description = "Reference to Money")>] 
         money : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Money = Helper.toCell<Money> money "Money" true 
                let builder () = withMnemonic mnemonic ((_Money.cell :?> MoneyModel).ToString
                                                       ) :> ICell
                let format (o : String) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Money.source + ".ToString") 
                                               [| _Money.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Money.cell
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
    [<ExcelFunction(Name="_Money_value", Description="Create a Money",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Money_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Money",Description = "Reference to Money")>] 
         money : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Money = Helper.toCell<Money> money "Money" true 
                let builder () = withMnemonic mnemonic ((_Money.cell :?> MoneyModel).Value
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Money.source + ".Value") 
                                               [| _Money.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Money.cell
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
    [<ExcelFunction(Name="_Money_Range", Description="Create a range of Money",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Money_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Money")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Money> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Money>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Money>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Money>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
