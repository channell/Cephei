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
  fixed x zero-inflation, i.e. fixed x CPI(i'th fixing)/CPI(base) versus floating + spread  Note that this does ony the inflation-vs-floating-leg. Extension to inflation-vs-fixed-leg.  is simple - just replace the floating leg with a fixed leg.  Typically there are notional exchanges at the end: either inflated-notional vs notional; or just (inflated-notional - notional) vs zero.  The latter is perhaphs more typical. Setting subtractInflationNominal to true means that the original inflation nominal is subtracted from both nominals before they are exchanged, even if they are different.  This swap can mimic a ZCIIS where [(1+q)^n - 1] is exchanged against (cpi ratio - 1), by using differnt nominals on each leg and setting subtractInflationNominal to true.  ALSO - there must be just one date in each schedule.  The two legs can have different schedules, fixing (days vs lag), settlement, and roll conventions.  N.B. accrual adjustment periods are already in the schedules.  Trade date and swap settlement date are outside the scope of the instrument.
  </summary> *)
[<AutoSerializable(true)>]
module CPISwapFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CPISwap_baseCPI", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_baseCPI
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).BaseCPI
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".BaseCPI") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
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
        legs
    *)
    [<ExcelFunction(Name="_CPISwap_cpiLeg", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_cpiLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).CpiLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_CPISwap.source + ".CpiLeg") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPISwap", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "CPISwap.Type: Receiver, Payer")>] 
         Type : obj)
        ([<ExcelArgument(Name="nominal",Description = "double")>] 
         nominal : obj)
        ([<ExcelArgument(Name="subtractInflationNominal",Description = "bool")>] 
         subtractInflationNominal : obj)
        ([<ExcelArgument(Name="spread",Description = "double")>] 
         spread : obj)
        ([<ExcelArgument(Name="floatDayCount",Description = "DayCounter")>] 
         floatDayCount : obj)
        ([<ExcelArgument(Name="floatSchedule",Description = "Schedule")>] 
         floatSchedule : obj)
        ([<ExcelArgument(Name="floatPaymentRoll",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         floatPaymentRoll : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="floatIndex",Description = "IborIndex")>] 
         floatIndex : obj)
        ([<ExcelArgument(Name="fixedRate",Description = "double")>] 
         fixedRate : obj)
        ([<ExcelArgument(Name="baseCPI",Description = "double")>] 
         baseCPI : obj)
        ([<ExcelArgument(Name="fixedDayCount",Description = "DayCounter")>] 
         fixedDayCount : obj)
        ([<ExcelArgument(Name="fixedSchedule",Description = "Schedule")>] 
         fixedSchedule : obj)
        ([<ExcelArgument(Name="fixedPaymentRoll",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         fixedPaymentRoll : obj)
        ([<ExcelArgument(Name="observationLag",Description = "Period")>] 
         observationLag : obj)
        ([<ExcelArgument(Name="fixedIndex",Description = "ZeroInflationIndex")>] 
         fixedIndex : obj)
        ([<ExcelArgument(Name="observationInterpolation",Description = "InterpolationType: AsIndex, Flat, Linear or empty")>] 
         observationInterpolation : obj)
        ([<ExcelArgument(Name="inflationNominal",Description = "double")>] 
         inflationNominal : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<CPISwap.Type> Type "Type" 
                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _subtractInflationNominal = Helper.toCell<bool> subtractInflationNominal "subtractInflationNominal" 
                let _spread = Helper.toCell<double> spread "spread" 
                let _floatDayCount = Helper.toCell<DayCounter> floatDayCount "floatDayCount" 
                let _floatSchedule = Helper.toCell<Schedule> floatSchedule "floatSchedule" 
                let _floatPaymentRoll = Helper.toCell<BusinessDayConvention> floatPaymentRoll "floatPaymentRoll" 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let _floatIndex = Helper.toCell<IborIndex> floatIndex "floatIndex" 
                let _fixedRate = Helper.toCell<double> fixedRate "fixedRate" 
                let _baseCPI = Helper.toCell<double> baseCPI "baseCPI" 
                let _fixedDayCount = Helper.toCell<DayCounter> fixedDayCount "fixedDayCount" 
                let _fixedSchedule = Helper.toCell<Schedule> fixedSchedule "fixedSchedule" 
                let _fixedPaymentRoll = Helper.toCell<BusinessDayConvention> fixedPaymentRoll "fixedPaymentRoll" 
                let _observationLag = Helper.toCell<Period> observationLag "observationLag" 
                let _fixedIndex = Helper.toCell<ZeroInflationIndex> fixedIndex "fixedIndex" 
                let _observationInterpolation = Helper.toDefault<InterpolationType> observationInterpolation "observationInterpolation" InterpolationType.AsIndex
                let _inflationNominal = Helper.toNullable<double> inflationNominal "inflationNominal"
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CPISwap 
                                                            _Type.cell 
                                                            _nominal.cell 
                                                            _subtractInflationNominal.cell 
                                                            _spread.cell 
                                                            _floatDayCount.cell 
                                                            _floatSchedule.cell 
                                                            _floatPaymentRoll.cell 
                                                            _fixingDays.cell 
                                                            _floatIndex.cell 
                                                            _fixedRate.cell 
                                                            _baseCPI.cell 
                                                            _fixedDayCount.cell 
                                                            _fixedSchedule.cell 
                                                            _fixedPaymentRoll.cell 
                                                            _observationLag.cell 
                                                            _fixedIndex.cell 
                                                            _observationInterpolation.cell 
                                                            _inflationNominal.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPISwap>) l

                let source () = Helper.sourceFold "Fun.CPISwap" 
                                               [| _Type.source
                                               ;  _nominal.source
                                               ;  _subtractInflationNominal.source
                                               ;  _spread.source
                                               ;  _floatDayCount.source
                                               ;  _floatSchedule.source
                                               ;  _floatPaymentRoll.source
                                               ;  _fixingDays.source
                                               ;  _floatIndex.source
                                               ;  _fixedRate.source
                                               ;  _baseCPI.source
                                               ;  _fixedDayCount.source
                                               ;  _fixedSchedule.source
                                               ;  _fixedPaymentRoll.source
                                               ;  _observationLag.source
                                               ;  _fixedIndex.source
                                               ;  _observationInterpolation.source
                                               ;  _inflationNominal.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _nominal.cell
                                ;  _subtractInflationNominal.cell
                                ;  _spread.cell
                                ;  _floatDayCount.cell
                                ;  _floatSchedule.cell
                                ;  _floatPaymentRoll.cell
                                ;  _fixingDays.cell
                                ;  _floatIndex.cell
                                ;  _fixedRate.cell
                                ;  _baseCPI.cell
                                ;  _fixedDayCount.cell
                                ;  _fixedSchedule.cell
                                ;  _fixedPaymentRoll.cell
                                ;  _observationLag.cell
                                ;  _fixedIndex.cell
                                ;  _observationInterpolation.cell
                                ;  _inflationNominal.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPISwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPISwap_fairRate", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_fairRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).FairRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".FairRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
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
    [<ExcelFunction(Name="_CPISwap_fairSpread", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_fairSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).FairSpread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".FairSpread") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
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
    [<ExcelFunction(Name="_CPISwap_fixedDayCount", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_fixedDayCount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).FixedDayCount
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_CPISwap.source + ".FixedDayCount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPISwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPISwap_fixedIndex", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_fixedIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).FixedIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ZeroInflationIndex>) l

                let source () = Helper.sourceFold (_CPISwap.source + ".FixedIndex") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPISwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        fixed rate x inflation
    *)
    [<ExcelFunction(Name="_CPISwap_fixedLegNPV", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_fixedLegNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).FixedLegNPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".FixedLegNPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
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
    [<ExcelFunction(Name="_CPISwap_fixedPaymentRoll", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_fixedPaymentRoll
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).FixedPaymentRoll
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".FixedPaymentRoll") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
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
        fixed rate x inflation
    *)
    [<ExcelFunction(Name="_CPISwap_fixedRate", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_fixedRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).FixedRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".FixedRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
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
    [<ExcelFunction(Name="_CPISwap_fixedSchedule", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_fixedSchedule
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).FixedSchedule
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Schedule>) l

                let source () = Helper.sourceFold (_CPISwap.source + ".FixedSchedule") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPISwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPISwap_fixingDays", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".FixingDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
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
    [<ExcelFunction(Name="_CPISwap_floatDayCount", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_floatDayCount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).FloatDayCount
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_CPISwap.source + ".FloatDayCount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPISwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPISwap_floatIndex", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_floatIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).FloatIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source () = Helper.sourceFold (_CPISwap.source + ".FloatIndex") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPISwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPISwap_floatLeg", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_floatLeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).FloatLeg
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_CPISwap.source + ".FloatLeg") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        results float+spread
    *)
    [<ExcelFunction(Name="_CPISwap_floatLegNPV", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_floatLegNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).FloatLegNPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".FloatLegNPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
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
    [<ExcelFunction(Name="_CPISwap_floatPaymentRoll", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_floatPaymentRoll
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).FloatPaymentRoll
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".FloatPaymentRoll") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
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
    [<ExcelFunction(Name="_CPISwap_floatSchedule", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_floatSchedule
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).FloatSchedule
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Schedule>) l

                let source () = Helper.sourceFold (_CPISwap.source + ".FloatSchedule") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPISwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPISwap_inflationNominal", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_inflationNominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).InflationNominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".InflationNominal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
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
    [<ExcelFunction(Name="_CPISwap_nominal", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".Nominal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
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
    [<ExcelFunction(Name="_CPISwap_observationInterpolation", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_observationInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).ObservationInterpolation
                                                       ) :> ICell
                let format (o : InterpolationType) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".ObservationInterpolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
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
    [<ExcelFunction(Name="_CPISwap_observationLag", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_observationLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).ObservationLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_CPISwap.source + ".ObservationLag") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPISwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        float+spread
    *)
    [<ExcelFunction(Name="_CPISwap_spread", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".Spread") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
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
    [<ExcelFunction(Name="_CPISwap_subtractInflationNominal", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_subtractInflationNominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).SubtractInflationNominal
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".SubtractInflationNominal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
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
        inspectors
    *)
    [<ExcelFunction(Name="_CPISwap_type", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).Type
                                                       ) :> ICell
                let format (o : Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".TYPE") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
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
    [<ExcelFunction(Name="_CPISwap_endDiscounts", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_endDiscounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).EndDiscounts
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".EndDiscounts") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
                                ;  _j.cell
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
    (*!!
    [<ExcelFunction(Name="_CPISwap_engine", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_engine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).Engine
                                                       ) :> ICell
                let format (o : SwapEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".Engine") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
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
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_CPISwap_isExpired", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
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
    [<ExcelFunction(Name="_CPISwap_leg", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_leg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).Leg
                                                            _j.cell 
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_CPISwap.source + ".Leg") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
                                ;  _j.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPISwap_legBPS", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_legBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).LegBPS
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".LegBPS") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_CPISwap_legNPV", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_legNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).LegNPV
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".LegNPV") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_CPISwap_maturityDate", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".MaturityDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
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
    [<ExcelFunction(Name="_CPISwap_npvDateDiscount", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_npvDateDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).NpvDateDiscount
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".NpvDateDiscount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
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
    [<ExcelFunction(Name="_CPISwap_payer", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_payer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).Payer
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".Payer") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_CPISwap_startDate", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".StartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
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
    [<ExcelFunction(Name="_CPISwap_startDiscounts", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_startDiscounts
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).StartDiscounts
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".StartDiscounts") 

                                               [| _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_CPISwap_CASH", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
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
    [<ExcelFunction(Name="_CPISwap_errorEstimate", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
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
    [<ExcelFunction(Name="_CPISwap_NPV", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
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
        returns any additional result returned by the pricing engine.
    *)
    [<ExcelFunction(Name="_CPISwap_result", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
                                ;  _tag.cell
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
        ! calling this method will have no effects in case the performCalculation method was overridden in a derived class.
    *)
    [<ExcelFunction(Name="_CPISwap_setPricingEngine", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : CPISwap) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
                                ;  _e.cell
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
        ! returns the date the net present value refers to.
    *)
    [<ExcelFunction(Name="_CPISwap_valuationDate", Description="Create a CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPISwap",Description = "CPISwap")>] 
         cpiswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPISwap = Helper.toCell<CPISwap> cpiswap "CPISwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPISwapModel.Cast _CPISwap.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CPISwap.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPISwap.cell
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
    [<ExcelFunction(Name="_CPISwap_Range", Description="Create a range of CPISwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPISwap_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CPISwap> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CPISwap>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<CPISwap>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<CPISwap>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
