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
module ConvertibleFloatingRateBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_create
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
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "Reference to fixingDays")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="spreads",Description = "Reference to spreads")>] 
         spreads : obj)
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
                let _index = Helper.toCell<IborIndex> index "index" 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let _spreads = Helper.toCell<Generic.List<double>> spreads "spreads" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _redemption = Helper.toDefault<double> redemption "redemption" 100.0
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.ConvertibleFloatingRateBond 
                                                            _exercise.cell 
                                                            _conversionRatio.cell 
                                                            _dividends.cell 
                                                            _callability.cell 
                                                            _creditSpread.cell 
                                                            _issueDate.cell 
                                                            _settlementDays.cell 
                                                            _index.cell 
                                                            _fixingDays.cell 
                                                            _spreads.cell 
                                                            _dayCounter.cell 
                                                            _schedule.cell 
                                                            _redemption.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConvertibleFloatingRateBond>) l

                let source = Helper.sourceFold "Fun.ConvertibleFloatingRateBond" 
                                               [| _exercise.source
                                               ;  _conversionRatio.source
                                               ;  _dividends.source
                                               ;  _callability.source
                                               ;  _creditSpread.source
                                               ;  _issueDate.source
                                               ;  _settlementDays.source
                                               ;  _index.source
                                               ;  _fixingDays.source
                                               ;  _spreads.source
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
                                ;  _index.cell
                                ;  _fixingDays.cell
                                ;  _spreads.cell
                                ;  _dayCounter.cell
                                ;  _schedule.cell
                                ;  _redemption.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvertibleFloatingRateBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_callability", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_callability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).Callability
                                                       ) :> ICell
                let format (o : CallabilitySchedule) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".Callability") 
                                               [| _ConvertibleFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_conversionRatio", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_conversionRatio
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).ConversionRatio
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".ConversionRatio") 
                                               [| _ConvertibleFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_creditSpread", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_creditSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).CreditSpread
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".CreditSpread") 
                                               [| _ConvertibleFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvertibleFloatingRateBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_dividends", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_dividends
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).Dividends
                                                       ) :> ICell
                let format (o : DividendSchedule) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".Dividends") 
                                               [| _ConvertibleFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_accruedAmount", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".AccruedAmount") 
                                               [| _ConvertibleFloatingRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_calendar", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".Calendar") 
                                               [| _ConvertibleFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvertibleFloatingRateBond> format
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_cashflows", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".Cashflows") 
                                               [| _ConvertibleFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_cleanPrice", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".CleanPrice") 
                                               [| _ConvertibleFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_cleanPrice1", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_cleanPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
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

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".CleanPrice1") 
                                               [| _ConvertibleFloatingRateBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_dirtyPrice1", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_dirtyPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
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

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).DirtyPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".DirtyPrice1") 
                                               [| _ConvertibleFloatingRateBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_dirtyPrice", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).DirtyPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".DirtyPrice") 
                                               [| _ConvertibleFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_isExpired", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".IsExpired") 
                                               [| _ConvertibleFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_issueDate", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".IssueDate") 
                                               [| _ConvertibleFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_isTradable", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".IsTradable") 
                                               [| _ConvertibleFloatingRateBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_maturityDate", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".MaturityDate") 
                                               [| _ConvertibleFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_nextCashFlowDate", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".NextCashFlowDate") 
                                               [| _ConvertibleFloatingRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_nextCouponRate", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".NextCouponRate") 
                                               [| _ConvertibleFloatingRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_notional", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".Notional") 
                                               [| _ConvertibleFloatingRateBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_notionals", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".Notionals") 
                                               [| _ConvertibleFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_previousCashFlowDate", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".PreviousCashFlowDate") 
                                               [| _ConvertibleFloatingRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_previousCouponRate", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".PreviousCouponRate") 
                                               [| _ConvertibleFloatingRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_redemption", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".Redemption") 
                                               [| _ConvertibleFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvertibleFloatingRateBond> format
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_redemptions", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".Redemptions") 
                                               [| _ConvertibleFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_settlementDate", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _date = Helper.toCell<Date> date "date" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".SettlementDate") 
                                               [| _ConvertibleFloatingRateBond.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_settlementDays", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".SettlementDays") 
                                               [| _ConvertibleFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_settlementValue", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "Reference to cleanPrice")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".SettlementValue") 
                                               [| _ConvertibleFloatingRateBond.source
                                               ;  _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_settlementValue1", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_settlementValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".SettlementValue1") 
                                               [| _ConvertibleFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_startDate", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".StartDate") 
                                               [| _ConvertibleFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_yield1", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_yield1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
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

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).Yield1
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".Yield1") 
                                               [| _ConvertibleFloatingRateBond.source
                                               ;  _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_yield", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
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

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).Yield
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".Yield") 
                                               [| _ConvertibleFloatingRateBond.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_CASH", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".CASH") 
                                               [| _ConvertibleFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_errorEstimate", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".ErrorEstimate") 
                                               [| _ConvertibleFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_NPV", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".NPV") 
                                               [| _ConvertibleFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_result", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".Result") 
                                               [| _ConvertibleFloatingRateBond.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_setPricingEngine", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : ConvertibleFloatingRateBond) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".SetPricingEngine") 
                                               [| _ConvertibleFloatingRateBond.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_valuationDate", Description="Create a ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFloatingRateBond",Description = "Reference to ConvertibleFloatingRateBond")>] 
         convertiblefloatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFloatingRateBond = Helper.toCell<ConvertibleFloatingRateBond> convertiblefloatingratebond "ConvertibleFloatingRateBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFloatingRateBond.cell :?> ConvertibleFloatingRateBondModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConvertibleFloatingRateBond.source + ".ValuationDate") 
                                               [| _ConvertibleFloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFloatingRateBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFloatingRateBond_Range", Description="Create a range of ConvertibleFloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFloatingRateBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ConvertibleFloatingRateBond")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ConvertibleFloatingRateBond> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ConvertibleFloatingRateBond>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ConvertibleFloatingRateBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ConvertibleFloatingRateBond>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
