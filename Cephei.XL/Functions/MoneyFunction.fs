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
    [<ExcelFunction(Name="_Money_currency", Description="Create a Money",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Money_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Money",Description = "Money")>] 
         money : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Money = Helper.toCell<Money> money "Money"  
                let builder (current : ICell) = withMnemonic mnemonic ((MoneyModel.Cast _Money.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_Money.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Money.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Money> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Money_Equals", Description="Create a Money",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Money_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Money",Description = "Money")>] 
         money : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Money = Helper.toCell<Money> money "Money"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((MoneyModel.Cast _Money.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Money.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Money.cell
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
        
    *)
    [<ExcelFunction(Name="_Money1", Description="Create a Money",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Money_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="currency",Description = "Currency")>] 
         currency : obj)
        ([<ExcelArgument(Name="value",Description = "double")>] 
         value : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _currency = Helper.toCell<Currency> currency "currency" 
                let _value = Helper.toCell<double> value "value" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Money1 
                                                            _currency.cell 
                                                            _value.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Money>) l

                let source () = Helper.sourceFold "Fun.Money1" 
                                               [| _currency.source
                                               ;  _value.source
                                               |]
                let hash = Helper.hashFold 
                                [| _currency.cell
                                ;  _value.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Money> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Money", Description="Create a Money",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Money_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.Money ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Money>) l

                let source () = Helper.sourceFold "Fun.Money" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Money> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Money2", Description="Create a Money",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Money_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="value",Description = "double")>] 
         value : obj)
        ([<ExcelArgument(Name="currency",Description = "Currency")>] 
         currency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _value = Helper.toCell<double> value "value" 
                let _currency = Helper.toCell<Currency> currency "currency" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Money2 
                                                            _value.cell 
                                                            _currency.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Money>) l

                let source () = Helper.sourceFold "Fun.Money2" 
                                               [| _value.source
                                               ;  _currency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _value.cell
                                ;  _currency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Money> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Money_rounded", Description="Create a Money",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Money_rounded
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Money",Description = "Money")>] 
         money : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Money = Helper.toCell<Money> money "Money"  
                let builder (current : ICell) = withMnemonic mnemonic ((MoneyModel.Cast _Money.cell).Rounded
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Money>) l

                let source () = Helper.sourceFold (_Money.source + ".Rounded") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Money.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Money> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Money_ToString", Description="Create a Money",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Money_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Money",Description = "Money")>] 
         money : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Money = Helper.toCell<Money> money "Money"  
                let builder (current : ICell) = withMnemonic mnemonic ((MoneyModel.Cast _Money.cell).ToString
                                                       ) :> ICell
                let format (o : String) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Money.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Money.cell
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
    [<ExcelFunction(Name="_Money_value", Description="Create a Money",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Money_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Money",Description = "Money")>] 
         money : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Money = Helper.toCell<Money> money "Money"  
                let builder (current : ICell) = withMnemonic mnemonic ((MoneyModel.Cast _Money.cell).Value
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Money.source + ".Value") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Money.cell
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
    [<ExcelFunction(Name="_Money_Range", Description="Create a range of Money",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Money_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Money> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Money>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<Money>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<Money>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
