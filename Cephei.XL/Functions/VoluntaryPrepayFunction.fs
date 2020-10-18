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
    [<ExcelFunction(Name="_VoluntaryPrepay", Description="Create a VoluntaryPrepay",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VoluntaryPrepay_create
        ([<ExcelArgument(Name="Mnemonic",Description = "VoluntaryPrepay")>] 
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.VoluntaryPrepay 
                                                            _amount.cell 
                                                            _date.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VoluntaryPrepay>) l

                let source () = Helper.sourceFold "Fun.VoluntaryPrepay" 
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
                    ; subscriber = Helper.subscriberModel<VoluntaryPrepay> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_VoluntaryPrepay_amount", Description="Create a VoluntaryPrepay",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VoluntaryPrepay_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VoluntaryPrepay",Description = "VoluntaryPrepay")>] 
         voluntaryprepay : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VoluntaryPrepay = Helper.toCell<VoluntaryPrepay> voluntaryprepay "VoluntaryPrepay"  
                let builder (current : ICell) = withMnemonic mnemonic ((VoluntaryPrepayModel.Cast _VoluntaryPrepay.cell).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_VoluntaryPrepay.source + ".Amount") 
                                               [| _VoluntaryPrepay.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VoluntaryPrepay.cell
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
    [<ExcelFunction(Name="_VoluntaryPrepay_date", Description="Create a VoluntaryPrepay",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VoluntaryPrepay_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VoluntaryPrepay",Description = "VoluntaryPrepay")>] 
         voluntaryprepay : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VoluntaryPrepay = Helper.toCell<VoluntaryPrepay> voluntaryprepay "VoluntaryPrepay"  
                let builder (current : ICell) = withMnemonic mnemonic ((VoluntaryPrepayModel.Cast _VoluntaryPrepay.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_VoluntaryPrepay.source + ".Date") 
                                               [| _VoluntaryPrepay.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VoluntaryPrepay.cell
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
    [<ExcelFunction(Name="_VoluntaryPrepay_CompareTo", Description="Create a VoluntaryPrepay",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VoluntaryPrepay_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VoluntaryPrepay",Description = "VoluntaryPrepay")>] 
         voluntaryprepay : obj)
        ([<ExcelArgument(Name="cf",Description = "CashFlow")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VoluntaryPrepay = Helper.toCell<VoluntaryPrepay> voluntaryprepay "VoluntaryPrepay"  
                let _cf = Helper.toCell<CashFlow> cf "cf" 
                let builder (current : ICell) = withMnemonic mnemonic ((VoluntaryPrepayModel.Cast _VoluntaryPrepay.cell).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_VoluntaryPrepay.source + ".CompareTo") 
                                               [| _VoluntaryPrepay.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VoluntaryPrepay.cell
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
    [<ExcelFunction(Name="_VoluntaryPrepay_Equals", Description="Create a VoluntaryPrepay",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VoluntaryPrepay_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VoluntaryPrepay",Description = "VoluntaryPrepay")>] 
         voluntaryprepay : obj)
        ([<ExcelArgument(Name="cf",Description = "Object")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VoluntaryPrepay = Helper.toCell<VoluntaryPrepay> voluntaryprepay "VoluntaryPrepay"  
                let _cf = Helper.toCell<Object> cf "cf" 
                let builder (current : ICell) = withMnemonic mnemonic ((VoluntaryPrepayModel.Cast _VoluntaryPrepay.cell).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VoluntaryPrepay.source + ".Equals") 
                                               [| _VoluntaryPrepay.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VoluntaryPrepay.cell
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
    [<ExcelFunction(Name="_VoluntaryPrepay_exCouponDate", Description="Create a VoluntaryPrepay",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VoluntaryPrepay_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VoluntaryPrepay",Description = "VoluntaryPrepay")>] 
         voluntaryprepay : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VoluntaryPrepay = Helper.toCell<VoluntaryPrepay> voluntaryprepay "VoluntaryPrepay"  
                let builder (current : ICell) = withMnemonic mnemonic ((VoluntaryPrepayModel.Cast _VoluntaryPrepay.cell).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_VoluntaryPrepay.source + ".ExCouponDate") 
                                               [| _VoluntaryPrepay.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VoluntaryPrepay.cell
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
    [<ExcelFunction(Name="_VoluntaryPrepay_hasOccurred", Description="Create a VoluntaryPrepay",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VoluntaryPrepay_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VoluntaryPrepay",Description = "VoluntaryPrepay")>] 
         voluntaryprepay : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "bool")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VoluntaryPrepay = Helper.toCell<VoluntaryPrepay> voluntaryprepay "VoluntaryPrepay"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder (current : ICell) = withMnemonic mnemonic ((VoluntaryPrepayModel.Cast _VoluntaryPrepay.cell).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VoluntaryPrepay.source + ".HasOccurred") 
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
    [<ExcelFunction(Name="_VoluntaryPrepay_tradingExCoupon", Description="Create a VoluntaryPrepay",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VoluntaryPrepay_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VoluntaryPrepay",Description = "VoluntaryPrepay")>] 
         voluntaryprepay : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VoluntaryPrepay = Helper.toCell<VoluntaryPrepay> voluntaryprepay "VoluntaryPrepay"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((VoluntaryPrepayModel.Cast _VoluntaryPrepay.cell).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VoluntaryPrepay.source + ".TradingExCoupon") 
                                               [| _VoluntaryPrepay.source
                                               ;  _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VoluntaryPrepay.cell
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
    [<ExcelFunction(Name="_VoluntaryPrepay_accept", Description="Create a VoluntaryPrepay",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VoluntaryPrepay_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VoluntaryPrepay",Description = "VoluntaryPrepay")>] 
         voluntaryprepay : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VoluntaryPrepay = Helper.toCell<VoluntaryPrepay> voluntaryprepay "VoluntaryPrepay"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((VoluntaryPrepayModel.Cast _VoluntaryPrepay.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : VoluntaryPrepay) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VoluntaryPrepay.source + ".Accept") 
                                               [| _VoluntaryPrepay.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VoluntaryPrepay.cell
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
    [<ExcelFunction(Name="_VoluntaryPrepay_registerWith", Description="Create a VoluntaryPrepay",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VoluntaryPrepay_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VoluntaryPrepay",Description = "VoluntaryPrepay")>] 
         voluntaryprepay : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VoluntaryPrepay = Helper.toCell<VoluntaryPrepay> voluntaryprepay "VoluntaryPrepay"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((VoluntaryPrepayModel.Cast _VoluntaryPrepay.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : VoluntaryPrepay) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VoluntaryPrepay.source + ".RegisterWith") 
                                               [| _VoluntaryPrepay.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VoluntaryPrepay.cell
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
    [<ExcelFunction(Name="_VoluntaryPrepay_unregisterWith", Description="Create a VoluntaryPrepay",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VoluntaryPrepay_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VoluntaryPrepay",Description = "VoluntaryPrepay")>] 
         voluntaryprepay : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VoluntaryPrepay = Helper.toCell<VoluntaryPrepay> voluntaryprepay "VoluntaryPrepay"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((VoluntaryPrepayModel.Cast _VoluntaryPrepay.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : VoluntaryPrepay) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VoluntaryPrepay.source + ".UnregisterWith") 
                                               [| _VoluntaryPrepay.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VoluntaryPrepay.cell
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
    [<ExcelFunction(Name="_VoluntaryPrepay_Range", Description="Create a range of VoluntaryPrepay",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VoluntaryPrepay_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<VoluntaryPrepay> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<VoluntaryPrepay>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<VoluntaryPrepay>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<VoluntaryPrepay>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
