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
  amortizing floating-rate bond (possibly capped and/or floored)
  </summary> *)
[<AutoSerializable(true)>]
module AmortizingFloatingRateBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AmortizingFloatingRateBond", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="notionals",Description = "Reference to notionals")>] 
         notionals : obj)
        ([<ExcelArgument(Name="schedule",Description = "Reference to schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        ([<ExcelArgument(Name="accrualDayCounter",Description = "Reference to accrualDayCounter")>] 
         accrualDayCounter : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "Reference to paymentConvention")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "Reference to fixingDays")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="gearings",Description = "Reference to gearings")>] 
         gearings : obj)
        ([<ExcelArgument(Name="spreads",Description = "Reference to spreads")>] 
         spreads : obj)
        ([<ExcelArgument(Name="caps",Description = "Reference to caps")>] 
         caps : obj)
        ([<ExcelArgument(Name="floors",Description = "Reference to floors")>] 
         floors : obj)
        ([<ExcelArgument(Name="inArrears",Description = "Reference to inArrears")>] 
         inArrears : obj)
        ([<ExcelArgument(Name="issueDate",Description = "Reference to issueDate")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _notionals = Helper.toCell<Generic.List<double>> notionals "notionals" 
                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _index = Helper.toCell<IborIndex> index "index" 
                let _accrualDayCounter = Helper.toCell<DayCounter> accrualDayCounter "accrualDayCounter" 
                let _paymentConvention = Helper.toDefault<BusinessDayConvention> paymentConvention "paymentConvention" BusinessDayConvention.Following
                let _fixingDays = Helper.toDefault<int> fixingDays "fixingDays" 0
                let _gearings = Helper.toDefault<Generic.List<double>> gearings "gearings" null
                let _spreads = Helper.toDefault<Generic.List<double>> spreads "spreads" null
                let _caps = Helper.toDefault<Generic.List<Nullable<double>>> caps "caps" null
                let _floors = Helper.toDefault<Generic.List<Nullable<double>>> floors "floors" null
                let _inArrears = Helper.toDefault<bool> inArrears "inArrears" false
                let _issueDate = Helper.toDefault<Date> issueDate "issueDate" null
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.AmortizingFloatingRateBond 
                                                            _settlementDays.cell 
                                                            _notionals.cell 
                                                            _schedule.cell 
                                                            _index.cell 
                                                            _accrualDayCounter.cell 
                                                            _paymentConvention.cell 
                                                            _fixingDays.cell 
                                                            _gearings.cell 
                                                            _spreads.cell 
                                                            _caps.cell 
                                                            _floors.cell 
                                                            _inArrears.cell 
                                                            _issueDate.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AmortizingFloatingRateBond>) l

                let source = Helper.sourceFold "Fun.AmortizingFloatingRateBond" 
                                               [| _settlementDays.source
                                               ;  _notionals.source
                                               ;  _schedule.source
                                               ;  _index.source
                                               ;  _accrualDayCounter.source
                                               ;  _paymentConvention.source
                                               ;  _fixingDays.source
                                               ;  _gearings.source
                                               ;  _spreads.source
                                               ;  _caps.source
                                               ;  _floors.source
                                               ;  _inArrears.source
                                               ;  _issueDate.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _notionals.cell
                                ;  _schedule.cell
                                ;  _index.cell
                                ;  _accrualDayCounter.cell
                                ;  _paymentConvention.cell
                                ;  _fixingDays.cell
                                ;  _gearings.cell
                                ;  _spreads.cell
                                ;  _caps.cell
                                ;  _floors.cell
                                ;  _inArrears.cell
                                ;  _issueDate.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AmortizingFloatingRateBond> format
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
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_accruedAmount", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".AccruedAmount") 
                                               [| _AmortizingFloatingRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
                                ;  _settlement.cell
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
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_calendar", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".Calendar") 
                                               [| _AmortizingFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AmortizingFloatingRateBond> format
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
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_cashflows", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".Cashflows") 
                                               [| _AmortizingFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_cleanPrice", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".CleanPrice") 
                                               [| _AmortizingFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
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
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_cleanPrice1", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_cleanPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        ([<ExcelArgument(Name="Yield",Description = "Reference to Yield")>] 
         Yield : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".CleanPrice1") 
                                               [| _AmortizingFloatingRateBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
                                ;  _Yield.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _settlement.cell
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
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_dirtyPrice1", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_dirtyPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        ([<ExcelArgument(Name="Yield",Description = "Reference to Yield")>] 
         Yield : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).DirtyPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".DirtyPrice") 
                                               [| _AmortizingFloatingRateBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
                                ;  _Yield.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _settlement.cell
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
        ! The default bond settlement is used for calculation.  \warning the theoretical price calculated from a flat term structure might differ slightly from the price calculated from the corresponding yield by means of the other overload of this function. If the price from a constant yield is desired, it is advisable to use such other overload.
    *)
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_dirtyPrice", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).DirtyPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".DirtyPrice") 
                                               [| _AmortizingFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_isExpired", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".IsExpired") 
                                               [| _AmortizingFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_issueDate", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".IssueDate") 
                                               [| _AmortizingFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_isTradable", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".IsTradable") 
                                               [| _AmortizingFloatingRateBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_maturityDate", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".MaturityDate") 
                                               [| _AmortizingFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_nextCashFlowDate", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".NextCashFlowDate") 
                                               [| _AmortizingFloatingRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
                                ;  _settlement.cell
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
        ! Expected next coupon: depending on (the bond and) the given date the coupon can be historic, deterministic or expected in a stochastic sense. When the bond settlement date is used the coupon is the already-fixed not-yet-paid one.  The current bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_nextCouponRate", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".NextCouponRate") 
                                               [| _AmortizingFloatingRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
                                ;  _settlement.cell
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
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_notional", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".Notional") 
                                               [| _AmortizingFloatingRateBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_notionals", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".Notionals") 
                                               [| _AmortizingFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_previousCashFlowDate", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".PreviousCashFlowDate") 
                                               [| _AmortizingFloatingRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
                                ;  _settlement.cell
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
        ! Expected previous coupon: depending on (the bond and) the given date the coupon can be historic, deterministic or expected in a stochastic sense. When the bond settlement date is used the coupon is the last paid one.  The current bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_previousCouponRate", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".PreviousCouponRate") 
                                               [| _AmortizingFloatingRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
                                ;  _settlement.cell
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
        returns the redemption, if only one is defined
    *)
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_redemption", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".Redemption") 
                                               [| _AmortizingFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AmortizingFloatingRateBond> format
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
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_redemptions", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".Redemptions") 
                                               [| _AmortizingFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_settlementDate", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let _date = Helper.toCell<Date> date "date" 
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".SettlementDate") 
                                               [| _AmortizingFloatingRateBond.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
                                ;  _date.cell
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
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_settlementDays", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".SettlementDays") 
                                               [| _AmortizingFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_settlementValue", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "Reference to cleanPrice")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".SettlementValue") 
                                               [| _AmortizingFloatingRateBond.source
                                               ;  _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
                                ;  _cleanPrice.cell
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
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_settlementValue1", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_settlementValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".SettlementValue1") 
                                               [| _AmortizingFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_startDate", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".StartDate") 
                                               [| _AmortizingFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
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
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_yield1", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_yield1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "Reference to cleanPrice")>] 
         cleanPrice : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).Yield1
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".Yield1") 
                                               [| _AmortizingFloatingRateBond.source
                                               ;  _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
                                ;  _cleanPrice.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _settlement.cell
                                ;  _accuracy.cell
                                ;  _maxEvaluations.cell
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
        ! The default bond settlement and theoretical price are used for calculation.
    *)
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_yield", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).Yield
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".Yield") 
                                               [| _AmortizingFloatingRateBond.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _accuracy.cell
                                ;  _maxEvaluations.cell
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
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_CASH", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".CASH") 
                                               [| _AmortizingFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_errorEstimate", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".ErrorEstimate") 
                                               [| _AmortizingFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_NPV", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".NPV") 
                                               [| _AmortizingFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
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
        returns any additional result returned by the pricing engine.
    *)
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_result", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".Result") 
                                               [| _AmortizingFloatingRateBond.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
                                ;  _tag.cell
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
        ! calling this method will have no effects in case the performCalculation method was overridden in a derived class.
    *)
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_setPricingEngine", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : AmortizingFloatingRateBond) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".SetPricingEngine") 
                                               [| _AmortizingFloatingRateBond.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
                                ;  _e.cell
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
        ! returns the date the net present value refers to.
    *)
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_valuationDate", Description="Create a AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFloatingRateBond",Description = "Reference to AmortizingFloatingRateBond")>] 
         amortizingfloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFloatingRateBond = Helper.toCell<AmortizingFloatingRateBond> amortizingfloatingratebond "AmortizingFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFloatingRateBondModel.Cast _AmortizingFloatingRateBond.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingFloatingRateBond.source + ".ValuationDate") 
                                               [| _AmortizingFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFloatingRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFloatingRateBond_Range", Description="Create a range of AmortizingFloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFloatingRateBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the AmortizingFloatingRateBond")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AmortizingFloatingRateBond> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AmortizingFloatingRateBond>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<AmortizingFloatingRateBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<AmortizingFloatingRateBond>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
