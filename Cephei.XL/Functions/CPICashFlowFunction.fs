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
    [<ExcelFunction(Name="_CPICashFlow_amount", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICashFlow_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "CPICashFlow")>] 
         cpicashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICashFlowModel.Cast _CPICashFlow.cell).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPICashFlow.source + ".Amount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
        ! you may not have a valid date
    *)
    [<ExcelFunction(Name="_CPICashFlow_baseDate", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICashFlow_baseDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "CPICashFlow")>] 
         cpicashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICashFlowModel.Cast _CPICashFlow.cell).BaseDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CPICashFlow.source + ".BaseDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
        ! This does not have to agree with index on that date.
    *)
    [<ExcelFunction(Name="_CPICashFlow_baseFixing", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICashFlow_baseFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "CPICashFlow")>] 
         cpicashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICashFlowModel.Cast _CPICashFlow.cell).BaseFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPICashFlow.source + ".BaseFixing") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICashFlow_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="notional",Description = "double")>] 
         notional : obj)
        ([<ExcelArgument(Name="index",Description = "ZeroInflationIndex")>] 
         index : obj)
        ([<ExcelArgument(Name="baseDate",Description = "Date")>] 
         baseDate : obj)
        ([<ExcelArgument(Name="baseFixing",Description = "double")>] 
         baseFixing : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="paymentDate",Description = "Date")>] 
         paymentDate : obj)
        ([<ExcelArgument(Name="growthOnly",Description = "bool or empty")>] 
         growthOnly : obj)
        ([<ExcelArgument(Name="interpolation",Description = "InterpolationType: AsIndex, Flat, Linear or empty")>] 
         interpolation : obj)
        ([<ExcelArgument(Name="frequency",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency or empty")>] 
         frequency : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _notional = Helper.toCell<double> notional "notional" 
                let _index = Helper.toCell<ZeroInflationIndex> index "index" 
                let _baseDate = Helper.toCell<Date> baseDate "baseDate" 
                let _baseFixing = Helper.toCell<double> baseFixing "baseFixing" 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" 
                let _growthOnly = Helper.toDefault<bool> growthOnly "growthOnly" false
                let _interpolation = Helper.toDefault<InterpolationType> interpolation "interpolation" InterpolationType.AsIndex
                let _frequency = Helper.toDefault<Frequency> frequency "frequency" Frequency.NoFrequency
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CPICashFlow 
                                                            _notional.cell 
                                                            _index.cell 
                                                            _baseDate.cell 
                                                            _baseFixing.cell 
                                                            _fixingDate.cell 
                                                            _paymentDate.cell 
                                                            _growthOnly.cell 
                                                            _interpolation.cell 
                                                            _frequency.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPICashFlow>) l

                let source () = Helper.sourceFold "Fun.CPICashFlow" 
                                               [| _notional.source
                                               ;  _index.source
                                               ;  _baseDate.source
                                               ;  _baseFixing.source
                                               ;  _fixingDate.source
                                               ;  _paymentDate.source
                                               ;  _growthOnly.source
                                               ;  _interpolation.source
                                               ;  _frequency.source
                                               ;  _evaluationDate.source
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
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPICashFlow> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPICashFlow_frequency", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICashFlow_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "CPICashFlow")>] 
         cpicashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICashFlowModel.Cast _CPICashFlow.cell).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPICashFlow.source + ".Frequency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
        ! do you want linear/constant/as-index interpolation of future data?
    *)
    [<ExcelFunction(Name="_CPICashFlow_interpolation", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICashFlow_interpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "CPICashFlow")>] 
         cpicashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICashFlowModel.Cast _CPICashFlow.cell).Interpolation
                                                       ) :> ICell
                let format (o : InterpolationType) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPICashFlow.source + ".Interpolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow_date", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICashFlow_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "CPICashFlow")>] 
         cpicashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICashFlowModel.Cast _CPICashFlow.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CPICashFlow.source + ".Date") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow_fixingDate", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICashFlow_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "CPICashFlow")>] 
         cpicashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICashFlowModel.Cast _CPICashFlow.cell).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CPICashFlow.source + ".FixingDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow_growthOnly", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICashFlow_growthOnly
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "CPICashFlow")>] 
         cpicashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICashFlowModel.Cast _CPICashFlow.cell).GrowthOnly
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPICashFlow.source + ".GrowthOnly") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow_index", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICashFlow_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "CPICashFlow")>] 
         cpicashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICashFlowModel.Cast _CPICashFlow.cell).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Index>) l

                let source () = Helper.sourceFold (_CPICashFlow.source + ".Index") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPICashFlow> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPICashFlow_notional", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICashFlow_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "CPICashFlow")>] 
         cpicashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICashFlowModel.Cast _CPICashFlow.cell).Notional
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPICashFlow.source + ".Notional") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow_CompareTo", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICashFlow_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "CPICashFlow")>] 
         cpicashflow : obj)
        ([<ExcelArgument(Name="cf",Description = "CashFlow")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow"  
                let _cf = Helper.toCell<CashFlow> cf "cf" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPICashFlowModel.Cast _CPICashFlow.cell).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPICashFlow.source + ".CompareTo") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow_Equals", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICashFlow_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "CPICashFlow")>] 
         cpicashflow : obj)
        ([<ExcelArgument(Name="cf",Description = "Object")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow"  
                let _cf = Helper.toCell<Object> cf "cf" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPICashFlowModel.Cast _CPICashFlow.cell).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPICashFlow.source + ".Equals") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow_exCouponDate", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICashFlow_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "CPICashFlow")>] 
         cpicashflow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICashFlowModel.Cast _CPICashFlow.cell).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CPICashFlow.source + ".ExCouponDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow_hasOccurred", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICashFlow_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "CPICashFlow")>] 
         cpicashflow : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "bool")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder (current : ICell) = withMnemonic mnemonic ((CPICashFlowModel.Cast _CPICashFlow.cell).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPICashFlow.source + ".HasOccurred") 

                                               [| _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow_tradingExCoupon", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICashFlow_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "CPICashFlow")>] 
         cpicashflow : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPICashFlowModel.Cast _CPICashFlow.cell).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPICashFlow.source + ".TradingExCoupon") 

                                               [| _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow_accept", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICashFlow_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "CPICashFlow")>] 
         cpicashflow : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPICashFlowModel.Cast _CPICashFlow.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : CPICashFlow) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPICashFlow.source + ".Accept") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow_registerWith", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICashFlow_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "CPICashFlow")>] 
         cpicashflow : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPICashFlowModel.Cast _CPICashFlow.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CPICashFlow) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPICashFlow.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow_unregisterWith", Description="Create a CPICashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICashFlow_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICashFlow",Description = "CPICashFlow")>] 
         cpicashflow : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICashFlow = Helper.toCell<CPICashFlow> cpicashflow "CPICashFlow"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPICashFlowModel.Cast _CPICashFlow.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CPICashFlow) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPICashFlow.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICashFlow.cell
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
    [<ExcelFunction(Name="_CPICashFlow_Range", Description="Create a range of CPICashFlow",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICashFlow_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CPICashFlow> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<CPICashFlow> (c)) :> ICell
                let format (i : Generic.List<ICell<CPICashFlow>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<CPICashFlow>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
