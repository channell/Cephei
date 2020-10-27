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
  instruments
  </summary> *)
[<AutoSerializable(true)>]
module CPIBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CPIBond_baseCPI", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_baseCPI
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).BaseCPI
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".BaseCPI") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "double")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="growthOnly",Description = "bool")>] 
         growthOnly : obj)
        ([<ExcelArgument(Name="baseCPI",Description = "double")>] 
         baseCPI : obj)
        ([<ExcelArgument(Name="observationLag",Description = "Period")>] 
         observationLag : obj)
        ([<ExcelArgument(Name="cpiIndex",Description = "ZeroInflationIndex")>] 
         cpiIndex : obj)
        ([<ExcelArgument(Name="observationInterpolation",Description = "InterpolationType: AsIndex, Flat, Linear")>] 
         observationInterpolation : obj)
        ([<ExcelArgument(Name="schedule",Description = "Schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="fixedRate",Description = "double range")>] 
         fixedRate : obj)
        ([<ExcelArgument(Name="accrualDayCounter",Description = "DayCounter")>] 
         accrualDayCounter : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest or empty")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="issueDate",Description = "Date or empty")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="paymentCalendar",Description = "Calendar or empty")>] 
         paymentCalendar : obj)
        ([<ExcelArgument(Name="exCouponPeriod",Description = "Period or empty")>] 
         exCouponPeriod : obj)
        ([<ExcelArgument(Name="exCouponCalendar",Description = "Calendar or empty")>] 
         exCouponCalendar : obj)
        ([<ExcelArgument(Name="exCouponConvention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest or empty")>] 
         exCouponConvention : obj)
        ([<ExcelArgument(Name="exCouponEndOfMonth",Description = "bool or empty")>] 
         exCouponEndOfMonth : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _faceAmount = Helper.toCell<double> faceAmount "faceAmount" 
                let _growthOnly = Helper.toCell<bool> growthOnly "growthOnly" 
                let _baseCPI = Helper.toCell<double> baseCPI "baseCPI" 
                let _observationLag = Helper.toCell<Period> observationLag "observationLag" 
                let _cpiIndex = Helper.toCell<ZeroInflationIndex> cpiIndex "cpiIndex" 
                let _observationInterpolation = Helper.toCell<InterpolationType> observationInterpolation "observationInterpolation" 
                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _fixedRate = Helper.toCell<Generic.List<double>> fixedRate "fixedRate" 
                let _accrualDayCounter = Helper.toCell<DayCounter> accrualDayCounter "accrualDayCounter" 
                let _paymentConvention = Helper.toDefault<BusinessDayConvention> paymentConvention "paymentConvention" BusinessDayConvention.ModifiedFollowing
                let _issueDate = Helper.toDefault<Date> issueDate "issueDate" null
                let _paymentCalendar = Helper.toDefault<Calendar> paymentCalendar "paymentCalendar" null
                let _exCouponPeriod = Helper.toDefault<Period> exCouponPeriod "exCouponPeriod" null
                let _exCouponCalendar = Helper.toDefault<Calendar> exCouponCalendar "exCouponCalendar" null
                let _exCouponConvention = Helper.toDefault<BusinessDayConvention> exCouponConvention "exCouponConvention" BusinessDayConvention.Unadjusted
                let _exCouponEndOfMonth = Helper.toDefault<bool> exCouponEndOfMonth "exCouponEndOfMonth" false
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CPIBond 
                                                            _settlementDays.cell 
                                                            _faceAmount.cell 
                                                            _growthOnly.cell 
                                                            _baseCPI.cell 
                                                            _observationLag.cell 
                                                            _cpiIndex.cell 
                                                            _observationInterpolation.cell 
                                                            _schedule.cell 
                                                            _fixedRate.cell 
                                                            _accrualDayCounter.cell 
                                                            _paymentConvention.cell 
                                                            _issueDate.cell 
                                                            _paymentCalendar.cell 
                                                            _exCouponPeriod.cell 
                                                            _exCouponCalendar.cell 
                                                            _exCouponConvention.cell 
                                                            _exCouponEndOfMonth.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPIBond>) l

                let source () = Helper.sourceFold "Fun.CPIBond" 
                                               [| _settlementDays.source
                                               ;  _faceAmount.source
                                               ;  _growthOnly.source
                                               ;  _baseCPI.source
                                               ;  _observationLag.source
                                               ;  _cpiIndex.source
                                               ;  _observationInterpolation.source
                                               ;  _schedule.source
                                               ;  _fixedRate.source
                                               ;  _accrualDayCounter.source
                                               ;  _paymentConvention.source
                                               ;  _issueDate.source
                                               ;  _paymentCalendar.source
                                               ;  _exCouponPeriod.source
                                               ;  _exCouponCalendar.source
                                               ;  _exCouponConvention.source
                                               ;  _exCouponEndOfMonth.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _faceAmount.cell
                                ;  _growthOnly.cell
                                ;  _baseCPI.cell
                                ;  _observationLag.cell
                                ;  _cpiIndex.cell
                                ;  _observationInterpolation.cell
                                ;  _schedule.cell
                                ;  _fixedRate.cell
                                ;  _accrualDayCounter.cell
                                ;  _paymentConvention.cell
                                ;  _issueDate.cell
                                ;  _paymentCalendar.cell
                                ;  _exCouponPeriod.cell
                                ;  _exCouponCalendar.cell
                                ;  _exCouponConvention.cell
                                ;  _exCouponEndOfMonth.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPIBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPIBond_cpiIndex", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_cpiIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).CpiIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ZeroInflationIndex>) l

                let source () = Helper.sourceFold (_CPIBond.source + ".CpiIndex") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPIBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPIBond_dayCounter", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_CPIBond.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPIBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPIBond_frequency", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".Frequency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_growthOnly", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_growthOnly
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).GrowthOnly
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".GrowthOnly") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_observationInterpolation", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_observationInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).ObservationInterpolation
                                                       ) :> ICell
                let format (o : InterpolationType) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".ObservationInterpolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_observationLag", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_observationLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).ObservationLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_CPIBond.source + ".ObservationLag") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPIBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_CPIBond_accruedAmount", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".AccruedAmount") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                ;  _settlement.cell
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
    [<ExcelFunction(Name="_CPIBond_calendar", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_CPIBond.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPIBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        \note returns all the cashflows, including the redemptions.
    *)
    [<ExcelFunction(Name="_CPIBond_cashflows", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_CPIBond.source + ".Cashflows") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
        ! The default bond settlement is used for calculation.  \warning the theoretical price calculated from a flat term structure might differ slightly from the price calculated from the corresponding yield by means of the other overload of this function. If the price from a constant yield is desired, it is advisable to use such other overload.
    *)
    [<ExcelFunction(Name="_CPIBond_cleanPrice", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".CleanPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_CPIBond_cleanPrice1", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_cleanPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="Yield",Description = "double")>] 
         Yield : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".CleanPrice1") 

                                               [| _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                ;  _Yield.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _settlement.cell
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
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_CPIBond_dirtyPrice1", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_dirtyPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="Yield",Description = "double")>] 
         Yield : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).DirtyPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".DirtyPrice1") 

                                               [| _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                ;  _Yield.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _settlement.cell
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
        ! The default bond settlement is used for calculation.  \warning the theoretical price calculated from a flat term structure might differ slightly from the price calculated from the corresponding yield by means of the other overload of this function. If the price from a constant yield is desired, it is advisable to use such other overload.
    *)
    [<ExcelFunction(Name="_CPIBond_dirtyPrice", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).DirtyPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".DirtyPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_isExpired", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_issueDate", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".IssueDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_isTradable", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".IsTradable") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_CPIBond_maturityDate", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".MaturityDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_nextCashFlowDate", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".NextCashFlowDate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                ;  _settlement.cell
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
        ! Expected next coupon: depending on (the bond and) the given date the coupon can be historic, deterministic or expected in a stochastic sense. When the bond settlement date is used the coupon is the already-fixed not-yet-paid one.  The current bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_CPIBond_nextCouponRate", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".NextCouponRate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                ;  _settlement.cell
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
    [<ExcelFunction(Name="_CPIBond_notional", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".Notional") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_CPIBond_notionals", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_CPIBond.source + ".Notionals") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPIBond_previousCashFlowDate", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".PreviousCashFlowDate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                ;  _settlement.cell
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
        ! Expected previous coupon: depending on (the bond and) the given date the coupon can be historic, deterministic or expected in a stochastic sense. When the bond settlement date is used the coupon is the last paid one.  The current bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_CPIBond_previousCouponRate", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".PreviousCouponRate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                ;  _settlement.cell
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
        returns the redemption, if only one is defined
    *)
    [<ExcelFunction(Name="_CPIBond_redemption", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source () = Helper.sourceFold (_CPIBond.source + ".Redemption") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPIBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns just the redemption flows (not interest payments)
    *)
    [<ExcelFunction(Name="_CPIBond_redemptions", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_CPIBond.source + ".Redemptions") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_settlementDate", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".SettlementDate") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                ;  _date.cell
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
    [<ExcelFunction(Name="_CPIBond_settlementDays", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_settlementValue", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "double")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".SettlementValue") 

                                               [| _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                ;  _cleanPrice.cell
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
    [<ExcelFunction(Name="_CPIBond_settlementValue1", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_settlementValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".SettlementValue1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_startDate", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".StartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_CPIBond_yield1", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_yield1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "double")>] 
         cleanPrice : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        ([<ExcelArgument(Name="accuracy",Description = "double")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "int")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).Yield1
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".Yield1") 

                                               [| _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                ;  _cleanPrice.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _settlement.cell
                                ;  _accuracy.cell
                                ;  _maxEvaluations.cell
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
        ! The default bond settlement and theoretical price are used for calculation.
    *)
    [<ExcelFunction(Name="_CPIBond_yield", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="accuracy",Description = "double")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "int")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).Yield
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".Yield") 

                                               [| _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _accuracy.cell
                                ;  _maxEvaluations.cell
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
    [<ExcelFunction(Name="_CPIBond_CASH", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_errorEstimate", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_NPV", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_result", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_setPricingEngine", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : CPIBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_valuationDate", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPIBondModel.Cast _CPIBond.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CPIBond.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_Range", Description="Create a range of CPIBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPIBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CPIBond> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CPIBond>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<CPIBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<CPIBond>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
