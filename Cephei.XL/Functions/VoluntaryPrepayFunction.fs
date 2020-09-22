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
module VoluntaryPrepayFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_VoluntaryPrepay", Description="Create a VoluntaryPrepay",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VoluntaryPrepay_create
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
                let builder () = withMnemonic mnemonic (Fun.VoluntaryPrepay 
                                                            _amount.cell 
                                                            _date.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VoluntaryPrepay>) l

                let source = Helper.sourceFold "Fun.VoluntaryPrepay" 
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
    [<ExcelFunction(Name="_VoluntaryPrepay_amount", Description="Create a VoluntaryPrepay",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VoluntaryPrepay_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VoluntaryPrepay",Description = "Reference to VoluntaryPrepay")>] 
         voluntaryprepay : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VoluntaryPrepay = Helper.toCell<VoluntaryPrepay> voluntaryprepay "VoluntaryPrepay" true 
                let builder () = withMnemonic mnemonic ((_VoluntaryPrepay.cell :?> VoluntaryPrepayModel).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_VoluntaryPrepay.source + ".Amount") 
                                               [| _VoluntaryPrepay.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VoluntaryPrepay.cell
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
    [<ExcelFunction(Name="_VoluntaryPrepay_date", Description="Create a VoluntaryPrepay",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VoluntaryPrepay_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VoluntaryPrepay",Description = "Reference to VoluntaryPrepay")>] 
         voluntaryprepay : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VoluntaryPrepay = Helper.toCell<VoluntaryPrepay> voluntaryprepay "VoluntaryPrepay" true 
                let builder () = withMnemonic mnemonic ((_VoluntaryPrepay.cell :?> VoluntaryPrepayModel).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_VoluntaryPrepay.source + ".Date") 
                                               [| _VoluntaryPrepay.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VoluntaryPrepay.cell
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
    [<ExcelFunction(Name="_VoluntaryPrepay_CompareTo", Description="Create a VoluntaryPrepay",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VoluntaryPrepay_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VoluntaryPrepay",Description = "Reference to VoluntaryPrepay")>] 
         voluntaryprepay : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VoluntaryPrepay = Helper.toCell<VoluntaryPrepay> voluntaryprepay "VoluntaryPrepay" true 
                let _cf = Helper.toCell<CashFlow> cf "cf" true
                let builder () = withMnemonic mnemonic ((_VoluntaryPrepay.cell :?> VoluntaryPrepayModel).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_VoluntaryPrepay.source + ".CompareTo") 
                                               [| _VoluntaryPrepay.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VoluntaryPrepay.cell
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
    [<ExcelFunction(Name="_VoluntaryPrepay_Equals", Description="Create a VoluntaryPrepay",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VoluntaryPrepay_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VoluntaryPrepay",Description = "Reference to VoluntaryPrepay")>] 
         voluntaryprepay : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VoluntaryPrepay = Helper.toCell<VoluntaryPrepay> voluntaryprepay "VoluntaryPrepay" true 
                let _cf = Helper.toCell<Object> cf "cf" true
                let builder () = withMnemonic mnemonic ((_VoluntaryPrepay.cell :?> VoluntaryPrepayModel).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_VoluntaryPrepay.source + ".Equals") 
                                               [| _VoluntaryPrepay.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VoluntaryPrepay.cell
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
    [<ExcelFunction(Name="_VoluntaryPrepay_exCouponDate", Description="Create a VoluntaryPrepay",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VoluntaryPrepay_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VoluntaryPrepay",Description = "Reference to VoluntaryPrepay")>] 
         voluntaryprepay : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VoluntaryPrepay = Helper.toCell<VoluntaryPrepay> voluntaryprepay "VoluntaryPrepay" true 
                let builder () = withMnemonic mnemonic ((_VoluntaryPrepay.cell :?> VoluntaryPrepayModel).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_VoluntaryPrepay.source + ".ExCouponDate") 
                                               [| _VoluntaryPrepay.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VoluntaryPrepay.cell
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
    [<ExcelFunction(Name="_VoluntaryPrepay_hasOccurred", Description="Create a VoluntaryPrepay",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VoluntaryPrepay_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VoluntaryPrepay",Description = "Reference to VoluntaryPrepay")>] 
         voluntaryprepay : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "Reference to includeRefDate")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VoluntaryPrepay = Helper.toCell<VoluntaryPrepay> voluntaryprepay "VoluntaryPrepay" true 
                let _refDate = Helper.toCell<Date> refDate "refDate" true
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder () = withMnemonic mnemonic ((_VoluntaryPrepay.cell :?> VoluntaryPrepayModel).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_VoluntaryPrepay.source + ".HasOccurred") 
                                               [| _VoluntaryPrepay.source
                                               ;  _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VoluntaryPrepay.cell
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
    [<ExcelFunction(Name="_VoluntaryPrepay_tradingExCoupon", Description="Create a VoluntaryPrepay",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VoluntaryPrepay_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VoluntaryPrepay",Description = "Reference to VoluntaryPrepay")>] 
         voluntaryprepay : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VoluntaryPrepay = Helper.toCell<VoluntaryPrepay> voluntaryprepay "VoluntaryPrepay" true 
                let _refDate = Helper.toCell<Date> refDate "refDate" true
                let builder () = withMnemonic mnemonic ((_VoluntaryPrepay.cell :?> VoluntaryPrepayModel).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_VoluntaryPrepay.source + ".TradingExCoupon") 
                                               [| _VoluntaryPrepay.source
                                               ;  _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VoluntaryPrepay.cell
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
    [<ExcelFunction(Name="_VoluntaryPrepay_accept", Description="Create a VoluntaryPrepay",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VoluntaryPrepay_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VoluntaryPrepay",Description = "Reference to VoluntaryPrepay")>] 
         voluntaryprepay : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VoluntaryPrepay = Helper.toCell<VoluntaryPrepay> voluntaryprepay "VoluntaryPrepay" true 
                let _v = Helper.toCell<IAcyclicVisitor> v "v" true
                let builder () = withMnemonic mnemonic ((_VoluntaryPrepay.cell :?> VoluntaryPrepayModel).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : VoluntaryPrepay) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_VoluntaryPrepay.source + ".Accept") 
                                               [| _VoluntaryPrepay.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VoluntaryPrepay.cell
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
    [<ExcelFunction(Name="_VoluntaryPrepay_registerWith", Description="Create a VoluntaryPrepay",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VoluntaryPrepay_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VoluntaryPrepay",Description = "Reference to VoluntaryPrepay")>] 
         voluntaryprepay : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VoluntaryPrepay = Helper.toCell<VoluntaryPrepay> voluntaryprepay "VoluntaryPrepay" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_VoluntaryPrepay.cell :?> VoluntaryPrepayModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : VoluntaryPrepay) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_VoluntaryPrepay.source + ".RegisterWith") 
                                               [| _VoluntaryPrepay.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VoluntaryPrepay.cell
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
    [<ExcelFunction(Name="_VoluntaryPrepay_unregisterWith", Description="Create a VoluntaryPrepay",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VoluntaryPrepay_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VoluntaryPrepay",Description = "Reference to VoluntaryPrepay")>] 
         voluntaryprepay : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VoluntaryPrepay = Helper.toCell<VoluntaryPrepay> voluntaryprepay "VoluntaryPrepay" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_VoluntaryPrepay.cell :?> VoluntaryPrepayModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : VoluntaryPrepay) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_VoluntaryPrepay.source + ".UnregisterWith") 
                                               [| _VoluntaryPrepay.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VoluntaryPrepay.cell
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
    [<ExcelFunction(Name="_VoluntaryPrepay_Range", Description="Create a range of VoluntaryPrepay",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VoluntaryPrepay_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the VoluntaryPrepay")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<VoluntaryPrepay> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<VoluntaryPrepay>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<VoluntaryPrepay>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<VoluntaryPrepay>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
