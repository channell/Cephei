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
module RedemptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Redemption", Description="Create a Redemption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Redemption_create
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
                let builder () = withMnemonic mnemonic (Fun.Redemption 
                                                            _amount.cell 
                                                            _date.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Redemption>) l

                let source = Helper.sourceFold "Fun.Redemption" 
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
    [<ExcelFunction(Name="_Redemption_amount", Description="Create a Redemption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Redemption_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Redemption",Description = "Reference to Redemption")>] 
         redemption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Redemption = Helper.toCell<Redemption> redemption "Redemption" true 
                let builder () = withMnemonic mnemonic ((_Redemption.cell :?> RedemptionModel).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Redemption.source + ".Amount") 
                                               [| _Redemption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Redemption.cell
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
    [<ExcelFunction(Name="_Redemption_date", Description="Create a Redemption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Redemption_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Redemption",Description = "Reference to Redemption")>] 
         redemption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Redemption = Helper.toCell<Redemption> redemption "Redemption" true 
                let builder () = withMnemonic mnemonic ((_Redemption.cell :?> RedemptionModel).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Redemption.source + ".Date") 
                                               [| _Redemption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Redemption.cell
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
    [<ExcelFunction(Name="_Redemption_CompareTo", Description="Create a Redemption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Redemption_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Redemption",Description = "Reference to Redemption")>] 
         redemption : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Redemption = Helper.toCell<Redemption> redemption "Redemption" true 
                let _cf = Helper.toCell<CashFlow> cf "cf" true
                let builder () = withMnemonic mnemonic ((_Redemption.cell :?> RedemptionModel).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Redemption.source + ".CompareTo") 
                                               [| _Redemption.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Redemption.cell
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
    [<ExcelFunction(Name="_Redemption_Equals", Description="Create a Redemption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Redemption_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Redemption",Description = "Reference to Redemption")>] 
         redemption : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Redemption = Helper.toCell<Redemption> redemption "Redemption" true 
                let _cf = Helper.toCell<Object> cf "cf" true
                let builder () = withMnemonic mnemonic ((_Redemption.cell :?> RedemptionModel).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Redemption.source + ".Equals") 
                                               [| _Redemption.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Redemption.cell
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
    [<ExcelFunction(Name="_Redemption_exCouponDate", Description="Create a Redemption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Redemption_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Redemption",Description = "Reference to Redemption")>] 
         redemption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Redemption = Helper.toCell<Redemption> redemption "Redemption" true 
                let builder () = withMnemonic mnemonic ((_Redemption.cell :?> RedemptionModel).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Redemption.source + ".ExCouponDate") 
                                               [| _Redemption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Redemption.cell
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
    [<ExcelFunction(Name="_Redemption_hasOccurred", Description="Create a Redemption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Redemption_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Redemption",Description = "Reference to Redemption")>] 
         redemption : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "Reference to includeRefDate")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Redemption = Helper.toCell<Redemption> redemption "Redemption" true 
                let _refDate = Helper.toCell<Date> refDate "refDate" true
                let _includeRefDate = Helper.toNullable<Nullable<bool>> includeRefDate "includeRefDate"
                let builder () = withMnemonic mnemonic ((_Redemption.cell :?> RedemptionModel).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Redemption.source + ".HasOccurred") 
                                               [| _Redemption.source
                                               ;  _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Redemption.cell
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
    [<ExcelFunction(Name="_Redemption_tradingExCoupon", Description="Create a Redemption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Redemption_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Redemption",Description = "Reference to Redemption")>] 
         redemption : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Redemption = Helper.toCell<Redemption> redemption "Redemption" true 
                let _refDate = Helper.toCell<Date> refDate "refDate" true
                let builder () = withMnemonic mnemonic ((_Redemption.cell :?> RedemptionModel).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Redemption.source + ".TradingExCoupon") 
                                               [| _Redemption.source
                                               ;  _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Redemption.cell
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
    [<ExcelFunction(Name="_Redemption_accept", Description="Create a Redemption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Redemption_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Redemption",Description = "Reference to Redemption")>] 
         redemption : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Redemption = Helper.toCell<Redemption> redemption "Redemption" true 
                let _v = Helper.toCell<IAcyclicVisitor> v "v" true
                let builder () = withMnemonic mnemonic ((_Redemption.cell :?> RedemptionModel).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : Redemption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Redemption.source + ".Accept") 
                                               [| _Redemption.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Redemption.cell
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
    [<ExcelFunction(Name="_Redemption_registerWith", Description="Create a Redemption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Redemption_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Redemption",Description = "Reference to Redemption")>] 
         redemption : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Redemption = Helper.toCell<Redemption> redemption "Redemption" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_Redemption.cell :?> RedemptionModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Redemption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Redemption.source + ".RegisterWith") 
                                               [| _Redemption.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Redemption.cell
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
    [<ExcelFunction(Name="_Redemption_unregisterWith", Description="Create a Redemption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Redemption_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Redemption",Description = "Reference to Redemption")>] 
         redemption : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Redemption = Helper.toCell<Redemption> redemption "Redemption" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_Redemption.cell :?> RedemptionModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Redemption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Redemption.source + ".UnregisterWith") 
                                               [| _Redemption.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Redemption.cell
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
    [<ExcelFunction(Name="_Redemption_Range", Description="Create a range of Redemption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Redemption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Redemption")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Redemption> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Redemption>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Redemption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Redemption>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
