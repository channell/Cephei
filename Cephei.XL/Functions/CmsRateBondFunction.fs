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
module CmsRateBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CmsRateBond", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "double")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="schedule",Description = "Schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="index",Description = "SwapIndex")>] 
         index : obj)
        ([<ExcelArgument(Name="paymentDayCounter",Description = "DayCounter")>] 
         paymentDayCounter : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest or empty")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int or empty")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="gearings",Description = "double or empty")>] 
         gearings : obj)
        ([<ExcelArgument(Name="spreads",Description = "double or empty")>] 
         spreads : obj)
        ([<ExcelArgument(Name="caps",Description = "double or empty")>] 
         caps : obj)
        ([<ExcelArgument(Name="floors",Description = "double or empty")>] 
         floors : obj)
        ([<ExcelArgument(Name="inArrears",Description = "bool or empty")>] 
         inArrears : obj)
        ([<ExcelArgument(Name="redemption",Description = "double or empty")>] 
         redemption : obj)
        ([<ExcelArgument(Name="issueDate",Description = "Date or empty")>] 
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
                let _index = Helper.toCell<SwapIndex> index "index" 
                let _paymentDayCounter = Helper.toCell<DayCounter> paymentDayCounter "paymentDayCounter" 
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CmsRateBond 
                                                            _settlementDays.cell 
                                                            _faceAmount.cell 
                                                            _schedule.cell 
                                                            _index.cell 
                                                            _paymentDayCounter.cell 
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
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CmsRateBond>) l

                let source () = Helper.sourceFold "Fun.CmsRateBond" 
                                               [| _settlementDays.source
                                               ;  _faceAmount.source
                                               ;  _schedule.source
                                               ;  _index.source
                                               ;  _paymentDayCounter.source
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
                                ;  _index.cell
                                ;  _paymentDayCounter.cell
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
                    ; subscriber = Helper.subscriberModel<CmsRateBond> format
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
    [<ExcelFunction(Name="_CmsRateBond_accruedAmount", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsRateBond.source + ".AccruedAmount") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_calendar", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_CmsRateBond.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsRateBond> format
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
    [<ExcelFunction(Name="_CmsRateBond_cashflows", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_CmsRateBond.source + ".Cashflows") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_cleanPrice", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsRateBond.source + ".CleanPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_cleanPrice1", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_cleanPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
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

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsRateBond.source + ".CleanPrice1") 

                                               [| _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_dirtyPrice1", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_dirtyPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
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

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).DirtyPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsRateBond.source + ".DirtyPrice") 

                                               [| _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_dirtyPrice", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).DirtyPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsRateBond.source + ".DirtyPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_isExpired", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CmsRateBond.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_issueDate", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CmsRateBond.source + ".IssueDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_isTradable", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CmsRateBond.source + ".IsTradable") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_maturityDate", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CmsRateBond.source + ".MaturityDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_nextCashFlowDate", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CmsRateBond.source + ".NextCashFlowDate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_nextCouponRate", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsRateBond.source + ".NextCouponRate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_notional", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsRateBond.source + ".Notional") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_notionals", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_CmsRateBond.source + ".Notionals") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_previousCashFlowDate", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CmsRateBond.source + ".PreviousCashFlowDate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_previousCouponRate", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsRateBond.source + ".PreviousCouponRate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_redemption", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source () = Helper.sourceFold (_CmsRateBond.source + ".Redemption") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsRateBond> format
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
    [<ExcelFunction(Name="_CmsRateBond_redemptions", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_CmsRateBond.source + ".Redemptions") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_settlementDate", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CmsRateBond.source + ".SettlementDate") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_settlementDays", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsRateBond.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_settlementValue", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "double")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsRateBond.source + ".SettlementValue") 

                                               [| _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_settlementValue1", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_settlementValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsRateBond.source + ".SettlementValue1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_startDate", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CmsRateBond.source + ".StartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_yield1", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_yield1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
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

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).Yield1
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsRateBond.source + ".Yield1") 

                                               [| _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_yield", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
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

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).Yield
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsRateBond.source + ".Yield") 

                                               [| _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_CASH", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsRateBond.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_errorEstimate", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsRateBond.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_NPV", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsRateBond.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_result", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CmsRateBond.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_setPricingEngine", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : CmsRateBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CmsRateBond.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_valuationDate", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsRateBondModel.Cast _CmsRateBond.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CmsRateBond.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_Range", Description="Create a range of CmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsRateBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CmsRateBond> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<CmsRateBond> (c)) :> ICell
                let format (i : Generic.List<ICell<CmsRateBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<CmsRateBond>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
