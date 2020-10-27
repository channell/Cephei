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
  This cash flow is not a coupon, i.e., there's no accrual.  The amount is either i(T)/i(0) or i(T)/i(0) - 1, depending on the growthOnly parameter.  We expect this to be used inside an instrument that does all the date adjustment etc., so this takes just dates and does not change them. growthOnly = false means i(T)/i(0), which is a bond-type setting. growthOnly = true means i(T)/i(0) - 1, which is a swap-type setting.
  </summary> *)
[<AutoSerializable(true)>]
module IndexedCashFlowFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_IndexedCashFlow_amount", Description="Create a IndexedCashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IndexedCashFlow_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Index")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexedCashFlow",Description = "IndexedCashFlow")>] 
         indexedcashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexedCashFlow = Helper.toCell<IndexedCashFlow> indexedcashflow "IndexedCashFlow"  
                let builder (current : ICell) = withMnemonic mnemonic ((IndexedCashFlowModel.Cast _IndexedCashFlow.cell).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_IndexedCashFlow.source + ".Amount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IndexedCashFlow.cell
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
    [<ExcelFunction(Name="_IndexedCashFlow_baseDate", Description="Create a IndexedCashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IndexedCashFlow_baseDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Index")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexedCashFlow",Description = "IndexedCashFlow")>] 
         indexedcashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexedCashFlow = Helper.toCell<IndexedCashFlow> indexedcashflow "IndexedCashFlow"  
                let builder (current : ICell) = withMnemonic mnemonic ((IndexedCashFlowModel.Cast _IndexedCashFlow.cell).BaseDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_IndexedCashFlow.source + ".BaseDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IndexedCashFlow.cell
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
    [<ExcelFunction(Name="_IndexedCashFlow_date", Description="Create a IndexedCashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IndexedCashFlow_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Index")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexedCashFlow",Description = "IndexedCashFlow")>] 
         indexedcashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexedCashFlow = Helper.toCell<IndexedCashFlow> indexedcashflow "IndexedCashFlow"  
                let builder (current : ICell) = withMnemonic mnemonic ((IndexedCashFlowModel.Cast _IndexedCashFlow.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_IndexedCashFlow.source + ".Date") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IndexedCashFlow.cell
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
    [<ExcelFunction(Name="_IndexedCashFlow_fixingDate", Description="Create a IndexedCashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IndexedCashFlow_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Index")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexedCashFlow",Description = "IndexedCashFlow")>] 
         indexedcashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexedCashFlow = Helper.toCell<IndexedCashFlow> indexedcashflow "IndexedCashFlow"  
                let builder (current : ICell) = withMnemonic mnemonic ((IndexedCashFlowModel.Cast _IndexedCashFlow.cell).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_IndexedCashFlow.source + ".FixingDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IndexedCashFlow.cell
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
    [<ExcelFunction(Name="_IndexedCashFlow_growthOnly", Description="Create a IndexedCashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IndexedCashFlow_growthOnly
        ([<ExcelArgument(Name="Mnemonic",Description = "Index")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexedCashFlow",Description = "IndexedCashFlow")>] 
         indexedcashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexedCashFlow = Helper.toCell<IndexedCashFlow> indexedcashflow "IndexedCashFlow"  
                let builder (current : ICell) = withMnemonic mnemonic ((IndexedCashFlowModel.Cast _IndexedCashFlow.cell).GrowthOnly
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IndexedCashFlow.source + ".GrowthOnly") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IndexedCashFlow.cell
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
    [<ExcelFunction(Name="_IndexedCashFlow_index", Description="Create a IndexedCashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IndexedCashFlow_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Index")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexedCashFlow",Description = "IndexedCashFlow")>] 
         indexedcashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexedCashFlow = Helper.toCell<IndexedCashFlow> indexedcashflow "IndexedCashFlow"  
                let builder (current : ICell) = withMnemonic mnemonic ((IndexedCashFlowModel.Cast _IndexedCashFlow.cell).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Index>) l

                let source () = Helper.sourceFold (_IndexedCashFlow.source + ".Index") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IndexedCashFlow.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IndexedCashFlow> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_IndexedCashFlow", Description="Create a IndexedCashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IndexedCashFlow_create
        ([<ExcelArgument(Name="Mnemonic",Description = "IndexedCashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="notional",Description = "double")>] 
         notional : obj)
        ([<ExcelArgument(Name="index",Description = "Index")>] 
         index : obj)
        ([<ExcelArgument(Name="baseDate",Description = "Date")>] 
         baseDate : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="paymentDate",Description = "Date")>] 
         paymentDate : obj)
        ([<ExcelArgument(Name="growthOnly",Description = "IndexedCashFlow")>] 
         growthOnly : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _notional = Helper.toCell<double> notional "notional" 
                let _index = Helper.toCell<Index> index "index" 
                let _baseDate = Helper.toCell<Date> baseDate "baseDate" 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" 
                let _growthOnly = Helper.toDefault<bool> growthOnly "growthOnly" false
                let builder (current : ICell) = withMnemonic mnemonic (Fun.IndexedCashFlow 
                                                            _notional.cell 
                                                            _index.cell 
                                                            _baseDate.cell 
                                                            _fixingDate.cell 
                                                            _paymentDate.cell 
                                                            _growthOnly.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IndexedCashFlow>) l

                let source () = Helper.sourceFold "Fun.IndexedCashFlow" 
                                               [| _notional.source
                                               ;  _index.source
                                               ;  _baseDate.source
                                               ;  _fixingDate.source
                                               ;  _paymentDate.source
                                               ;  _growthOnly.source
                                               |]
                let hash = Helper.hashFold 
                                [| _notional.cell
                                ;  _index.cell
                                ;  _baseDate.cell
                                ;  _fixingDate.cell
                                ;  _paymentDate.cell
                                ;  _growthOnly.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IndexedCashFlow> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_IndexedCashFlow_notional", Description="Create a IndexedCashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IndexedCashFlow_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexedCashFlow",Description = "IndexedCashFlow")>] 
         indexedcashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexedCashFlow = Helper.toCell<IndexedCashFlow> indexedcashflow "IndexedCashFlow"  
                let builder (current : ICell) = withMnemonic mnemonic ((IndexedCashFlowModel.Cast _IndexedCashFlow.cell).Notional
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_IndexedCashFlow.source + ".Notional") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IndexedCashFlow.cell
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
    [<ExcelFunction(Name="_IndexedCashFlow_CompareTo", Description="Create a IndexedCashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IndexedCashFlow_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexedCashFlow",Description = "IndexedCashFlow")>] 
         indexedcashflow : obj)
        ([<ExcelArgument(Name="cf",Description = "CashFlow")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexedCashFlow = Helper.toCell<IndexedCashFlow> indexedcashflow "IndexedCashFlow"  
                let _cf = Helper.toCell<CashFlow> cf "cf" 
                let builder (current : ICell) = withMnemonic mnemonic ((IndexedCashFlowModel.Cast _IndexedCashFlow.cell).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_IndexedCashFlow.source + ".CompareTo") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IndexedCashFlow.cell
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
    [<ExcelFunction(Name="_IndexedCashFlow_Equals", Description="Create a IndexedCashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IndexedCashFlow_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexedCashFlow",Description = "IndexedCashFlow")>] 
         indexedcashflow : obj)
        ([<ExcelArgument(Name="cf",Description = "Object")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexedCashFlow = Helper.toCell<IndexedCashFlow> indexedcashflow "IndexedCashFlow"  
                let _cf = Helper.toCell<Object> cf "cf" 
                let builder (current : ICell) = withMnemonic mnemonic ((IndexedCashFlowModel.Cast _IndexedCashFlow.cell).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IndexedCashFlow.source + ".Equals") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IndexedCashFlow.cell
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
    [<ExcelFunction(Name="_IndexedCashFlow_exCouponDate", Description="Create a IndexedCashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IndexedCashFlow_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexedCashFlow",Description = "IndexedCashFlow")>] 
         indexedcashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexedCashFlow = Helper.toCell<IndexedCashFlow> indexedcashflow "IndexedCashFlow"  
                let builder (current : ICell) = withMnemonic mnemonic ((IndexedCashFlowModel.Cast _IndexedCashFlow.cell).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_IndexedCashFlow.source + ".ExCouponDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IndexedCashFlow.cell
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
    [<ExcelFunction(Name="_IndexedCashFlow_hasOccurred", Description="Create a IndexedCashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IndexedCashFlow_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexedCashFlow",Description = "IndexedCashFlow")>] 
         indexedcashflow : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "bool")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexedCashFlow = Helper.toCell<IndexedCashFlow> indexedcashflow "IndexedCashFlow"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder (current : ICell) = withMnemonic mnemonic ((IndexedCashFlowModel.Cast _IndexedCashFlow.cell).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IndexedCashFlow.source + ".HasOccurred") 

                                               [| _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IndexedCashFlow.cell
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
    [<ExcelFunction(Name="_IndexedCashFlow_tradingExCoupon", Description="Create a IndexedCashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IndexedCashFlow_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexedCashFlow",Description = "IndexedCashFlow")>] 
         indexedcashflow : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexedCashFlow = Helper.toCell<IndexedCashFlow> indexedcashflow "IndexedCashFlow"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((IndexedCashFlowModel.Cast _IndexedCashFlow.cell).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IndexedCashFlow.source + ".TradingExCoupon") 

                                               [| _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IndexedCashFlow.cell
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
    [<ExcelFunction(Name="_IndexedCashFlow_accept", Description="Create a IndexedCashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IndexedCashFlow_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexedCashFlow",Description = "IndexedCashFlow")>] 
         indexedcashflow : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexedCashFlow = Helper.toCell<IndexedCashFlow> indexedcashflow "IndexedCashFlow"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((IndexedCashFlowModel.Cast _IndexedCashFlow.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : IndexedCashFlow) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IndexedCashFlow.source + ".Accept") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IndexedCashFlow.cell
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
    [<ExcelFunction(Name="_IndexedCashFlow_registerWith", Description="Create a IndexedCashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IndexedCashFlow_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexedCashFlow",Description = "IndexedCashFlow")>] 
         indexedcashflow : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexedCashFlow = Helper.toCell<IndexedCashFlow> indexedcashflow "IndexedCashFlow"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((IndexedCashFlowModel.Cast _IndexedCashFlow.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : IndexedCashFlow) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IndexedCashFlow.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IndexedCashFlow.cell
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
    [<ExcelFunction(Name="_IndexedCashFlow_unregisterWith", Description="Create a IndexedCashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IndexedCashFlow_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IndexedCashFlow",Description = "IndexedCashFlow")>] 
         indexedcashflow : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IndexedCashFlow = Helper.toCell<IndexedCashFlow> indexedcashflow "IndexedCashFlow"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((IndexedCashFlowModel.Cast _IndexedCashFlow.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : IndexedCashFlow) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IndexedCashFlow.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IndexedCashFlow.cell
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
    [<ExcelFunction(Name="_IndexedCashFlow_Range", Description="Create a range of IndexedCashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IndexedCashFlow_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<IndexedCashFlow> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<IndexedCashFlow>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<IndexedCashFlow>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<IndexedCashFlow>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
