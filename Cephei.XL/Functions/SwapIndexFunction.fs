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
  base class for swap-rate indexes
  </summary> *)
[<AutoSerializable(true)>]
module SwapIndexFunction =

    (*
        ! returns a copy of itself linked to a different tenor
    *)
    [<ExcelFunction(Name="_SwapIndex_clone", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).Clone
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_SwapIndex.source + ".Clone") 

                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
                                ;  _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns a copy of itself linked to a different curves
    *)
    [<ExcelFunction(Name="_SwapIndex_clone1", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_clone1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        ([<ExcelArgument(Name="forwarding",Description = "YieldTermStructure")>] 
         forwarding : obj)
        ([<ExcelArgument(Name="discounting",Description = "YieldTermStructure")>] 
         discounting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let _discounting = Helper.toHandle<YieldTermStructure> discounting "discounting" 
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).Clone1
                                                            _forwarding.cell 
                                                            _discounting.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_SwapIndex.source + ".Clone1") 

                                               [| _forwarding.source
                                               ;  _discounting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
                                ;  _forwarding.cell
                                ;  _discounting.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Other methods returns a copy of itself linked to a different forwarding curve
    *)
    [<ExcelFunction(Name="_SwapIndex_clone2", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_clone2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        ([<ExcelArgument(Name="forwarding",Description = "YieldTermStructure")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).Clone2
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_SwapIndex.source + ".Clone2") 

                                               [| _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwapIndex_discountingTermStructure", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_discountingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).DiscountingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_SwapIndex.source + ".DiscountingTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwapIndex_exogenousDiscount", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_exogenousDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).ExogenousDiscount
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapIndex.source + ".ExogenousDiscount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
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
    [<ExcelFunction(Name="_SwapIndex_fixedLegConvention", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_fixedLegConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).FixedLegConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapIndex.source + ".FixedLegConvention") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_SwapIndex_fixedLegTenor", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_fixedLegTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).FixedLegTenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_SwapIndex.source + ".FixedLegTenor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwapIndex_forecastFixing", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwapIndex.source + ".ForecastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
                                ;  _fixingDate.cell
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
    [<ExcelFunction(Name="_SwapIndex_forwardingTermStructure", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_SwapIndex.source + ".ForwardingTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwapIndex_iborIndex", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_iborIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).IborIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source () = Helper.sourceFold (_SwapIndex.source + ".IborIndex") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        InterestRateIndex interface
    *)
    [<ExcelFunction(Name="_SwapIndex_maturityDate", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SwapIndex.source + ".MaturityDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
                                ;  _valueDate.cell
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
    [<ExcelFunction(Name="_SwapIndex1", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="familyName",Description = "string")>] 
         familyName : obj)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="currency",Description = "Currency")>] 
         currency : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="fixedLegTenor",Description = "Period")>] 
         fixedLegTenor : obj)
        ([<ExcelArgument(Name="fixedLegConvention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         fixedLegConvention : obj)
        ([<ExcelArgument(Name="fixedLegDayCounter",Description = "DayCounter")>] 
         fixedLegDayCounter : obj)
        ([<ExcelArgument(Name="iborIndex",Description = "IborIndex")>] 
         iborIndex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _familyName = Helper.toCell<string> familyName "familyName" 
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _currency = Helper.toCell<Currency> currency "currency" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _fixedLegTenor = Helper.toCell<Period> fixedLegTenor "fixedLegTenor" 
                let _fixedLegConvention = Helper.toCell<BusinessDayConvention> fixedLegConvention "fixedLegConvention" 
                let _fixedLegDayCounter = Helper.toCell<DayCounter> fixedLegDayCounter "fixedLegDayCounter" 
                let _iborIndex = Helper.toCell<IborIndex> iborIndex "iborIndex" 
                let builder (current : ICell) = (Fun.SwapIndex1 
                                                            _familyName.cell 
                                                            _tenor.cell 
                                                            _settlementDays.cell 
                                                            _currency.cell 
                                                            _calendar.cell 
                                                            _fixedLegTenor.cell 
                                                            _fixedLegConvention.cell 
                                                            _fixedLegDayCounter.cell 
                                                            _iborIndex.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold "Fun.SwapIndex1" 
                                               [| _familyName.source
                                               ;  _tenor.source
                                               ;  _settlementDays.source
                                               ;  _currency.source
                                               ;  _calendar.source
                                               ;  _fixedLegTenor.source
                                               ;  _fixedLegConvention.source
                                               ;  _fixedLegDayCounter.source
                                               ;  _iborIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _familyName.cell
                                ;  _tenor.cell
                                ;  _settlementDays.cell
                                ;  _currency.cell
                                ;  _calendar.cell
                                ;  _fixedLegTenor.cell
                                ;  _fixedLegConvention.cell
                                ;  _fixedLegDayCounter.cell
                                ;  _iborIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        need by CashFlowVectors
    *)
    [<ExcelFunction(Name="_SwapIndex2", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.SwapIndex2 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold "Fun.SwapIndex2" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwapIndex", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="familyName",Description = "string")>] 
         familyName : obj)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="currency",Description = "Currency")>] 
         currency : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="fixedLegTenor",Description = "Period")>] 
         fixedLegTenor : obj)
        ([<ExcelArgument(Name="fixedLegConvention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         fixedLegConvention : obj)
        ([<ExcelArgument(Name="fixedLegDayCounter",Description = "DayCounter")>] 
         fixedLegDayCounter : obj)
        ([<ExcelArgument(Name="iborIndex",Description = "IborIndex")>] 
         iborIndex : obj)
        ([<ExcelArgument(Name="discountingTermStructure",Description = "YieldTermStructure")>] 
         discountingTermStructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _familyName = Helper.toCell<string> familyName "familyName" 
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _currency = Helper.toCell<Currency> currency "currency" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _fixedLegTenor = Helper.toCell<Period> fixedLegTenor "fixedLegTenor" 
                let _fixedLegConvention = Helper.toCell<BusinessDayConvention> fixedLegConvention "fixedLegConvention" 
                let _fixedLegDayCounter = Helper.toCell<DayCounter> fixedLegDayCounter "fixedLegDayCounter" 
                let _iborIndex = Helper.toCell<IborIndex> iborIndex "iborIndex" 
                let _discountingTermStructure = Helper.toHandle<YieldTermStructure> discountingTermStructure "discountingTermStructure" 
                let builder (current : ICell) = (Fun.SwapIndex
                                                            _familyName.cell 
                                                            _tenor.cell 
                                                            _settlementDays.cell 
                                                            _currency.cell 
                                                            _calendar.cell 
                                                            _fixedLegTenor.cell 
                                                            _fixedLegConvention.cell 
                                                            _fixedLegDayCounter.cell 
                                                            _iborIndex.cell 
                                                            _discountingTermStructure.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold "Fun.SwapIndex" 
                                               [| _familyName.source
                                               ;  _tenor.source
                                               ;  _settlementDays.source
                                               ;  _currency.source
                                               ;  _calendar.source
                                               ;  _fixedLegTenor.source
                                               ;  _fixedLegConvention.source
                                               ;  _fixedLegDayCounter.source
                                               ;  _iborIndex.source
                                               ;  _discountingTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _familyName.cell
                                ;  _tenor.cell
                                ;  _settlementDays.cell
                                ;  _currency.cell
                                ;  _calendar.cell
                                ;  _fixedLegTenor.cell
                                ;  _fixedLegConvention.cell
                                ;  _fixedLegDayCounter.cell
                                ;  _iborIndex.cell
                                ;  _discountingTermStructure.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        \warning Relinking the term structure underlying the index will not have effect on the returned swap. recheck
    *)
    [<ExcelFunction(Name="_SwapIndex_underlyingSwap", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_underlyingSwap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).UnderlyingSwap
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VanillaSwap>) l

                let source () = Helper.sourceFold (_SwapIndex.source + ".UnderlyingSwap") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
                                ;  _fixingDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwapIndex_currency", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_SwapIndex.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwapIndex_dayCounter", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_SwapIndex.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Inspectors
    *)
    [<ExcelFunction(Name="_SwapIndex_familyName", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapIndex.source + ".FamilyName") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
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
    [<ExcelFunction(Name="_SwapIndex_fixing", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwapIndex.source + ".Fixing") 

                                               [| _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
                                ;  _fixingDate.cell
                                ;  _forecastTodaysFixing.cell
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
    [<ExcelFunction(Name="_SwapIndex_fixingCalendar", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_SwapIndex.source + ".FixingCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwapIndex_fixingDate", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SwapIndex.source + ".FixingDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
                                ;  _valueDate.cell
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
    [<ExcelFunction(Name="_SwapIndex_fixingDays", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwapIndex.source + ".FixingDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
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
    [<ExcelFunction(Name="_SwapIndex_isValidFixingDate", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapIndex.source + ".IsValidFixingDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
                                ;  _fixingDate.cell
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
        Index interface
    *)
    [<ExcelFunction(Name="_SwapIndex_name", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapIndex.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
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
    [<ExcelFunction(Name="_SwapIndex_pastFixing", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapIndex.source + ".PastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
                                ;  _fixingDate.cell
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
    [<ExcelFunction(Name="_SwapIndex_tenor", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_SwapIndex.source + ".Tenor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Observer interface
    *)
    [<ExcelFunction(Name="_SwapIndex_update", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).Update
                                                       ) :> ICell
                let format (o : SwapIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapIndex.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
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
        Date calculations These methods can be overridden to implement particular conventions (e.g. EurLibor)
    *)
    [<ExcelFunction(Name="_SwapIndex_valueDate", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SwapIndex.source + ".ValueDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
                                ;  _fixingDate.cell
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
        Stores the historical fixing at the given date The date passed as arguments must be the actual calendar date of the fixing; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_SwapIndex_addFixing", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : SwapIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapIndex.source + ".AddFixing") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
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
        Stores historical fixings at the given dates The dates passed as arguments must be the actual calendar dates of the fixings; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_SwapIndex_addFixings", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        ([<ExcelArgument(Name="d",Description = "Date range")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double range")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : SwapIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapIndex.source + ".AddFixings") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
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
        Stores historical fixings from a TimeSeries The dates in the TimeSeries must be the actual calendar dates of the fixings; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_SwapIndex_addFixings1", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : SwapIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapIndex.source + ".AddFixings1") 

                                               [| _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
                                ;  _source.cell
                                ;  _forceOverwrite.cell
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
        Check if index allows for native fixings. If this returns false, calls to addFixing and similar methods will raise an exception.
    *)
    [<ExcelFunction(Name="_SwapIndex_allowsNativeFixings", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapIndex.source + ".AllowsNativeFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
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
        Clears all stored historical fixings
    *)
    [<ExcelFunction(Name="_SwapIndex_clearFixings", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).ClearFixings
                                                       ) :> ICell
                let format (o : SwapIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapIndex.source + ".ClearFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
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
    [<ExcelFunction(Name="_SwapIndex_registerWith", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : SwapIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapIndex.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
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
        Returns the fixing TimeSeries
    *)
    [<ExcelFunction(Name="_SwapIndex_timeSeries", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapIndex.source + ".TimeSeries") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
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
    [<ExcelFunction(Name="_SwapIndex_unregisterWith", Description="Create a SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapIndex",Description = "SwapIndex")>] 
         swapindex : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapIndex = Helper.toModelReference<SwapIndex> swapindex "SwapIndex"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((SwapIndexModel.Cast _SwapIndex.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : SwapIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapIndex.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapIndex.cell
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
    [<ExcelFunction(Name="_SwapIndex_Range", Description="Create a range of SwapIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapIndex_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SwapIndex> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<SwapIndex> (c)) :> ICell
                let format (i : Cephei.Cell.List<SwapIndex>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<SwapIndex>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
