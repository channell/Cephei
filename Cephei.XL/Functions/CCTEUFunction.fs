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
  Italian CCTEU (Certificato di credito del tesoro) Euribor6M indexed floating rate bond  instruments
  </summary> *)
[<AutoSerializable(true)>]
module CCTEUFunction =

    (*
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_CCTEU_accruedAmount", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "CCTEU")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
        ([<ExcelArgument(Name="d",Description = "CCTEU")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let _d = Helper.toDefault<Date> d "d" null
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).AccruedAmount
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CCTEU.source + ".AccruedAmount") 
                                               [| _CCTEU.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_create
        ([<ExcelArgument(Name="Mnemonic",Description = "CCTEU")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="maturityDate",Description = "Date")>] 
         maturityDate : obj)
        ([<ExcelArgument(Name="spread",Description = "double")>] 
         spread : obj)
        ([<ExcelArgument(Name="fwdCurve",Description = "YieldTermStructure")>] 
         fwdCurve : obj)
        ([<ExcelArgument(Name="startDate",Description = "CCTEU")>] 
         startDate : obj)
        ([<ExcelArgument(Name="issueDate",Description = "CCTEU")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _maturityDate = Helper.toCell<Date> maturityDate "maturityDate" 
                let _spread = Helper.toCell<double> spread "spread" 
                let _fwdCurve = Helper.toHandle<YieldTermStructure> fwdCurve "fwdCurve" 
                let _startDate = Helper.toDefault<Date> startDate "startDate" null
                let _issueDate = Helper.toDefault<Date> issueDate "issueDate" null
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CCTEU 
                                                            _maturityDate.cell 
                                                            _spread.cell 
                                                            _fwdCurve.cell 
                                                            _startDate.cell 
                                                            _issueDate.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CCTEU>) l

                let source () = Helper.sourceFold "Fun.CCTEU" 
                                               [| _maturityDate.source
                                               ;  _spread.source
                                               ;  _fwdCurve.source
                                               ;  _startDate.source
                                               ;  _issueDate.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _maturityDate.cell
                                ;  _spread.cell
                                ;  _fwdCurve.cell
                                ;  _startDate.cell
                                ;  _issueDate.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CCTEU> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CCTEU_calendar", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_CCTEU.source + ".Calendar") 
                                               [| _CCTEU.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CCTEU> format
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
    [<ExcelFunction(Name="_CCTEU_cashflows", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_CCTEU.source + ".Cashflows") 
                                               [| _CCTEU.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_cleanPrice", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CCTEU.source + ".CleanPrice") 
                                               [| _CCTEU.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_cleanPrice1", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_cleanPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
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

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CCTEU.source + ".CleanPrice1") 
                                               [| _CCTEU.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_dirtyPrice1", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_dirtyPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
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

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).DirtyPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CCTEU.source + ".DirtyPrice1") 
                                               [| _CCTEU.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_dirtyPrice", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).DirtyPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CCTEU.source + ".DirtyPrice") 
                                               [| _CCTEU.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_isExpired", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CCTEU.source + ".IsExpired") 
                                               [| _CCTEU.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_issueDate", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CCTEU.source + ".IssueDate") 
                                               [| _CCTEU.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_isTradable", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
        ([<ExcelArgument(Name="d",Description = "CashFlow")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let _d = Helper.toDefault<Date> d "d" null
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CCTEU.source + ".IsTradable") 
                                               [| _CCTEU.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_maturityDate", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CCTEU.source + ".MaturityDate") 
                                               [| _CCTEU.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_nextCashFlowDate", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CCTEU.source + ".NextCashFlowDate") 
                                               [| _CCTEU.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_nextCouponRate", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CCTEU.source + ".NextCouponRate") 
                                               [| _CCTEU.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_notional", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
        ([<ExcelArgument(Name="d",Description = "CashFlow")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let _d = Helper.toDefault<Date> d "d" null
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CCTEU.source + ".Notional") 
                                               [| _CCTEU.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_notionals", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_CCTEU.source + ".Notionals") 
                                               [| _CCTEU.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_previousCashFlowDate", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CCTEU.source + ".PreviousCashFlowDate") 
                                               [| _CCTEU.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_previousCouponRate", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CCTEU.source + ".PreviousCouponRate") 
                                               [| _CCTEU.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_redemption", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source () = Helper.sourceFold (_CCTEU.source + ".Redemption") 
                                               [| _CCTEU.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CCTEU> format
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
    [<ExcelFunction(Name="_CCTEU_redemptions", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_CCTEU.source + ".Redemptions") 
                                               [| _CCTEU.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_settlementDate", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CCTEU.source + ".SettlementDate") 
                                               [| _CCTEU.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_settlementDays", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CCTEU.source + ".SettlementDays") 
                                               [| _CCTEU.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_settlementValue", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "double")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CCTEU.source + ".SettlementValue") 
                                               [| _CCTEU.source
                                               ;  _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_settlementValue1", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_settlementValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CCTEU.source + ".SettlementValue1") 
                                               [| _CCTEU.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_startDate", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CCTEU.source + ".StartDate") 
                                               [| _CCTEU.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_yield1", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_yield1
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
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

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).Yield1
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CCTEU.source + ".Yield1") 
                                               [| _CCTEU.source
                                               ;  _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_yield", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
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

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).Yield
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CCTEU.source + ".Yield") 
                                               [| _CCTEU.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_CASH", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CCTEU.source + ".CASH") 
                                               [| _CCTEU.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_errorEstimate", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CCTEU.source + ".ErrorEstimate") 
                                               [| _CCTEU.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_NPV", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CCTEU.source + ".NPV") 
                                               [| _CCTEU.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_result", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CCTEU.source + ".Result") 
                                               [| _CCTEU.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_setPricingEngine", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : CCTEU) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CCTEU.source + ".SetPricingEngine") 
                                               [| _CCTEU.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_valuationDate", Description="Create a CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CCTEU",Description = "CCTEU")>] 
         ccteu : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CCTEU = Helper.toCell<CCTEU> ccteu "CCTEU"  
                let builder (current : ICell) = withMnemonic mnemonic ((CCTEUModel.Cast _CCTEU.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CCTEU.source + ".ValuationDate") 
                                               [| _CCTEU.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CCTEU.cell
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
    [<ExcelFunction(Name="_CCTEU_Range", Description="Create a range of CCTEU",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CCTEU_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CCTEU> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CCTEU>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<CCTEU>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<CCTEU>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
