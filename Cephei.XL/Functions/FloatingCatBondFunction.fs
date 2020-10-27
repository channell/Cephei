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

  </summary> *)
[<AutoSerializable(true)>]
module FloatingCatBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FloatingCatBond", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_create
        ([<ExcelArgument(Name="Mnemonic",Description = "FloatingCatBond")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "double")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="startDate",Description = "Date")>] 
         startDate : obj)
        ([<ExcelArgument(Name="maturityDate",Description = "Date")>] 
         maturityDate : obj)
        ([<ExcelArgument(Name="couponFrequency",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         couponFrequency : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="iborIndex",Description = "IborIndex")>] 
         iborIndex : obj)
        ([<ExcelArgument(Name="accrualDayCounter",Description = "DayCounter")>] 
         accrualDayCounter : obj)
        ([<ExcelArgument(Name="notionalRisk",Description = "NotionalRisk")>] 
         notionalRisk : obj)
        ([<ExcelArgument(Name="accrualConvention",Description = "FloatingCatBond")>] 
         accrualConvention : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "FloatingCatBond")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "FloatingCatBond")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="gearings",Description = "FloatingCatBond")>] 
         gearings : obj)
        ([<ExcelArgument(Name="spreads",Description = "FloatingCatBond")>] 
         spreads : obj)
        ([<ExcelArgument(Name="caps",Description = "FloatingCatBond")>] 
         caps : obj)
        ([<ExcelArgument(Name="floors",Description = "FloatingCatBond")>] 
         floors : obj)
        ([<ExcelArgument(Name="inArrears",Description = "FloatingCatBond")>] 
         inArrears : obj)
        ([<ExcelArgument(Name="redemption",Description = "FloatingCatBond")>] 
         redemption : obj)
        ([<ExcelArgument(Name="issueDate",Description = "FloatingCatBond")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="stubDate",Description = "FloatingCatBond")>] 
         stubDate : obj)
        ([<ExcelArgument(Name="rule",Description = "FloatingCatBond")>] 
         rule : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "FloatingCatBond")>] 
         endOfMonth : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _faceAmount = Helper.toCell<double> faceAmount "faceAmount" 
                let _startDate = Helper.toCell<Date> startDate "startDate" 
                let _maturityDate = Helper.toCell<Date> maturityDate "maturityDate" 
                let _couponFrequency = Helper.toCell<Frequency> couponFrequency "couponFrequency" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _iborIndex = Helper.toCell<IborIndex> iborIndex "iborIndex" 
                let _accrualDayCounter = Helper.toCell<DayCounter> accrualDayCounter "accrualDayCounter" 
                let _notionalRisk = Helper.toCell<NotionalRisk> notionalRisk "notionalRisk" 
                let _accrualConvention = Helper.toDefault<BusinessDayConvention> accrualConvention "accrualConvention" BusinessDayConvention.Following
                let _paymentConvention = Helper.toDefault<BusinessDayConvention> paymentConvention "paymentConvention" BusinessDayConvention.Following
                let _fixingDays = Helper.toDefault<int> fixingDays "fixingDays" 0
                let _gearings = Helper.toDefault<Generic.List<double>> gearings "gearings" null
                let _spreads = Helper.toDefault<Generic.List<double>> spreads "spreads" null
                let _caps = Helper.toDefault<Generic.List<Nullable<double>>> caps "caps" null
                let _floors = Helper.toDefault<Generic.List<Nullable<double>>> floors "floors" null
                let _inArrears = Helper.toDefault<bool> inArrears "inArrears" false
                let _redemption = Helper.toDefault<double> redemption "redemption" 100.0
                let _issueDate = Helper.toDefault<Date> issueDate "issueDate" null
                let _stubDate = Helper.toDefault<Date> stubDate "stubDate" null
                let _rule = Helper.toDefault<DateGeneration.Rule> rule "rule" DateGeneration.Rule.Backward
                let _endOfMonth = Helper.toDefault<bool> endOfMonth "endOfMonth" false
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FloatingCatBond 
                                                            _settlementDays.cell 
                                                            _faceAmount.cell 
                                                            _startDate.cell 
                                                            _maturityDate.cell 
                                                            _couponFrequency.cell 
                                                            _calendar.cell 
                                                            _iborIndex.cell 
                                                            _accrualDayCounter.cell 
                                                            _notionalRisk.cell 
                                                            _accrualConvention.cell 
                                                            _paymentConvention.cell 
                                                            _fixingDays.cell 
                                                            _gearings.cell 
                                                            _spreads.cell 
                                                            _caps.cell 
                                                            _floors.cell 
                                                            _inArrears.cell 
                                                            _redemption.cell 
                                                            _issueDate.cell 
                                                            _stubDate.cell 
                                                            _rule.cell 
                                                            _endOfMonth.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingCatBond>) l

                let source () = Helper.sourceFold "Fun.FloatingCatBond" 
                                               [| _settlementDays.source
                                               ;  _faceAmount.source
                                               ;  _startDate.source
                                               ;  _maturityDate.source
                                               ;  _couponFrequency.source
                                               ;  _calendar.source
                                               ;  _iborIndex.source
                                               ;  _accrualDayCounter.source
                                               ;  _notionalRisk.source
                                               ;  _accrualConvention.source
                                               ;  _paymentConvention.source
                                               ;  _fixingDays.source
                                               ;  _gearings.source
                                               ;  _spreads.source
                                               ;  _caps.source
                                               ;  _floors.source
                                               ;  _inArrears.source
                                               ;  _redemption.source
                                               ;  _issueDate.source
                                               ;  _stubDate.source
                                               ;  _rule.source
                                               ;  _endOfMonth.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _faceAmount.cell
                                ;  _startDate.cell
                                ;  _maturityDate.cell
                                ;  _couponFrequency.cell
                                ;  _calendar.cell
                                ;  _iborIndex.cell
                                ;  _accrualDayCounter.cell
                                ;  _notionalRisk.cell
                                ;  _accrualConvention.cell
                                ;  _paymentConvention.cell
                                ;  _fixingDays.cell
                                ;  _gearings.cell
                                ;  _spreads.cell
                                ;  _caps.cell
                                ;  _floors.cell
                                ;  _inArrears.cell
                                ;  _redemption.cell
                                ;  _issueDate.cell
                                ;  _stubDate.cell
                                ;  _rule.cell
                                ;  _endOfMonth.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FloatingCatBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingCatBond1", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "FloatingCatBond")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "double")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="schedule",Description = "Schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="iborIndex",Description = "IborIndex")>] 
         iborIndex : obj)
        ([<ExcelArgument(Name="paymentDayCounter",Description = "DayCounter")>] 
         paymentDayCounter : obj)
        ([<ExcelArgument(Name="notionalRisk",Description = "NotionalRisk")>] 
         notionalRisk : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "FloatingCatBond")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "FloatingCatBond")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="gearings",Description = "FloatingCatBond")>] 
         gearings : obj)
        ([<ExcelArgument(Name="spreads",Description = "FloatingCatBond")>] 
         spreads : obj)
        ([<ExcelArgument(Name="caps",Description = "FloatingCatBond")>] 
         caps : obj)
        ([<ExcelArgument(Name="floors",Description = "FloatingCatBond")>] 
         floors : obj)
        ([<ExcelArgument(Name="inArrears",Description = "FloatingCatBond")>] 
         inArrears : obj)
        ([<ExcelArgument(Name="redemption",Description = "FloatingCatBond")>] 
         redemption : obj)
        ([<ExcelArgument(Name="issueDate",Description = "FloatingCatBond")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _faceAmount = Helper.toCell<double> faceAmount "faceAmount" 
                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _iborIndex = Helper.toCell<IborIndex> iborIndex "iborIndex" 
                let _paymentDayCounter = Helper.toCell<DayCounter> paymentDayCounter "paymentDayCounter" 
                let _notionalRisk = Helper.toCell<NotionalRisk> notionalRisk "notionalRisk" 
                let _paymentConvention = Helper.toDefault<BusinessDayConvention> paymentConvention "paymentConvention" BusinessDayConvention.Following
                let _fixingDays = Helper.toDefault<int> fixingDays "fixingDays" 0
                let _gearings = Helper.toDefault<Generic.List<double>> gearings "gearings" null
                let _spreads = Helper.toDefault<Generic.List<double>> spreads "spreads" null
                let _caps = Helper.toDefault<Generic.List<Nullable<double>>> caps "caps" null
                let _floors = Helper.toDefault<Generic.List<Nullable<double>>> floors "floors" null
                let _inArrears = Helper.toDefault<bool> inArrears "inArrears" false
                let _redemption = Helper.toDefault<double> redemption "redemption" 100.0
                let _issueDate = Helper.toDefault<Date> issueDate "issueDate" null
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FloatingCatBond1 
                                                            _settlementDays.cell 
                                                            _faceAmount.cell 
                                                            _schedule.cell 
                                                            _iborIndex.cell 
                                                            _paymentDayCounter.cell 
                                                            _notionalRisk.cell 
                                                            _paymentConvention.cell 
                                                            _fixingDays.cell 
                                                            _gearings.cell 
                                                            _spreads.cell 
                                                            _caps.cell 
                                                            _floors.cell 
                                                            _inArrears.cell 
                                                            _redemption.cell 
                                                            _issueDate.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingCatBond>) l

                let source () = Helper.sourceFold "Fun.FloatingCatBond1" 
                                               [| _settlementDays.source
                                               ;  _faceAmount.source
                                               ;  _schedule.source
                                               ;  _iborIndex.source
                                               ;  _paymentDayCounter.source
                                               ;  _notionalRisk.source
                                               ;  _paymentConvention.source
                                               ;  _fixingDays.source
                                               ;  _gearings.source
                                               ;  _spreads.source
                                               ;  _caps.source
                                               ;  _floors.source
                                               ;  _inArrears.source
                                               ;  _redemption.source
                                               ;  _issueDate.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _faceAmount.cell
                                ;  _schedule.cell
                                ;  _iborIndex.cell
                                ;  _paymentDayCounter.cell
                                ;  _notionalRisk.cell
                                ;  _paymentConvention.cell
                                ;  _fixingDays.cell
                                ;  _gearings.cell
                                ;  _spreads.cell
                                ;  _caps.cell
                                ;  _floors.cell
                                ;  _inArrears.cell
                                ;  _redemption.cell
                                ;  _issueDate.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FloatingCatBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingCatBond_exhaustionProbability", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_exhaustionProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).ExhaustionProbability
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".ExhaustionProbability") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_expectedLoss", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_expectedLoss
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).ExpectedLoss
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".ExpectedLoss") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_lossProbability", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_lossProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).LossProbability
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".LossProbability") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_accruedAmount", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".AccruedAmount") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_calendar", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FloatingCatBond> format
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
    [<ExcelFunction(Name="_FloatingCatBond_cashflows", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".Cashflows") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_cleanPrice", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".CleanPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_cleanPrice1", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_cleanPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
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

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".CleanPrice1") 

                                               [| _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_dirtyPrice1", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_dirtyPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
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

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).DirtyPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".DirtyPrice1") 

                                               [| _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_dirtyPrice", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).DirtyPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".DirtyPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_isExpired", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_issueDate", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".IssueDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_isTradable", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".IsTradable") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_maturityDate", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".MaturityDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_nextCashFlowDate", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".NextCashFlowDate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_nextCouponRate", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".NextCouponRate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_notional", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".Notional") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_notionals", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".Notionals") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_previousCashFlowDate", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".PreviousCashFlowDate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_previousCouponRate", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".PreviousCouponRate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_redemption", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".Redemption") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FloatingCatBond> format
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
    [<ExcelFunction(Name="_FloatingCatBond_redemptions", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".Redemptions") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_settlementDate", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".SettlementDate") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_settlementDays", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_settlementValue", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "double")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".SettlementValue") 

                                               [| _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_settlementValue1", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_settlementValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".SettlementValue1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_startDate", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".StartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_yield1", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_yield1
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
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

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).Yield1
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".Yield1") 

                                               [| _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_yield", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
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

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).Yield
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".Yield") 

                                               [| _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_CASH", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_errorEstimate", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_NPV", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_result", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_setPricingEngine", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : FloatingCatBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_valuationDate", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingCatBondModel.Cast _FloatingCatBond.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FloatingCatBond.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_Range", Description="Create a range of FloatingCatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingCatBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FloatingCatBond> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FloatingCatBond>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<FloatingCatBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<FloatingCatBond>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
