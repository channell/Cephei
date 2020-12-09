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
module AmortizingBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AmortizingBond_AmortizationValue", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_AmortizationValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).AmortizationValue
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".AmortizationValue") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FaceValue",Description = "double")>] 
         FaceValue : obj)
        ([<ExcelArgument(Name="MarketValue",Description = "double")>] 
         MarketValue : obj)
        ([<ExcelArgument(Name="CouponRate",Description = "double")>] 
         CouponRate : obj)
        ([<ExcelArgument(Name="IssueDate",Description = "Date")>] 
         IssueDate : obj)
        ([<ExcelArgument(Name="MaturityDate",Description = "Date")>] 
         MaturityDate : obj)
        ([<ExcelArgument(Name="TradeDate",Description = "Date")>] 
         TradeDate : obj)
        ([<ExcelArgument(Name="payFrequency",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         payFrequency : obj)
        ([<ExcelArgument(Name="dCounter",Description = "DayCounter")>] 
         dCounter : obj)
        ([<ExcelArgument(Name="Method",Description = "AmortizingMethod: EffectiveInterestRate")>] 
         Method : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="gYield",Description = "double or empty")>] 
         gYield : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FaceValue = Helper.toCell<double> FaceValue "FaceValue" 
                let _MarketValue = Helper.toCell<double> MarketValue "MarketValue" 
                let _CouponRate = Helper.toCell<double> CouponRate "CouponRate" 
                let _IssueDate = Helper.toCell<Date> IssueDate "IssueDate" 
                let _MaturityDate = Helper.toCell<Date> MaturityDate "MaturityDate" 
                let _TradeDate = Helper.toCell<Date> TradeDate "TradeDate" 
                let _payFrequency = Helper.toCell<Frequency> payFrequency "payFrequency" 
                let _dCounter = Helper.toCell<DayCounter> dCounter "dCounter" 
                let _Method = Helper.toCell<AmortizingMethod> Method "Method" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _gYield = Helper.toDefault<double> gYield "gYield" 0.0
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.AmortizingBond 
                                                            _FaceValue.cell 
                                                            _MarketValue.cell 
                                                            _CouponRate.cell 
                                                            _IssueDate.cell 
                                                            _MaturityDate.cell 
                                                            _TradeDate.cell 
                                                            _payFrequency.cell 
                                                            _dCounter.cell 
                                                            _Method.cell 
                                                            _calendar.cell 
                                                            _gYield.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AmortizingBond>) l

                let source () = Helper.sourceFold "Fun.AmortizingBond" 
                                               [| _FaceValue.source
                                               ;  _MarketValue.source
                                               ;  _CouponRate.source
                                               ;  _IssueDate.source
                                               ;  _MaturityDate.source
                                               ;  _TradeDate.source
                                               ;  _payFrequency.source
                                               ;  _dCounter.source
                                               ;  _Method.source
                                               ;  _calendar.source
                                               ;  _gYield.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FaceValue.cell
                                ;  _MarketValue.cell
                                ;  _CouponRate.cell
                                ;  _IssueDate.cell
                                ;  _MaturityDate.cell
                                ;  _TradeDate.cell
                                ;  _payFrequency.cell
                                ;  _dCounter.cell
                                ;  _Method.cell
                                ;  _calendar.cell
                                ;  _gYield.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AmortizingBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AmortizingBond_isPremium", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_isPremium
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).IsPremium
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".IsPremium") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_Yield", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_Yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).Yield
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".Yield") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_accruedAmount", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".AccruedAmount") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_calendar", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_AmortizingBond.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AmortizingBond> format
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
    [<ExcelFunction(Name="_AmortizingBond_cashflows", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_AmortizingBond.source + ".Cashflows") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_cleanPrice", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".CleanPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_cleanPrice1", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_cleanPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
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

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".CleanPrice") 

                                               [| _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_dirtyPrice1", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_dirtyPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
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

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).DirtyPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".DirtyPrice") 

                                               [| _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_dirtyPrice", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).DirtyPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".DirtyPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_isExpired", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_issueDate", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".IssueDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_isTradable", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".IsTradable") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_maturityDate", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".MaturityDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_nextCashFlowDate", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".NextCashFlowDate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_nextCouponRate", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".NextCouponRate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_notional", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".Notional") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_notionals", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_AmortizingBond.source + ".Notionals") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_previousCashFlowDate", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".PreviousCashFlowDate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_previousCouponRate", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".PreviousCouponRate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_redemption", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source () = Helper.sourceFold (_AmortizingBond.source + ".Redemption") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AmortizingBond> format
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
    [<ExcelFunction(Name="_AmortizingBond_redemptions", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_AmortizingBond.source + ".Redemptions") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_settlementDate", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".SettlementDate") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_settlementDays", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_settlementValue", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "double")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".SettlementValue") 

                                               [| _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_settlementValue1", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_settlementValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".SettlementValue1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_startDate", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".StartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_yield2", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_yield2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
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

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).Yield2
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".Yield2") 

                                               [| _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_yield1", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_yield1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
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

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).Yield1
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".Yield") 

                                               [| _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_CASH", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_errorEstimate", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_NPV", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_result", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_setPricingEngine", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : AmortizingBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_valuationDate", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((AmortizingBondModel.Cast _AmortizingBond.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_AmortizingBond.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_Range", Description="Create a range of AmortizingBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AmortizingBond> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<AmortizingBond> (c)) :> ICell
                let format (i : Generic.List<ICell<AmortizingBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<AmortizingBond>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
