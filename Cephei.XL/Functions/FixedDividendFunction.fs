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
  This cash flow pays a predetermined amount at a given date.
  </summary> *)
[<AutoSerializable(true)>]
module FixedDividendFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FixedDividend_amount1", Description="Create a FixedDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedDividend_amount1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedDividend",Description = "FixedDividend")>] 
         fixeddividend : obj)
        ([<ExcelArgument(Name="d",Description = "double")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedDividend = Helper.toModelReference<FixedDividend> fixeddividend "FixedDividend"  
                let _d = Helper.toCell<double> d "d" 
                let builder (current : ICell) = ((FixedDividendModel.Cast _FixedDividend.cell).Amount1
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedDividend.source + ".Amount1") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedDividend.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_FixedDividend_amount", Description="Create a FixedDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedDividend_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedDividend",Description = "FixedDividend")>] 
         fixeddividend : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedDividend = Helper.toModelReference<FixedDividend> fixeddividend "FixedDividend"  
                let builder (current : ICell) = ((FixedDividendModel.Cast _FixedDividend.cell).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedDividend.source + ".Amount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedDividend.cell
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
    [<ExcelFunction(Name="_FixedDividend", Description="Create a FixedDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedDividend_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="amount",Description = "double")>] 
         amount : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _amount = Helper.toCell<double> amount "amount" 
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = (Fun.FixedDividend 
                                                            _amount.cell 
                                                            _date.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FixedDividend>) l

                let source () = Helper.sourceFold "Fun.FixedDividend" 
                                               [| _amount.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _amount.cell
                                ;  _date.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedDividend> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Event interface
    *)
    [<ExcelFunction(Name="_FixedDividend_date", Description="Create a FixedDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedDividend_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedDividend",Description = "FixedDividend")>] 
         fixeddividend : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedDividend = Helper.toModelReference<FixedDividend> fixeddividend "FixedDividend"  
                let builder (current : ICell) = ((FixedDividendModel.Cast _FixedDividend.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FixedDividend.source + ".Date") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedDividend.cell
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
    [<ExcelFunction(Name="_FixedDividend_CompareTo", Description="Create a FixedDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedDividend_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedDividend",Description = "FixedDividend")>] 
         fixeddividend : obj)
        ([<ExcelArgument(Name="cf",Description = "CashFlow")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedDividend = Helper.toModelReference<FixedDividend> fixeddividend "FixedDividend"  
                let _cf = Helper.toCell<CashFlow> cf "cf" 
                let builder (current : ICell) = ((FixedDividendModel.Cast _FixedDividend.cell).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedDividend.source + ".CompareTo") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedDividend.cell
                                ;  _cf.cell
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
    [<ExcelFunction(Name="_FixedDividend_Equals", Description="Create a FixedDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedDividend_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedDividend",Description = "FixedDividend")>] 
         fixeddividend : obj)
        ([<ExcelArgument(Name="cf",Description = "Object")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedDividend = Helper.toModelReference<FixedDividend> fixeddividend "FixedDividend"  
                let _cf = Helper.toCell<Object> cf "cf" 
                let builder (current : ICell) = ((FixedDividendModel.Cast _FixedDividend.cell).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FixedDividend.source + ".Equals") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedDividend.cell
                                ;  _cf.cell
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
        ! returns the date that the cash flow trades exCoupon
    *)
    [<ExcelFunction(Name="_FixedDividend_exCouponDate", Description="Create a FixedDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedDividend_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedDividend",Description = "FixedDividend")>] 
         fixeddividend : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedDividend = Helper.toModelReference<FixedDividend> fixeddividend "FixedDividend"  
                let builder (current : ICell) = ((FixedDividendModel.Cast _FixedDividend.cell).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FixedDividend.source + ".ExCouponDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedDividend.cell
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
    [<ExcelFunction(Name="_FixedDividend_hasOccurred", Description="Create a FixedDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedDividend_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedDividend",Description = "FixedDividend")>] 
         fixeddividend : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "bool")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedDividend = Helper.toModelReference<FixedDividend> fixeddividend "FixedDividend"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder (current : ICell) = ((FixedDividendModel.Cast _FixedDividend.cell).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FixedDividend.source + ".HasOccurred") 

                                               [| _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedDividend.cell
                                ;  _refDate.cell
                                ;  _includeRefDate.cell
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
        ! returns true if the cashflow is trading ex-coupon on the refDate
    *)
    [<ExcelFunction(Name="_FixedDividend_tradingExCoupon", Description="Create a FixedDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedDividend_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedDividend",Description = "FixedDividend")>] 
         fixeddividend : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedDividend = Helper.toModelReference<FixedDividend> fixeddividend "FixedDividend"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let builder (current : ICell) = ((FixedDividendModel.Cast _FixedDividend.cell).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FixedDividend.source + ".TradingExCoupon") 

                                               [| _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedDividend.cell
                                ;  _refDate.cell
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
    [<ExcelFunction(Name="_FixedDividend_accept", Description="Create a FixedDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedDividend_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedDividend",Description = "FixedDividend")>] 
         fixeddividend : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedDividend = Helper.toModelReference<FixedDividend> fixeddividend "FixedDividend"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = ((FixedDividendModel.Cast _FixedDividend.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : FixedDividend) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FixedDividend.source + ".Accept") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedDividend.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_FixedDividend_registerWith", Description="Create a FixedDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedDividend_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedDividend",Description = "FixedDividend")>] 
         fixeddividend : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedDividend = Helper.toModelReference<FixedDividend> fixeddividend "FixedDividend"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((FixedDividendModel.Cast _FixedDividend.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FixedDividend) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FixedDividend.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedDividend.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_FixedDividend_unregisterWith", Description="Create a FixedDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedDividend_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedDividend",Description = "FixedDividend")>] 
         fixeddividend : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedDividend = Helper.toModelReference<FixedDividend> fixeddividend "FixedDividend"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((FixedDividendModel.Cast _FixedDividend.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FixedDividend) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FixedDividend.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedDividend.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_FixedDividend_Range", Description="Create a range of FixedDividend",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedDividend_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FixedDividend> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FixedDividend> (c)) :> ICell
                let format (i : Cephei.Cell.List<FixedDividend>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FixedDividend>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
