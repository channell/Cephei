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
module MBSFixedRateBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_MBSFixedRateBond_BondEquivalentYield", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_BondEquivalentYield
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).BondEquivalentYield
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".BondEquivalentYield") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_BondFactors", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_BondFactors
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).BondFactors
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".BondFactors") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_expectedCashflows", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_expectedCashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).ExpectedCashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".ExpectedCashflows") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_create
        ([<ExcelArgument(Name="Mnemonic",Description = "MBSFixedRateBond")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "double")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="startDate",Description = "Date")>] 
         startDate : obj)
        ([<ExcelArgument(Name="bondTenor",Description = "Period")>] 
         bondTenor : obj)
        ([<ExcelArgument(Name="originalLength",Description = "Period")>] 
         originalLength : obj)
        ([<ExcelArgument(Name="sinkingFrequency",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         sinkingFrequency : obj)
        ([<ExcelArgument(Name="WACRate",Description = "double")>] 
         WACRate : obj)
        ([<ExcelArgument(Name="PassThroughRate",Description = "double")>] 
         PassThroughRate : obj)
        ([<ExcelArgument(Name="accrualDayCounter",Description = "DayCounter")>] 
         accrualDayCounter : obj)
        ([<ExcelArgument(Name="prepayModel",Description = "IPrepayModel")>] 
         prepayModel : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "MBSFixedRateBond")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="issueDate",Description = "MBSFixedRateBond")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _faceAmount = Helper.toCell<double> faceAmount "faceAmount" 
                let _startDate = Helper.toCell<Date> startDate "startDate" 
                let _bondTenor = Helper.toCell<Period> bondTenor "bondTenor" 
                let _originalLength = Helper.toCell<Period> originalLength "originalLength" 
                let _sinkingFrequency = Helper.toCell<Frequency> sinkingFrequency "sinkingFrequency" 
                let _WACRate = Helper.toCell<double> WACRate "WACRate" 
                let _PassThroughRate = Helper.toCell<double> PassThroughRate "PassThroughRate" 
                let _accrualDayCounter = Helper.toCell<DayCounter> accrualDayCounter "accrualDayCounter" 
                let _prepayModel = Helper.toCell<IPrepayModel> prepayModel "prepayModel" 
                let _paymentConvention = Helper.toDefault<BusinessDayConvention> paymentConvention "paymentConvention" BusinessDayConvention.Following
                let _issueDate = Helper.toDefault<Date> issueDate "issueDate" null
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.MBSFixedRateBond 
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _faceAmount.cell 
                                                            _startDate.cell 
                                                            _bondTenor.cell 
                                                            _originalLength.cell 
                                                            _sinkingFrequency.cell 
                                                            _WACRate.cell 
                                                            _PassThroughRate.cell 
                                                            _accrualDayCounter.cell 
                                                            _prepayModel.cell 
                                                            _paymentConvention.cell 
                                                            _issueDate.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MBSFixedRateBond>) l

                let source () = Helper.sourceFold "Fun.MBSFixedRateBond" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _faceAmount.source
                                               ;  _startDate.source
                                               ;  _bondTenor.source
                                               ;  _originalLength.source
                                               ;  _sinkingFrequency.source
                                               ;  _WACRate.source
                                               ;  _PassThroughRate.source
                                               ;  _accrualDayCounter.source
                                               ;  _prepayModel.source
                                               ;  _paymentConvention.source
                                               ;  _issueDate.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _faceAmount.cell
                                ;  _startDate.cell
                                ;  _bondTenor.cell
                                ;  _originalLength.cell
                                ;  _sinkingFrequency.cell
                                ;  _WACRate.cell
                                ;  _PassThroughRate.cell
                                ;  _accrualDayCounter.cell
                                ;  _prepayModel.cell
                                ;  _paymentConvention.cell
                                ;  _issueDate.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MBSFixedRateBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MBSFixedRateBond_MonthlyYield", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_MonthlyYield
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).MonthlyYield
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".MonthlyYield") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_SMM", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_SMM
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).SMM
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".SMM") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_dayCounter", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MBSFixedRateBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MBSFixedRateBond_frequency", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".Frequency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_accruedAmount", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".AccruedAmount") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_calendar", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MBSFixedRateBond> format
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
    [<ExcelFunction(Name="_MBSFixedRateBond_cashflows", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".Cashflows") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_cleanPrice", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".CleanPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_cleanPrice1", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_cleanPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
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

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".CleanPrice1") 

                                               [| _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_dirtyPrice1", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_dirtyPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
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

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).DirtyPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".DirtyPrice1") 

                                               [| _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_dirtyPrice", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).DirtyPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".DirtyPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_isExpired", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_issueDate", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".IssueDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_isTradable", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".IsTradable") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_maturityDate", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".MaturityDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_nextCashFlowDate", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".NextCashFlowDate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_nextCouponRate", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".NextCouponRate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_notional", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".Notional") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_notionals", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".Notionals") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_previousCashFlowDate", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".PreviousCashFlowDate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_previousCouponRate", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".PreviousCouponRate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_redemption", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".Redemption") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MBSFixedRateBond> format
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
    [<ExcelFunction(Name="_MBSFixedRateBond_redemptions", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".Redemptions") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_settlementDate", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".SettlementDate") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_settlementDays", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_settlementValue", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "double")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".SettlementValue") 

                                               [| _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_settlementValue1", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_settlementValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".SettlementValue1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_startDate", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".StartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_yield1", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_yield1
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
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

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).Yield1
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".Yield1") 

                                               [| _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_yield", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
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

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).Yield
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".Yield") 

                                               [| _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_CASH", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_errorEstimate", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_NPV", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_result", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_setPricingEngine", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : MBSFixedRateBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_valuationDate", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((MBSFixedRateBondModel.Cast _MBSFixedRateBond.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_MBSFixedRateBond.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_Range", Description="Create a range of MBSFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MBSFixedRateBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MBSFixedRateBond> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<MBSFixedRateBond>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<MBSFixedRateBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<MBSFixedRateBond>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
