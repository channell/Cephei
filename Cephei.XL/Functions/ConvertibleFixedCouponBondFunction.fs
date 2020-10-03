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
module ConvertibleFixedCouponBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_create
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
        ([<ExcelArgument(Name="coupons",Description = "Reference to coupons")>] 
         coupons : obj)
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
                let _coupons = Helper.toCell<Generic.List<double>> coupons "coupons" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _redemption = Helper.toDefault<double> redemption "redemption" 100.0
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.ConvertibleFixedCouponBond 
                                                            _exercise.cell 
                                                            _conversionRatio.cell 
                                                            _dividends.cell 
                                                            _callability.cell 
                                                            _creditSpread.cell 
                                                            _issueDate.cell 
                                                            _settlementDays.cell 
                                                            _coupons.cell 
                                                            _dayCounter.cell 
                                                            _schedule.cell 
                                                            _redemption.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConvertibleFixedCouponBond>) l

                let source = Helper.sourceFold "Fun.ConvertibleFixedCouponBond" 
                                               [| _exercise.source
                                               ;  _conversionRatio.source
                                               ;  _dividends.source
                                               ;  _callability.source
                                               ;  _creditSpread.source
                                               ;  _issueDate.source
                                               ;  _settlementDays.source
                                               ;  _coupons.source
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
                                ;  _coupons.cell
                                ;  _dayCounter.cell
                                ;  _schedule.cell
                                ;  _redemption.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvertibleFixedCouponBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_callability", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_callability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).Callability
                                                       ) :> ICell
                let format (o : CallabilitySchedule) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".Callability") 
                                               [| _ConvertibleFixedCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_conversionRatio", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_conversionRatio
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).ConversionRatio
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".ConversionRatio") 
                                               [| _ConvertibleFixedCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_creditSpread", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_creditSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).CreditSpread
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".CreditSpread") 
                                               [| _ConvertibleFixedCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvertibleFixedCouponBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_dividends", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_dividends
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).Dividends
                                                       ) :> ICell
                let format (o : DividendSchedule) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".Dividends") 
                                               [| _ConvertibleFixedCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_accruedAmount", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".AccruedAmount") 
                                               [| _ConvertibleFixedCouponBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_calendar", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".Calendar") 
                                               [| _ConvertibleFixedCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvertibleFixedCouponBond> format
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_cashflows", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".Cashflows") 
                                               [| _ConvertibleFixedCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_cleanPrice", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".CleanPrice") 
                                               [| _ConvertibleFixedCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_cleanPrice1", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_cleanPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
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

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".CleanPrice1") 
                                               [| _ConvertibleFixedCouponBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_dirtyPrice1", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_dirtyPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
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

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).DirtyPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".DirtyPrice1") 
                                               [| _ConvertibleFixedCouponBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_dirtyPrice", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).DirtyPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".DirtyPrice") 
                                               [| _ConvertibleFixedCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_isExpired", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".IsExpired") 
                                               [| _ConvertibleFixedCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_issueDate", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".IssueDate") 
                                               [| _ConvertibleFixedCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_isTradable", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".IsTradable") 
                                               [| _ConvertibleFixedCouponBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_maturityDate", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".MaturityDate") 
                                               [| _ConvertibleFixedCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_nextCashFlowDate", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".NextCashFlowDate") 
                                               [| _ConvertibleFixedCouponBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_nextCouponRate", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".NextCouponRate") 
                                               [| _ConvertibleFixedCouponBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_notional", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".Notional") 
                                               [| _ConvertibleFixedCouponBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_notionals", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".Notionals") 
                                               [| _ConvertibleFixedCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_previousCashFlowDate", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".PreviousCashFlowDate") 
                                               [| _ConvertibleFixedCouponBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_previousCouponRate", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".PreviousCouponRate") 
                                               [| _ConvertibleFixedCouponBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_redemption", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".Redemption") 
                                               [| _ConvertibleFixedCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvertibleFixedCouponBond> format
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_redemptions", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".Redemptions") 
                                               [| _ConvertibleFixedCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_settlementDate", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let _date = Helper.toCell<Date> date "date" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".SettlementDate") 
                                               [| _ConvertibleFixedCouponBond.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_settlementDays", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".SettlementDays") 
                                               [| _ConvertibleFixedCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_settlementValue", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "Reference to cleanPrice")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".SettlementValue") 
                                               [| _ConvertibleFixedCouponBond.source
                                               ;  _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_settlementValue1", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_settlementValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".SettlementValue1") 
                                               [| _ConvertibleFixedCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_startDate", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".StartDate") 
                                               [| _ConvertibleFixedCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_yield1", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_yield1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
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

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).Yield1
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".Yield1") 
                                               [| _ConvertibleFixedCouponBond.source
                                               ;  _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_yield", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
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

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).Yield
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".Yield") 
                                               [| _ConvertibleFixedCouponBond.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_CASH", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".CASH") 
                                               [| _ConvertibleFixedCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_errorEstimate", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".ErrorEstimate") 
                                               [| _ConvertibleFixedCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_NPV", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".NPV") 
                                               [| _ConvertibleFixedCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_result", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".Result") 
                                               [| _ConvertibleFixedCouponBond.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_setPricingEngine", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : ConvertibleFixedCouponBond) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".SetPricingEngine") 
                                               [| _ConvertibleFixedCouponBond.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_valuationDate", Description="Create a ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleFixedCouponBond",Description = "Reference to ConvertibleFixedCouponBond")>] 
         convertiblefixedcouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleFixedCouponBond = Helper.toCell<ConvertibleFixedCouponBond> convertiblefixedcouponbond "ConvertibleFixedCouponBond"  
                let builder () = withMnemonic mnemonic ((_ConvertibleFixedCouponBond.cell :?> ConvertibleFixedCouponBondModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConvertibleFixedCouponBond.source + ".ValuationDate") 
                                               [| _ConvertibleFixedCouponBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleFixedCouponBond.cell
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
    [<ExcelFunction(Name="_ConvertibleFixedCouponBond_Range", Description="Create a range of ConvertibleFixedCouponBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleFixedCouponBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ConvertibleFixedCouponBond")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ConvertibleFixedCouponBond> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ConvertibleFixedCouponBond>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ConvertibleFixedCouponBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ConvertibleFixedCouponBond>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
