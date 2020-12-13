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
  instruments  calculations are tested by checking results against cached values.
  </summary> *)
[<AutoSerializable(true)>]
module ZeroCouponBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ZeroCouponBond", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "double")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="maturityDate",Description = "Date")>] 
         maturityDate : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="redemption",Description = "double")>] 
         redemption : obj)
        ([<ExcelArgument(Name="issueDate",Description = "Date")>] 
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
                let _maturityDate = Helper.toCell<Date> maturityDate "maturityDate" 
                let _paymentConvention = Helper.toCell<BusinessDayConvention> paymentConvention "paymentConvention" 
                let _redemption = Helper.toCell<double> redemption "redemption" 
                let _issueDate = Helper.toCell<Date> issueDate "issueDate" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.ZeroCouponBond 
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _faceAmount.cell 
                                                            _maturityDate.cell 
                                                            _paymentConvention.cell 
                                                            _redemption.cell 
                                                            _issueDate.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ZeroCouponBond>) l

                let source () = Helper.sourceFold "Fun.ZeroCouponBond" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _faceAmount.source
                                               ;  _maturityDate.source
                                               ;  _paymentConvention.source
                                               ;  _redemption.source
                                               ;  _issueDate.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _faceAmount.cell
                                ;  _maturityDate.cell
                                ;  _paymentConvention.cell
                                ;  _redemption.cell
                                ;  _issueDate.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ZeroCouponBond> format
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
    [<ExcelFunction(Name="_ZeroCouponBond_accruedAmount", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".AccruedAmount") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_calendar", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ZeroCouponBond> format
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
    [<ExcelFunction(Name="_ZeroCouponBond_cashflows", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<CashFlow>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".Cashflows") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
        ! The default bond settlement is used for calculation.  \warning the theoretical price calculated from a flat term structure might differ slightly from the price calculated from the corresponding yield by means of the other overload of this function. If the price from a constant yield is desired, it is advisable to use such other overload.
    *)
    [<ExcelFunction(Name="_ZeroCouponBond_cleanPrice", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".CleanPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_cleanPrice1", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_cleanPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
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

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".CleanPrice") 

                                               [| _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_dirtyPrice1", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_dirtyPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
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

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).DirtyPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".DirtyPrice") 

                                               [| _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_dirtyPrice", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).DirtyPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".DirtyPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_isExpired", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_issueDate", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".IssueDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_isTradable", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".IsTradable") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_maturityDate", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".MaturityDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_nextCashFlowDate", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".NextCashFlowDate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_nextCouponRate", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".NextCouponRate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_notional", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".Notional") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_notionals", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".Notionals") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_previousCashFlowDate", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".PreviousCashFlowDate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_previousCouponRate", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".PreviousCouponRate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_redemption", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".Redemption") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ZeroCouponBond> format
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
    [<ExcelFunction(Name="_ZeroCouponBond_redemptions", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<CashFlow>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".Redemptions") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_settlementDate", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".SettlementDate") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_settlementDays", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_settlementValue", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "double")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".SettlementValue") 

                                               [| _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_settlementValue1", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_settlementValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".SettlementValue1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_startDate", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".StartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_yield1", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_yield1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
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

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).Yield1
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".Yield1") 

                                               [| _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_yield", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
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

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).Yield
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".Yield") 

                                               [| _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_CASH", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_errorEstimate", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_NPV", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_result", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_setPricingEngine", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : ZeroCouponBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_valuationDate", Description="Create a ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponBond",Description = "ZeroCouponBond")>] 
         zerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponBond = Helper.toCell<ZeroCouponBond> zerocouponbond "ZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroCouponBondModel.Cast _ZeroCouponBond.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ZeroCouponBond.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroCouponBond.cell
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
    [<ExcelFunction(Name="_ZeroCouponBond_Range", Description="Create a range of ZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ZeroCouponBond> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<ZeroCouponBond> (c)) :> ICell
                let format (i : Cephei.Cell.List<ZeroCouponBond>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<ZeroCouponBond>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
