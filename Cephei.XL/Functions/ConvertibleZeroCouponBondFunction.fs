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
  Most methods inherited from Bond (such as yield or the yield-based dirtyPrice and cleanPrice) refer to the underlying plain-vanilla bond and do not take convertibility and callability into account.
  </summary> *)
[<AutoSerializable(true)>]
module ConvertibleZeroCouponBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="exercise",Description = "Reference to exercise")>] 
         exercise : obj)
        ([<ExcelArgument(Name="conversionRatio",Description = "Reference to conversionRatio")>] 
         conversionRatio : obj)
        ([<ExcelArgument(Name="dividends",Description = "Reference to dividends")>] 
         dividends : obj)
        ([<ExcelArgument(Name="callability",Description = "Reference to callability")>] 
         callability : obj)
        ([<ExcelArgument(Name="creditSpread",Description = "Reference to creditSpread")>] 
         creditSpread : obj)
        ([<ExcelArgument(Name="issueDate",Description = "Reference to issueDate")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="schedule",Description = "Reference to schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="redemption",Description = "Reference to redemption")>] 
         redemption : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _exercise = Helper.toCell<Exercise> exercise "exercise" 
                let _conversionRatio = Helper.toCell<double> conversionRatio "conversionRatio" 
                let _dividends = Helper.toCell<DividendSchedule> dividends "dividends" 
                let _callability = Helper.toCell<CallabilitySchedule> callability "callability" 
                let _creditSpread = Helper.toHandle<Quote> creditSpread "creditSpread" 
                let _issueDate = Helper.toCell<Date> issueDate "issueDate" 
                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _redemption = Helper.toDefault<double> redemption "redemption" 100.0
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.ConvertibleZeroCouponBond 
                                                            _exercise.cell 
                                                            _conversionRatio.cell 
                                                            _dividends.cell 
                                                            _callability.cell 
                                                            _creditSpread.cell 
                                                            _issueDate.cell 
                                                            _settlementDays.cell 
                                                            _dayCounter.cell 
                                                            _schedule.cell 
                                                            _redemption.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConvertibleZeroCouponBond>) l

                let source = Helper.sourceFold "Fun.ConvertibleZeroCouponBond" 
                                               [| _exercise.source
                                               ;  _conversionRatio.source
                                               ;  _dividends.source
                                               ;  _callability.source
                                               ;  _creditSpread.source
                                               ;  _issueDate.source
                                               ;  _settlementDays.source
                                               ;  _dayCounter.source
                                               ;  _schedule.source
                                               ;  _redemption.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _exercise.cell
                                ;  _conversionRatio.cell
                                ;  _dividends.cell
                                ;  _callability.cell
                                ;  _creditSpread.cell
                                ;  _issueDate.cell
                                ;  _settlementDays.cell
                                ;  _dayCounter.cell
                                ;  _schedule.cell
                                ;  _redemption.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvertibleZeroCouponBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_callability", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_callability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).Callability
                                                       ) :> ICell
                let format (o : CallabilitySchedule) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".Callability") 
                                               [| _ConvertibleZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_conversionRatio", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_conversionRatio
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).ConversionRatio
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".ConversionRatio") 
                                               [| _ConvertibleZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_creditSpread", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_creditSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).CreditSpread
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".CreditSpread") 
                                               [| _ConvertibleZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvertibleZeroCouponBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_dividends", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_dividends
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).Dividends
                                                       ) :> ICell
                let format (o : DividendSchedule) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".Dividends") 
                                               [| _ConvertibleZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_accruedAmount", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".AccruedAmount") 
                                               [| _ConvertibleZeroCouponBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_calendar", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".Calendar") 
                                               [| _ConvertibleZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvertibleZeroCouponBond> format
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_cashflows", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".Cashflows") 
                                               [| _ConvertibleZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_cleanPrice", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".CleanPrice") 
                                               [| _ConvertibleZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_cleanPrice1", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_cleanPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
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

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".CleanPrice1") 
                                               [| _ConvertibleZeroCouponBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_dirtyPrice1", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_dirtyPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
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

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).DirtyPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".DirtyPrice1") 
                                               [| _ConvertibleZeroCouponBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_dirtyPrice", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).DirtyPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".DirtyPrice") 
                                               [| _ConvertibleZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_isExpired", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".IsExpired") 
                                               [| _ConvertibleZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_issueDate", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".IssueDate") 
                                               [| _ConvertibleZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_isTradable", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".IsTradable") 
                                               [| _ConvertibleZeroCouponBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_maturityDate", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".MaturityDate") 
                                               [| _ConvertibleZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_nextCashFlowDate", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".NextCashFlowDate") 
                                               [| _ConvertibleZeroCouponBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_nextCouponRate", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".NextCouponRate") 
                                               [| _ConvertibleZeroCouponBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_notional", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".Notional") 
                                               [| _ConvertibleZeroCouponBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_notionals", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".Notionals") 
                                               [| _ConvertibleZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_previousCashFlowDate", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".PreviousCashFlowDate") 
                                               [| _ConvertibleZeroCouponBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_previousCouponRate", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".PreviousCouponRate") 
                                               [| _ConvertibleZeroCouponBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_redemption", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".Redemption") 
                                               [| _ConvertibleZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvertibleZeroCouponBond> format
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_redemptions", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".Redemptions") 
                                               [| _ConvertibleZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_settlementDate", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _date = Helper.toCell<Date> date "date" 
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".SettlementDate") 
                                               [| _ConvertibleZeroCouponBond.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_settlementDays", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".SettlementDays") 
                                               [| _ConvertibleZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_settlementValue", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "Reference to cleanPrice")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".SettlementValue") 
                                               [| _ConvertibleZeroCouponBond.source
                                               ;  _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_settlementValue1", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_settlementValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".SettlementValue1") 
                                               [| _ConvertibleZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_startDate", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".StartDate") 
                                               [| _ConvertibleZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_yield1", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_yield1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
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

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).Yield1
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".Yield1") 
                                               [| _ConvertibleZeroCouponBond.source
                                               ;  _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_yield", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
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

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).Yield
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".Yield") 
                                               [| _ConvertibleZeroCouponBond.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_CASH", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".CASH") 
                                               [| _ConvertibleZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_errorEstimate", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".ErrorEstimate") 
                                               [| _ConvertibleZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_NPV", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".NPV") 
                                               [| _ConvertibleZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_result", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".Result") 
                                               [| _ConvertibleZeroCouponBond.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_setPricingEngine", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : ConvertibleZeroCouponBond) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".SetPricingEngine") 
                                               [| _ConvertibleZeroCouponBond.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_valuationDate", Description="Create a ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleZeroCouponBond",Description = "Reference to ConvertibleZeroCouponBond")>] 
         convertiblezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleZeroCouponBond = Helper.toCell<ConvertibleZeroCouponBond> convertiblezerocouponbond "ConvertibleZeroCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleZeroCouponBond.cell :?> ConvertibleZeroCouponBondModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConvertibleZeroCouponBond.source + ".ValuationDate") 
                                               [| _ConvertibleZeroCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleZeroCouponBond_Range", Description="Create a range of ConvertibleZeroCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleZeroCouponBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ConvertibleZeroCouponBond")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ConvertibleZeroCouponBond> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ConvertibleZeroCouponBond>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ConvertibleZeroCouponBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ConvertibleZeroCouponBond>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
