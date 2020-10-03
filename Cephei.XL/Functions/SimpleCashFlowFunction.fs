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
module SimpleCashFlowFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SimpleCashFlow_amount", Description="Create a SimpleCashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpleCashFlow_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpleCashFlow",Description = "Reference to SimpleCashFlow")>] 
         simplecashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpleCashFlow = Helper.toCell<SimpleCashFlow> simplecashflow "SimpleCashFlow"  
                let builder () = withMnemonic mnemonic ((SimpleCashFlowModel.Cast _SimpleCashFlow.cell).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SimpleCashFlow.source + ".Amount") 
                                               [| _SimpleCashFlow.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpleCashFlow.cell
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
    [<ExcelFunction(Name="_SimpleCashFlow_date", Description="Create a SimpleCashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpleCashFlow_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpleCashFlow",Description = "Reference to SimpleCashFlow")>] 
         simplecashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpleCashFlow = Helper.toCell<SimpleCashFlow> simplecashflow "SimpleCashFlow"  
                let builder () = withMnemonic mnemonic ((SimpleCashFlowModel.Cast _SimpleCashFlow.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SimpleCashFlow.source + ".Date") 
                                               [| _SimpleCashFlow.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpleCashFlow.cell
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
    [<ExcelFunction(Name="_SimpleCashFlow", Description="Create a SimpleCashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpleCashFlow_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="amount",Description = "Reference to amount")>] 
         amount : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _amount = Helper.toCell<double> amount "amount" 
                let _date = Helper.toCell<Date> date "date" 
                let builder () = withMnemonic mnemonic (Fun.SimpleCashFlow 
                                                            _amount.cell 
                                                            _date.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SimpleCashFlow>) l

                let source = Helper.sourceFold "Fun.SimpleCashFlow" 
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
                    ; subscriber = Helper.subscriberModel<SimpleCashFlow> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SimpleCashFlow_CompareTo", Description="Create a SimpleCashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpleCashFlow_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpleCashFlow",Description = "Reference to SimpleCashFlow")>] 
         simplecashflow : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpleCashFlow = Helper.toCell<SimpleCashFlow> simplecashflow "SimpleCashFlow"  
                let _cf = Helper.toCell<CashFlow> cf "cf" 
                let builder () = withMnemonic mnemonic ((SimpleCashFlowModel.Cast _SimpleCashFlow.cell).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SimpleCashFlow.source + ".CompareTo") 
                                               [| _SimpleCashFlow.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpleCashFlow.cell
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
    [<ExcelFunction(Name="_SimpleCashFlow_Equals", Description="Create a SimpleCashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpleCashFlow_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpleCashFlow",Description = "Reference to SimpleCashFlow")>] 
         simplecashflow : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpleCashFlow = Helper.toCell<SimpleCashFlow> simplecashflow "SimpleCashFlow"  
                let _cf = Helper.toCell<Object> cf "cf" 
                let builder () = withMnemonic mnemonic ((SimpleCashFlowModel.Cast _SimpleCashFlow.cell).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SimpleCashFlow.source + ".Equals") 
                                               [| _SimpleCashFlow.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpleCashFlow.cell
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
    [<ExcelFunction(Name="_SimpleCashFlow_exCouponDate", Description="Create a SimpleCashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpleCashFlow_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpleCashFlow",Description = "Reference to SimpleCashFlow")>] 
         simplecashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpleCashFlow = Helper.toCell<SimpleCashFlow> simplecashflow "SimpleCashFlow"  
                let builder () = withMnemonic mnemonic ((SimpleCashFlowModel.Cast _SimpleCashFlow.cell).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SimpleCashFlow.source + ".ExCouponDate") 
                                               [| _SimpleCashFlow.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpleCashFlow.cell
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
    [<ExcelFunction(Name="_SimpleCashFlow_hasOccurred", Description="Create a SimpleCashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpleCashFlow_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpleCashFlow",Description = "Reference to SimpleCashFlow")>] 
         simplecashflow : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "Reference to includeRefDate")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpleCashFlow = Helper.toCell<SimpleCashFlow> simplecashflow "SimpleCashFlow"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder () = withMnemonic mnemonic ((SimpleCashFlowModel.Cast _SimpleCashFlow.cell).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SimpleCashFlow.source + ".HasOccurred") 
                                               [| _SimpleCashFlow.source
                                               ;  _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpleCashFlow.cell
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
    [<ExcelFunction(Name="_SimpleCashFlow_tradingExCoupon", Description="Create a SimpleCashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpleCashFlow_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpleCashFlow",Description = "Reference to SimpleCashFlow")>] 
         simplecashflow : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpleCashFlow = Helper.toCell<SimpleCashFlow> simplecashflow "SimpleCashFlow"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let builder () = withMnemonic mnemonic ((SimpleCashFlowModel.Cast _SimpleCashFlow.cell).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SimpleCashFlow.source + ".TradingExCoupon") 
                                               [| _SimpleCashFlow.source
                                               ;  _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpleCashFlow.cell
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
    [<ExcelFunction(Name="_SimpleCashFlow_accept", Description="Create a SimpleCashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpleCashFlow_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpleCashFlow",Description = "Reference to SimpleCashFlow")>] 
         simplecashflow : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpleCashFlow = Helper.toCell<SimpleCashFlow> simplecashflow "SimpleCashFlow"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder () = withMnemonic mnemonic ((SimpleCashFlowModel.Cast _SimpleCashFlow.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : SimpleCashFlow) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SimpleCashFlow.source + ".Accept") 
                                               [| _SimpleCashFlow.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpleCashFlow.cell
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
    [<ExcelFunction(Name="_SimpleCashFlow_registerWith", Description="Create a SimpleCashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpleCashFlow_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpleCashFlow",Description = "Reference to SimpleCashFlow")>] 
         simplecashflow : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpleCashFlow = Helper.toCell<SimpleCashFlow> simplecashflow "SimpleCashFlow"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((SimpleCashFlowModel.Cast _SimpleCashFlow.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : SimpleCashFlow) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SimpleCashFlow.source + ".RegisterWith") 
                                               [| _SimpleCashFlow.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpleCashFlow.cell
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
    [<ExcelFunction(Name="_SimpleCashFlow_unregisterWith", Description="Create a SimpleCashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpleCashFlow_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpleCashFlow",Description = "Reference to SimpleCashFlow")>] 
         simplecashflow : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpleCashFlow = Helper.toCell<SimpleCashFlow> simplecashflow "SimpleCashFlow"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((SimpleCashFlowModel.Cast _SimpleCashFlow.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : SimpleCashFlow) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SimpleCashFlow.source + ".UnregisterWith") 
                                               [| _SimpleCashFlow.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpleCashFlow.cell
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
    [<ExcelFunction(Name="_SimpleCashFlow_Range", Description="Create a range of SimpleCashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpleCashFlow_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SimpleCashFlow")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SimpleCashFlow> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SimpleCashFlow>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SimpleCashFlow>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SimpleCashFlow>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
