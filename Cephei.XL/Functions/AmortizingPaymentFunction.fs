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
  This class specializes SimpleCashFlow so that visitors can perform more detailed cash-flow analysis.
  </summary> *)
[<AutoSerializable(true)>]
module AmortizingPaymentFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AmortizingPayment", Description="Create a AmortizingPayment",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingPayment_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="amount",Description = "Reference to amount")>] 
         amount : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _amount = Helper.toCell<double> amount "amount" true
                let _date = Helper.toCell<Date> date "date" true
                let builder () = withMnemonic mnemonic (Fun.AmortizingPayment 
                                                            _amount.cell 
                                                            _date.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AmortizingPayment>) l

                let source = Helper.sourceFold "Fun.AmortizingPayment" 
                                               [| _amount.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _amount.cell
                                ;  _date.cell
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
    [<ExcelFunction(Name="_AmortizingPayment_amount", Description="Create a AmortizingPayment",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingPayment_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingPayment",Description = "Reference to AmortizingPayment")>] 
         amortizingpayment : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingPayment = Helper.toCell<AmortizingPayment> amortizingpayment "AmortizingPayment" true 
                let builder () = withMnemonic mnemonic ((_AmortizingPayment.cell :?> AmortizingPaymentModel).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingPayment.source + ".Amount") 
                                               [| _AmortizingPayment.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingPayment.cell
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
    [<ExcelFunction(Name="_AmortizingPayment_date", Description="Create a AmortizingPayment",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingPayment_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingPayment",Description = "Reference to AmortizingPayment")>] 
         amortizingpayment : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingPayment = Helper.toCell<AmortizingPayment> amortizingpayment "AmortizingPayment" true 
                let builder () = withMnemonic mnemonic ((_AmortizingPayment.cell :?> AmortizingPaymentModel).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingPayment.source + ".Date") 
                                               [| _AmortizingPayment.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingPayment.cell
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
    [<ExcelFunction(Name="_AmortizingPayment_CompareTo", Description="Create a AmortizingPayment",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingPayment_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingPayment",Description = "Reference to AmortizingPayment")>] 
         amortizingpayment : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingPayment = Helper.toCell<AmortizingPayment> amortizingpayment "AmortizingPayment" true 
                let _cf = Helper.toCell<CashFlow> cf "cf" true
                let builder () = withMnemonic mnemonic ((_AmortizingPayment.cell :?> AmortizingPaymentModel).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingPayment.source + ".CompareTo") 
                                               [| _AmortizingPayment.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingPayment.cell
                                ;  _cf.cell
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
    [<ExcelFunction(Name="_AmortizingPayment_Equals", Description="Create a AmortizingPayment",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingPayment_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingPayment",Description = "Reference to AmortizingPayment")>] 
         amortizingpayment : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingPayment = Helper.toCell<AmortizingPayment> amortizingpayment "AmortizingPayment" true 
                let _cf = Helper.toCell<Object> cf "cf" true
                let builder () = withMnemonic mnemonic ((_AmortizingPayment.cell :?> AmortizingPaymentModel).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AmortizingPayment.source + ".Equals") 
                                               [| _AmortizingPayment.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingPayment.cell
                                ;  _cf.cell
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
        ! returns the date that the cash flow trades exCoupon
    *)
    [<ExcelFunction(Name="_AmortizingPayment_exCouponDate", Description="Create a AmortizingPayment",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingPayment_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingPayment",Description = "Reference to AmortizingPayment")>] 
         amortizingpayment : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingPayment = Helper.toCell<AmortizingPayment> amortizingpayment "AmortizingPayment" true 
                let builder () = withMnemonic mnemonic ((_AmortizingPayment.cell :?> AmortizingPaymentModel).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingPayment.source + ".ExCouponDate") 
                                               [| _AmortizingPayment.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingPayment.cell
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
    [<ExcelFunction(Name="_AmortizingPayment_hasOccurred", Description="Create a AmortizingPayment",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingPayment_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingPayment",Description = "Reference to AmortizingPayment")>] 
         amortizingpayment : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "Reference to includeRefDate")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingPayment = Helper.toCell<AmortizingPayment> amortizingpayment "AmortizingPayment" true 
                let _refDate = Helper.toCell<Date> refDate "refDate" true
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder () = withMnemonic mnemonic ((_AmortizingPayment.cell :?> AmortizingPaymentModel).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AmortizingPayment.source + ".HasOccurred") 
                                               [| _AmortizingPayment.source
                                               ;  _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingPayment.cell
                                ;  _refDate.cell
                                ;  _includeRefDate.cell
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
        ! returns true if the cashflow is trading ex-coupon on the refDate
    *)
    [<ExcelFunction(Name="_AmortizingPayment_tradingExCoupon", Description="Create a AmortizingPayment",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingPayment_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingPayment",Description = "Reference to AmortizingPayment")>] 
         amortizingpayment : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingPayment = Helper.toCell<AmortizingPayment> amortizingpayment "AmortizingPayment" true 
                let _refDate = Helper.toCell<Date> refDate "refDate" true
                let builder () = withMnemonic mnemonic ((_AmortizingPayment.cell :?> AmortizingPaymentModel).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AmortizingPayment.source + ".TradingExCoupon") 
                                               [| _AmortizingPayment.source
                                               ;  _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingPayment.cell
                                ;  _refDate.cell
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
    [<ExcelFunction(Name="_AmortizingPayment_accept", Description="Create a AmortizingPayment",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingPayment_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingPayment",Description = "Reference to AmortizingPayment")>] 
         amortizingpayment : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingPayment = Helper.toCell<AmortizingPayment> amortizingpayment "AmortizingPayment" true 
                let _v = Helper.toCell<IAcyclicVisitor> v "v" true
                let builder () = withMnemonic mnemonic ((_AmortizingPayment.cell :?> AmortizingPaymentModel).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : AmortizingPayment) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AmortizingPayment.source + ".Accept") 
                                               [| _AmortizingPayment.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingPayment.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_AmortizingPayment_registerWith", Description="Create a AmortizingPayment",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingPayment_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingPayment",Description = "Reference to AmortizingPayment")>] 
         amortizingpayment : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingPayment = Helper.toCell<AmortizingPayment> amortizingpayment "AmortizingPayment" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_AmortizingPayment.cell :?> AmortizingPaymentModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AmortizingPayment) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AmortizingPayment.source + ".RegisterWith") 
                                               [| _AmortizingPayment.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingPayment.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_AmortizingPayment_unregisterWith", Description="Create a AmortizingPayment",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingPayment_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingPayment",Description = "Reference to AmortizingPayment")>] 
         amortizingpayment : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingPayment = Helper.toCell<AmortizingPayment> amortizingpayment "AmortizingPayment" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_AmortizingPayment.cell :?> AmortizingPaymentModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AmortizingPayment) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AmortizingPayment.source + ".UnregisterWith") 
                                               [| _AmortizingPayment.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingPayment.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_AmortizingPayment_Range", Description="Create a range of AmortizingPayment",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingPayment_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the AmortizingPayment")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AmortizingPayment> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AmortizingPayment>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<AmortizingPayment>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<AmortizingPayment>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
