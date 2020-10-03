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
  Derived classes must fill the unitialized data members.  Most methods assume that the cashflows are stored sorted by date, the redemption being the last one.  - price/yield calculations are cross-checked for consistency. - price/yield calculations are checked against known good values.
  </summary> *)
[<AutoSerializable(true)>]
module BondFunction =

    (*
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_Bond_accruedAmount", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let _settlement = Helper.toDefault<Date> settlement "settlement" null
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Bond.source + ".AccruedAmount") 
                                               [| _Bond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
        ! \warning The last passed cash flow must be the bond redemption. No other cash flow can have a date later than the redemption date.
    *)
    [<ExcelFunction(Name="_Bond", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "Reference to faceAmount")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="maturityDate",Description = "Reference to maturityDate")>] 
         maturityDate : obj)
        ([<ExcelArgument(Name="issueDate",Description = "Reference to issueDate")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="cashflows",Description = "Reference to cashflows")>] 
         cashflows : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _faceAmount = Helper.toCell<double> faceAmount "faceAmount" 
                let _maturityDate = Helper.toCell<Date> maturityDate "maturityDate" 
                let _issueDate = Helper.toDefault<Date> issueDate "issueDate" null
                let _cashflows = Helper.toDefault<Generic.List<CashFlow>> cashflows "cashflows" null
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.Bond 
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _faceAmount.cell 
                                                            _maturityDate.cell 
                                                            _issueDate.cell 
                                                            _cashflows.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Bond>) l

                let source = Helper.sourceFold "Fun.Bond" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _faceAmount.source
                                               ;  _maturityDate.source
                                               ;  _issueDate.source
                                               ;  _cashflows.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _faceAmount.cell
                                ;  _maturityDate.cell
                                ;  _issueDate.cell
                                ;  _cashflows.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Bond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Redemptions and maturity are calculated from the coupon data, if available.  Therefore, redemptions must not be included in the passed cash flows.
    *)
    [<ExcelFunction(Name="_Bond1", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="issueDate",Description = "Reference to issueDate")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="coupons",Description = "Reference to coupons")>] 
         coupons : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _issueDate = Helper.toDefault<Date> issueDate "issueDate" null
                let _coupons = Helper.toDefault<Generic.List<CashFlow>> coupons "coupons" null
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.Bond1 
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _issueDate.cell 
                                                            _coupons.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Bond>) l

                let source = Helper.sourceFold "Fun.Bond1" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _issueDate.source
                                               ;  _coupons.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _issueDate.cell
                                ;  _coupons.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Bond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Bond_calendar", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Bond.source + ".Calendar") 
                                               [| _Bond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Bond> format
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
    [<ExcelFunction(Name="_Bond_cashflows", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Bond.source + ".Cashflows") 
                                               [| _Bond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_cleanPrice", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Bond.source + ".CleanPrice") 
                                               [| _Bond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_cleanPrice1", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_cleanPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
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

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toDefault<Date> settlement "settlement" null
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Bond.source + ".CleanPrice1") 
                                               [| _Bond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_dirtyPrice1", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_dirtyPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
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

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toDefault<Date> settlement "settlement" null
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).DirtyPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Bond.source + ".DirtyPrice") 
                                               [| _Bond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_dirtyPrice", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).DirtyPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Bond.source + ".DirtyPrice") 
                                               [| _Bond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_isExpired", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bond.source + ".IsExpired") 
                                               [| _Bond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_issueDate", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Bond.source + ".IssueDate") 
                                               [| _Bond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_isTradable", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let _d = Helper.toDefault<Date> d "d" null
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bond.source + ".IsTradable") 
                                               [| _Bond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_maturityDate", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Bond.source + ".MaturityDate") 
                                               [| _Bond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_nextCashFlowDate", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let _settlement = Helper.toDefault<Date> settlement "settlement" null
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Bond.source + ".NextCashFlowDate") 
                                               [| _Bond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_nextCouponRate", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let _settlement = Helper.toDefault<Date> settlement "settlement" null
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Bond.source + ".NextCouponRate") 
                                               [| _Bond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_notional", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let _d = Helper.toDefault<Date> d "d" null
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Bond.source + ".Notional") 
                                               [| _Bond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_notionals", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_Bond.source + ".Notionals") 
                                               [| _Bond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_previousCashFlowDate", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let _settlement = Helper.toDefault<Date> settlement "settlement" null
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Bond.source + ".PreviousCashFlowDate") 
                                               [| _Bond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_previousCouponRate", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let _settlement = Helper.toDefault<Date> settlement "settlement" null
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Bond.source + ".PreviousCouponRate") 
                                               [| _Bond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_redemption", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source = Helper.sourceFold (_Bond.source + ".Redemption") 
                                               [| _Bond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Bond> format
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
    [<ExcelFunction(Name="_Bond_redemptions", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Bond.source + ".Redemptions") 
                                               [| _Bond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_settlementDate", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let _date = Helper.toDefault<Date> date "date" null
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Bond.source + ".SettlementDate") 
                                               [| _Bond.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_settlementDays", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Bond.source + ".SettlementDays") 
                                               [| _Bond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_settlementValue", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "Reference to cleanPrice")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Bond.source + ".SettlementValue") 
                                               [| _Bond.source
                                               ;  _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_settlementValue1", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_settlementValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Bond.source + ".SettlementValue1") 
                                               [| _Bond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_startDate", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Bond.source + ".StartDate") 
                                               [| _Bond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_yield1", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_yield1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
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

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toDefault<Date> settlement "settlement" null
                let _accuracy = Helper.toDefault<double> accuracy "accuracy" 1.0e-8
                let _maxEvaluations = Helper.toDefault<int> maxEvaluations "maxEvaluations" 100
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).Yield1
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Bond.source + ".Yield1") 
                                               [| _Bond.source
                                               ;  _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_yield", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
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

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _accuracy = Helper.toDefault<double> accuracy "accuracy" 1.0e-8
                let _maxEvaluations = Helper.toDefault<int> maxEvaluations "maxEvaluations" 100
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).Yield
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Bond.source + ".Yield") 
                                               [| _Bond.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_CASH", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Bond.source + ".CASH") 
                                               [| _Bond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_errorEstimate", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Bond.source + ".ErrorEstimate") 
                                               [| _Bond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_NPV", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Bond.source + ".NPV") 
                                               [| _Bond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_result", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bond.source + ".Result") 
                                               [| _Bond.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_setPricingEngine", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : Bond) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bond.source + ".SetPricingEngine") 
                                               [| _Bond.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_valuationDate", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bond",Description = "Reference to Bond")>] 
         bond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "Bond"  
                let builder () = withMnemonic mnemonic ((BondModel.Cast _Bond.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Bond.source + ".ValuationDate") 
                                               [| _Bond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bond.cell
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
    [<ExcelFunction(Name="_Bond_Range", Description="Create a range of Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Bond")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Bond> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Bond>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Bond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Bond>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
