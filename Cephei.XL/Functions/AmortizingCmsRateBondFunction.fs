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
  amortizing CMS-rate bond
  </summary> *)
[<AutoSerializable(true)>]
module AmortizingCmsRateBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AmortizingCmsRateBond", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_create
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
        ([<ExcelArgument(Name="paymentDayCounter",Description = "Reference to paymentDayCounter")>] 
         paymentDayCounter : obj)
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
                let _index = Helper.toCell<SwapIndex> index "index" 
                let _paymentDayCounter = Helper.toCell<DayCounter> paymentDayCounter "paymentDayCounter" 
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
                let builder () = withMnemonic mnemonic (Fun.AmortizingCmsRateBond 
                                                            _settlementDays.cell 
                                                            _notionals.cell 
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
                                                            _issueDate.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AmortizingCmsRateBond>) l

                let source = Helper.sourceFold "Fun.AmortizingCmsRateBond" 
                                               [| _settlementDays.source
                                               ;  _notionals.source
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
                                               ;  _issueDate.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _notionals.cell
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
                                ;  _issueDate.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AmortizingCmsRateBond> format
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_accruedAmount", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".AccruedAmount") 
                                               [| _AmortizingCmsRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_calendar", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".Calendar") 
                                               [| _AmortizingCmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AmortizingCmsRateBond> format
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_cashflows", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".Cashflows") 
                                               [| _AmortizingCmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_cleanPrice", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".CleanPrice") 
                                               [| _AmortizingCmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_cleanPrice1", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_cleanPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
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

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".CleanPrice1") 
                                               [| _AmortizingCmsRateBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_dirtyPrice1", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_dirtyPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
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

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).DirtyPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".DirtyPrice1") 
                                               [| _AmortizingCmsRateBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_dirtyPrice", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).DirtyPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".DirtyPrice") 
                                               [| _AmortizingCmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_isExpired", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".IsExpired") 
                                               [| _AmortizingCmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_issueDate", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".IssueDate") 
                                               [| _AmortizingCmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_isTradable", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".IsTradable") 
                                               [| _AmortizingCmsRateBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_maturityDate", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".MaturityDate") 
                                               [| _AmortizingCmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_nextCashFlowDate", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".NextCashFlowDate") 
                                               [| _AmortizingCmsRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_nextCouponRate", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".NextCouponRate") 
                                               [| _AmortizingCmsRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_notional", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".Notional") 
                                               [| _AmortizingCmsRateBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_notionals", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".Notionals") 
                                               [| _AmortizingCmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_previousCashFlowDate", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".PreviousCashFlowDate") 
                                               [| _AmortizingCmsRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_previousCouponRate", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".PreviousCouponRate") 
                                               [| _AmortizingCmsRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_redemption", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".Redemption") 
                                               [| _AmortizingCmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AmortizingCmsRateBond> format
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_redemptions", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".Redemptions") 
                                               [| _AmortizingCmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_settlementDate", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let _date = Helper.toCell<Date> date "date" 
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".SettlementDate") 
                                               [| _AmortizingCmsRateBond.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_settlementDays", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".SettlementDays") 
                                               [| _AmortizingCmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_settlementValue", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "Reference to cleanPrice")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".SettlementValue") 
                                               [| _AmortizingCmsRateBond.source
                                               ;  _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_settlementValue1", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_settlementValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".SettlementValue1") 
                                               [| _AmortizingCmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_startDate", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".StartDate") 
                                               [| _AmortizingCmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_yield1", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_yield1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
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

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).Yield1
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".Yield") 
                                               [| _AmortizingCmsRateBond.source
                                               ;  _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_yield", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
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

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).Yield
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".Yield") 
                                               [| _AmortizingCmsRateBond.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_CASH", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".CASH") 
                                               [| _AmortizingCmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_errorEstimate", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".ErrorEstimate") 
                                               [| _AmortizingCmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_NPV", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".NPV") 
                                               [| _AmortizingCmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_result", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".Result") 
                                               [| _AmortizingCmsRateBond.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_setPricingEngine", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : AmortizingCmsRateBond) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".SetPricingEngine") 
                                               [| _AmortizingCmsRateBond.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_valuationDate", Description="Create a AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingCmsRateBond",Description = "Reference to AmortizingCmsRateBond")>] 
         amortizingcmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingCmsRateBond = Helper.toCell<AmortizingCmsRateBond> amortizingcmsratebond "AmortizingCmsRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingCmsRateBondModel.Cast _AmortizingCmsRateBond.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingCmsRateBond.source + ".ValuationDate") 
                                               [| _AmortizingCmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingCmsRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingCmsRateBond_Range", Description="Create a range of AmortizingCmsRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingCmsRateBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the AmortizingCmsRateBond")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AmortizingCmsRateBond> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AmortizingCmsRateBond>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<AmortizingCmsRateBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<AmortizingCmsRateBond>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
