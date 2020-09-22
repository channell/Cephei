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
  It is NOT a coupon, i.e. no accruals.
  </summary> *)
[<AutoSerializable(true)>]
module CPICashFlowFunction =

    (*
        ! redefined to use baseFixing() and interpolation
    *)
    [<ExcelFunction(Name="_CPICashFlow_amount", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICashFlow_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "Reference to CPICashFlow")>] 
         cpicashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow" true 
                let builder () = withMnemonic mnemonic ((_CPICashFlow.cell :?> CPICashFlowModel).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPICashFlow.source + ".Amount") 
                                               [| _CPICashFlow.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
        ! you may not have a valid date
    *)
    [<ExcelFunction(Name="_CPICashFlow_baseDate", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICashFlow_baseDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "Reference to CPICashFlow")>] 
         cpicashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow" true 
                let builder () = withMnemonic mnemonic ((_CPICashFlow.cell :?> CPICashFlowModel).BaseDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CPICashFlow.source + ".BaseDate") 
                                               [| _CPICashFlow.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
        ! This does not have to agree with index on that date.
    *)
    [<ExcelFunction(Name="_CPICashFlow_baseFixing", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICashFlow_baseFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "Reference to CPICashFlow")>] 
         cpicashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow" true 
                let builder () = withMnemonic mnemonic ((_CPICashFlow.cell :?> CPICashFlowModel).BaseFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPICashFlow.source + ".BaseFixing") 
                                               [| _CPICashFlow.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICashFlow_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="notional",Description = "Reference to notional")>] 
         notional : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        ([<ExcelArgument(Name="baseDate",Description = "Reference to baseDate")>] 
         baseDate : obj)
        ([<ExcelArgument(Name="baseFixing",Description = "Reference to baseFixing")>] 
         baseFixing : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="paymentDate",Description = "Reference to paymentDate")>] 
         paymentDate : obj)
        ([<ExcelArgument(Name="growthOnly",Description = "Reference to growthOnly")>] 
         growthOnly : obj)
        ([<ExcelArgument(Name="interpolation",Description = "Reference to interpolation")>] 
         interpolation : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _notional = Helper.toCell<double> notional "notional" true
                let _index = Helper.toCell<ZeroInflationIndex> index "index" true
                let _baseDate = Helper.toCell<Date> baseDate "baseDate" true
                let _baseFixing = Helper.toCell<double> baseFixing "baseFixing" true
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" true
                let _growthOnly = Helper.toCell<bool> growthOnly "growthOnly" true
                let _interpolation = Helper.toCell<InterpolationType> interpolation "interpolation" true
                let _frequency = Helper.toCell<Frequency> frequency "frequency" true
                let builder () = withMnemonic mnemonic (Fun.CPICashFlow 
                                                            _notional.cell 
                                                            _index.cell 
                                                            _baseDate.cell 
                                                            _baseFixing.cell 
                                                            _fixingDate.cell 
                                                            _paymentDate.cell 
                                                            _growthOnly.cell 
                                                            _interpolation.cell 
                                                            _frequency.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPICashFlow>) l

                let source = Helper.sourceFold "Fun.CPICashFlow" 
                                               [| _notional.source
                                               ;  _index.source
                                               ;  _baseDate.source
                                               ;  _baseFixing.source
                                               ;  _fixingDate.source
                                               ;  _paymentDate.source
                                               ;  _growthOnly.source
                                               ;  _interpolation.source
                                               ;  _frequency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _notional.cell
                                ;  _index.cell
                                ;  _baseDate.cell
                                ;  _baseFixing.cell
                                ;  _fixingDate.cell
                                ;  _paymentDate.cell
                                ;  _growthOnly.cell
                                ;  _interpolation.cell
                                ;  _frequency.cell
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
    [<ExcelFunction(Name="_CPICashFlow_frequency", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICashFlow_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "Reference to CPICashFlow")>] 
         cpicashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow" true 
                let builder () = withMnemonic mnemonic ((_CPICashFlow.cell :?> CPICashFlowModel).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CPICashFlow.source + ".Frequency") 
                                               [| _CPICashFlow.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
        ! do you want linear/constant/as-index interpolation of future data?
    *)
    [<ExcelFunction(Name="_CPICashFlow_interpolation", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICashFlow_interpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "Reference to CPICashFlow")>] 
         cpicashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow" true 
                let builder () = withMnemonic mnemonic ((_CPICashFlow.cell :?> CPICashFlowModel).Interpolation
                                                       ) :> ICell
                let format (o : InterpolationType) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CPICashFlow.source + ".Interpolation") 
                                               [| _CPICashFlow.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow_date", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICashFlow_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "Reference to CPICashFlow")>] 
         cpicashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow" true 
                let builder () = withMnemonic mnemonic ((_CPICashFlow.cell :?> CPICashFlowModel).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CPICashFlow.source + ".Date") 
                                               [| _CPICashFlow.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow_fixingDate", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICashFlow_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "Reference to CPICashFlow")>] 
         cpicashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow" true 
                let builder () = withMnemonic mnemonic ((_CPICashFlow.cell :?> CPICashFlowModel).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CPICashFlow.source + ".FixingDate") 
                                               [| _CPICashFlow.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow_growthOnly", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICashFlow_growthOnly
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "Reference to CPICashFlow")>] 
         cpicashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow" true 
                let builder () = withMnemonic mnemonic ((_CPICashFlow.cell :?> CPICashFlowModel).GrowthOnly
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CPICashFlow.source + ".GrowthOnly") 
                                               [| _CPICashFlow.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow_index", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICashFlow_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "Reference to CPICashFlow")>] 
         cpicashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow" true 
                let builder () = withMnemonic mnemonic ((_CPICashFlow.cell :?> CPICashFlowModel).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Index>) l

                let source = Helper.sourceFold (_CPICashFlow.source + ".Index") 
                                               [| _CPICashFlow.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow_notional", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICashFlow_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "Reference to CPICashFlow")>] 
         cpicashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow" true 
                let builder () = withMnemonic mnemonic ((_CPICashFlow.cell :?> CPICashFlowModel).Notional
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPICashFlow.source + ".Notional") 
                                               [| _CPICashFlow.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow_CompareTo", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICashFlow_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "Reference to CPICashFlow")>] 
         cpicashflow : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow" true 
                let _cf = Helper.toCell<CashFlow> cf "cf" true
                let builder () = withMnemonic mnemonic ((_CPICashFlow.cell :?> CPICashFlowModel).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPICashFlow.source + ".CompareTo") 
                                               [| _CPICashFlow.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow_Equals", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICashFlow_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "Reference to CPICashFlow")>] 
         cpicashflow : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow" true 
                let _cf = Helper.toCell<Object> cf "cf" true
                let builder () = withMnemonic mnemonic ((_CPICashFlow.cell :?> CPICashFlowModel).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CPICashFlow.source + ".Equals") 
                                               [| _CPICashFlow.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow_exCouponDate", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICashFlow_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "Reference to CPICashFlow")>] 
         cpicashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow" true 
                let builder () = withMnemonic mnemonic ((_CPICashFlow.cell :?> CPICashFlowModel).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CPICashFlow.source + ".ExCouponDate") 
                                               [| _CPICashFlow.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow_hasOccurred", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICashFlow_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "Reference to CPICashFlow")>] 
         cpicashflow : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "Reference to includeRefDate")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow" true 
                let _refDate = Helper.toCell<Date> refDate "refDate" true
                let _includeRefDate = Helper.toNullable<Nullable<bool>> includeRefDate "includeRefDate"
                let builder () = withMnemonic mnemonic ((_CPICashFlow.cell :?> CPICashFlowModel).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CPICashFlow.source + ".HasOccurred") 
                                               [| _CPICashFlow.source
                                               ;  _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow_tradingExCoupon", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICashFlow_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "Reference to CPICashFlow")>] 
         cpicashflow : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow" true 
                let _refDate = Helper.toCell<Date> refDate "refDate" true
                let builder () = withMnemonic mnemonic ((_CPICashFlow.cell :?> CPICashFlowModel).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CPICashFlow.source + ".TradingExCoupon") 
                                               [| _CPICashFlow.source
                                               ;  _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow_accept", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICashFlow_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "Reference to CPICashFlow")>] 
         cpicashflow : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow" true 
                let _v = Helper.toCell<IAcyclicVisitor> v "v" true
                let builder () = withMnemonic mnemonic ((_CPICashFlow.cell :?> CPICashFlowModel).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : CPICashFlow) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CPICashFlow.source + ".Accept") 
                                               [| _CPICashFlow.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow_registerWith", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICashFlow_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "Reference to CPICashFlow")>] 
         cpicashflow : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_CPICashFlow.cell :?> CPICashFlowModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CPICashFlow) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CPICashFlow.source + ".RegisterWith") 
                                               [| _CPICashFlow.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow_unregisterWith", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICashFlow_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "Reference to CPICashFlow")>] 
         cpicashflow : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_CPICashFlow.cell :?> CPICashFlowModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CPICashFlow) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CPICashFlow.source + ".UnregisterWith") 
                                               [| _CPICashFlow.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow_Range", Description="Create a range of CPICashFlow",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPICashFlow_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CPICashFlow")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CPICashFlow> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CPICashFlow>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CPICashFlow>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CPICashFlow>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
