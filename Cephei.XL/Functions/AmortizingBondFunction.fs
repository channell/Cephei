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
    [<ExcelFunction(Name="_AmortizingBond_AmortizationValue", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_AmortizationValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).AmortizationValue
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".AmortizationValue") 
                                               [| _AmortizingBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FaceValue",Description = "Reference to FaceValue")>] 
         FaceValue : obj)
        ([<ExcelArgument(Name="MarketValue",Description = "Reference to MarketValue")>] 
         MarketValue : obj)
        ([<ExcelArgument(Name="CouponRate",Description = "Reference to CouponRate")>] 
         CouponRate : obj)
        ([<ExcelArgument(Name="IssueDate",Description = "Reference to IssueDate")>] 
         IssueDate : obj)
        ([<ExcelArgument(Name="MaturityDate",Description = "Reference to MaturityDate")>] 
         MaturityDate : obj)
        ([<ExcelArgument(Name="TradeDate",Description = "Reference to TradeDate")>] 
         TradeDate : obj)
        ([<ExcelArgument(Name="payFrequency",Description = "Reference to payFrequency")>] 
         payFrequency : obj)
        ([<ExcelArgument(Name="dCounter",Description = "Reference to dCounter")>] 
         dCounter : obj)
        ([<ExcelArgument(Name="Method",Description = "Reference to Method")>] 
         Method : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="gYield",Description = "Reference to gYield")>] 
         gYield : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FaceValue = Helper.toCell<double> FaceValue "FaceValue" true
                let _MarketValue = Helper.toCell<double> MarketValue "MarketValue" true
                let _CouponRate = Helper.toCell<double> CouponRate "CouponRate" true
                let _IssueDate = Helper.toCell<Date> IssueDate "IssueDate" true
                let _MaturityDate = Helper.toCell<Date> MaturityDate "MaturityDate" true
                let _TradeDate = Helper.toCell<Date> TradeDate "TradeDate" true
                let _payFrequency = Helper.toCell<Frequency> payFrequency "payFrequency" true
                let _dCounter = Helper.toCell<DayCounter> dCounter "dCounter" true
                let _Method = Helper.toCell<AmortizingMethod> Method "Method" true
                let _calendar = Helper.toCell<Calendar> calendar "calendar" true
                let _gYield = Helper.toCell<double> gYield "gYield" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.AmortizingBond 
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

                let source = Helper.sourceFold "Fun.AmortizingBond" 
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
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AmortizingBond_isPremium", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_isPremium
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).IsPremium
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".IsPremium") 
                                               [| _AmortizingBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_Yield", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_Yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).Yield
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".Yield") 
                                               [| _AmortizingBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_accruedAmount", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".AccruedAmount") 
                                               [| _AmortizingBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_calendar", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_AmortizingBond.source + ".Calendar") 
                                               [| _AmortizingBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
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
    [<ExcelFunction(Name="_AmortizingBond_cashflows", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_AmortizingBond.source + ".Cashflows") 
                                               [| _AmortizingBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_cleanPrice", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".CleanPrice") 
                                               [| _AmortizingBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_cleanPrice1", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_cleanPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
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

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let _Yield = Helper.toCell<double> Yield "Yield" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".CleanPrice") 
                                               [| _AmortizingBond.source
                                               ;  _Yield.source
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
    [<ExcelFunction(Name="_AmortizingBond_dirtyPrice1", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_dirtyPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
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

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let _Yield = Helper.toCell<double> Yield "Yield" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).DirtyPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".DirtyPrice") 
                                               [| _AmortizingBond.source
                                               ;  _Yield.source
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
    [<ExcelFunction(Name="_AmortizingBond_dirtyPrice", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).DirtyPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".DirtyPrice") 
                                               [| _AmortizingBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_isExpired", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".IsExpired") 
                                               [| _AmortizingBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_issueDate", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".IssueDate") 
                                               [| _AmortizingBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_isTradable", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".IsTradable") 
                                               [| _AmortizingBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_maturityDate", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".MaturityDate") 
                                               [| _AmortizingBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_nextCashFlowDate", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".NextCashFlowDate") 
                                               [| _AmortizingBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_nextCouponRate", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".NextCouponRate") 
                                               [| _AmortizingBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_notional", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".Notional") 
                                               [| _AmortizingBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_notionals", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_AmortizingBond.source + ".Notionals") 
                                               [| _AmortizingBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_previousCashFlowDate", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".PreviousCashFlowDate") 
                                               [| _AmortizingBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_previousCouponRate", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".PreviousCouponRate") 
                                               [| _AmortizingBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_redemption", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source = Helper.sourceFold (_AmortizingBond.source + ".Redemption") 
                                               [| _AmortizingBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
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
    [<ExcelFunction(Name="_AmortizingBond_redemptions", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_AmortizingBond.source + ".Redemptions") 
                                               [| _AmortizingBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_settlementDate", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let _date = Helper.toCell<Date> date "date" true
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".SettlementDate") 
                                               [| _AmortizingBond.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_settlementDays", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".SettlementDays") 
                                               [| _AmortizingBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_settlementValue", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "Reference to cleanPrice")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" true
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".SettlementValue") 
                                               [| _AmortizingBond.source
                                               ;  _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_settlementValue1", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_settlementValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".SettlementValue1") 
                                               [| _AmortizingBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_startDate", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".StartDate") 
                                               [| _AmortizingBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_yield2", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_yield2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
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

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).Yield2
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".Yield2") 
                                               [| _AmortizingBond.source
                                               ;  _cleanPrice.source
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
    [<ExcelFunction(Name="_AmortizingBond_yield1", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_yield1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
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

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).Yield1
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".Yield") 
                                               [| _AmortizingBond.source
                                               ;  _dc.source
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
    [<ExcelFunction(Name="_AmortizingBond_CASH", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".CASH") 
                                               [| _AmortizingBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_errorEstimate", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".ErrorEstimate") 
                                               [| _AmortizingBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_NPV", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".NPV") 
                                               [| _AmortizingBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_result", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let _tag = Helper.toCell<string> tag "tag" true
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".Result") 
                                               [| _AmortizingBond.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_setPricingEngine", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let _e = Helper.toCell<IPricingEngine> e "e" true
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : AmortizingBond) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".SetPricingEngine") 
                                               [| _AmortizingBond.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_valuationDate", Description="Create a AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingBond",Description = "Reference to AmortizingBond")>] 
         amortizingbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingBond = Helper.toCell<AmortizingBond> amortizingbond "AmortizingBond" true 
                let builder () = withMnemonic mnemonic ((_AmortizingBond.cell :?> AmortizingBondModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingBond.source + ".ValuationDate") 
                                               [| _AmortizingBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingBond.cell
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
    [<ExcelFunction(Name="_AmortizingBond_Range", Description="Create a range of AmortizingBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmortizingBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the AmortizingBond")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AmortizingBond> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AmortizingBond>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<AmortizingBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<AmortizingBond>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
