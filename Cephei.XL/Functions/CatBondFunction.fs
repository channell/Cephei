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
module CatBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CatBond", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_create
        ([<ExcelArgument(Name="Mnemonic",Description = "CatBond")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="issueDate",Description = "Date")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="notionalRisk",Description = "NotionalRisk")>] 
         notionalRisk : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _issueDate = Helper.toCell<Date> issueDate "issueDate" 
                let _notionalRisk = Helper.toCell<NotionalRisk> notionalRisk "notionalRisk" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CatBond 
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _issueDate.cell 
                                                            _notionalRisk.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CatBond>) l

                let source () = Helper.sourceFold "Fun.CatBond" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _issueDate.source
                                               ;  _notionalRisk.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _issueDate.cell
                                ;  _notionalRisk.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CatBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CatBond_exhaustionProbability", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_exhaustionProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).ExhaustionProbability
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".ExhaustionProbability") 
                                               [| _CatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_expectedLoss", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_expectedLoss
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).ExpectedLoss
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".ExpectedLoss") 
                                               [| _CatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_lossProbability", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_lossProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).LossProbability
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".LossProbability") 
                                               [| _CatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_accruedAmount", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".AccruedAmount") 
                                               [| _CatBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_calendar", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_CatBond.source + ".Calendar") 
                                               [| _CatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CatBond> format
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
    [<ExcelFunction(Name="_CatBond_cashflows", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_CatBond.source + ".Cashflows") 
                                               [| _CatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_cleanPrice", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".CleanPrice") 
                                               [| _CatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_cleanPrice1", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_cleanPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
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

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".CleanPrice1") 
                                               [| _CatBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_dirtyPrice1", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_dirtyPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
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

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).DirtyPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".DirtyPrice") 
                                               [| _CatBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_dirtyPrice", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).DirtyPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".DirtyPrice") 
                                               [| _CatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_isExpired", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".IsExpired") 
                                               [| _CatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_issueDate", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".IssueDate") 
                                               [| _CatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_isTradable", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".IsTradable") 
                                               [| _CatBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_maturityDate", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".MaturityDate") 
                                               [| _CatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_nextCashFlowDate", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".NextCashFlowDate") 
                                               [| _CatBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_nextCouponRate", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".NextCouponRate") 
                                               [| _CatBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_notional", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".Notional") 
                                               [| _CatBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_notionals", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_CatBond.source + ".Notionals") 
                                               [| _CatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_previousCashFlowDate", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".PreviousCashFlowDate") 
                                               [| _CatBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_previousCouponRate", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".PreviousCouponRate") 
                                               [| _CatBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_redemption", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source () = Helper.sourceFold (_CatBond.source + ".Redemption") 
                                               [| _CatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CatBond> format
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
    [<ExcelFunction(Name="_CatBond_redemptions", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_CatBond.source + ".Redemptions") 
                                               [| _CatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_settlementDate", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".SettlementDate") 
                                               [| _CatBond.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_settlementDays", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".SettlementDays") 
                                               [| _CatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_settlementValue", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "double")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".SettlementValue") 
                                               [| _CatBond.source
                                               ;  _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_settlementValue1", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_settlementValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".SettlementValue1") 
                                               [| _CatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_startDate", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".StartDate") 
                                               [| _CatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_yield1", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_yield1
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
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

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).Yield1
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".Yield1") 
                                               [| _CatBond.source
                                               ;  _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_yield", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
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

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).Yield
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".Yield") 
                                               [| _CatBond.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_CASH", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".CASH") 
                                               [| _CatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_errorEstimate", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".ErrorEstimate") 
                                               [| _CatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_NPV", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".NPV") 
                                               [| _CatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_result", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".Result") 
                                               [| _CatBond.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_setPricingEngine", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : CatBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".SetPricingEngine") 
                                               [| _CatBond.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_valuationDate", Description="Create a CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CatBond",Description = "CatBond")>] 
         catbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CatBond = Helper.toCell<CatBond> catbond "CatBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CatBondModel.Cast _CatBond.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CatBond.source + ".ValuationDate") 
                                               [| _CatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CatBond.cell
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
    [<ExcelFunction(Name="_CatBond_Range", Description="Create a range of CatBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CatBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CatBond> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CatBond>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<CatBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<CatBond>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
