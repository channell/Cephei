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
module CmsRateBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CmsRateBond", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "Reference to faceAmount")>] 
         faceAmount : obj)
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
        ([<ExcelArgument(Name="redemption",Description = "Reference to redemption")>] 
         redemption : obj)
        ([<ExcelArgument(Name="issueDate",Description = "Reference to issueDate")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" true
                let _faceAmount = Helper.toCell<double> faceAmount "faceAmount" true
                let _schedule = Helper.toCell<Schedule> schedule "schedule" true
                let _index = Helper.toCell<SwapIndex> index "index" true
                let _paymentDayCounter = Helper.toCell<DayCounter> paymentDayCounter "paymentDayCounter" true
                let _paymentConvention = Helper.toCell<BusinessDayConvention> paymentConvention "paymentConvention" true
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" true
                let _gearings = Helper.toCell<Generic.List<double>> gearings "gearings" true
                let _spreads = Helper.toCell<Generic.List<double>> spreads "spreads" true
                let _caps = Helper.toCell<List<Nullable<double>>> caps "caps" true
                let _floors = Helper.toCell<List<Nullable<double>>> floors "floors" true
                let _inArrears = Helper.toCell<bool> inArrears "inArrears" true
                let _redemption = Helper.toCell<double> redemption "redemption" true
                let _issueDate = Helper.toCell<Date> issueDate "issueDate" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.CmsRateBond 
                                                            _settlementDays.cell 
                                                            _faceAmount.cell 
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
                                                            _redemption.cell 
                                                            _issueDate.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CmsRateBond>) l

                let source = Helper.sourceFold "Fun.CmsRateBond" 
                                               [| _settlementDays.source
                                               ;  _faceAmount.source
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
                                               ;  _redemption.source
                                               ;  _issueDate.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _faceAmount.cell
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
                                ;  _redemption.cell
                                ;  _issueDate.cell
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
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_CmsRateBond_accruedAmount", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CmsRateBond.source + ".AccruedAmount") 
                                               [| _CmsRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_calendar", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_CmsRateBond.source + ".Calendar") 
                                               [| _CmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_cashflows", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_CmsRateBond.source + ".Cashflows") 
                                               [| _CmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_cleanPrice", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CmsRateBond.source + ".CleanPrice") 
                                               [| _CmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_cleanPrice", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
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

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let _Yield = Helper.toCell<double> Yield "Yield" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CmsRateBond.source + ".CleanPrice1") 
                                               [| _CmsRateBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_dirtyPrice", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
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

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let _Yield = Helper.toCell<double> Yield "Yield" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).DirtyPrice
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CmsRateBond.source + ".DirtyPrice") 
                                               [| _CmsRateBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_dirtyPrice", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).DirtyPrice1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CmsRateBond.source + ".DirtyPrice1") 
                                               [| _CmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_isExpired", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CmsRateBond.source + ".IsExpired") 
                                               [| _CmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_issueDate", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CmsRateBond.source + ".IssueDate") 
                                               [| _CmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_isTradable", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CmsRateBond.source + ".IsTradable") 
                                               [| _CmsRateBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_maturityDate", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CmsRateBond.source + ".MaturityDate") 
                                               [| _CmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_nextCashFlowDate", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CmsRateBond.source + ".NextCashFlowDate") 
                                               [| _CmsRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_nextCouponRate", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CmsRateBond.source + ".NextCouponRate") 
                                               [| _CmsRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_notional", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CmsRateBond.source + ".Notional") 
                                               [| _CmsRateBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_notionals", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_CmsRateBond.source + ".Notionals") 
                                               [| _CmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_previousCashFlowDate", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CmsRateBond.source + ".PreviousCashFlowDate") 
                                               [| _CmsRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_previousCouponRate", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CmsRateBond.source + ".PreviousCouponRate") 
                                               [| _CmsRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_redemption", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source = Helper.sourceFold (_CmsRateBond.source + ".Redemption") 
                                               [| _CmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_redemptions", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_CmsRateBond.source + ".Redemptions") 
                                               [| _CmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_settlementDate", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let _date = Helper.toCell<Date> date "date" true
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CmsRateBond.source + ".SettlementDate") 
                                               [| _CmsRateBond.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_settlementDays", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CmsRateBond.source + ".SettlementDays") 
                                               [| _CmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_settlementValue", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "Reference to cleanPrice")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" true
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CmsRateBond.source + ".SettlementValue") 
                                               [| _CmsRateBond.source
                                               ;  _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_settlementValue", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CmsRateBond.source + ".SettlementValue1") 
                                               [| _CmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_startDate", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CmsRateBond.source + ".StartDate") 
                                               [| _CmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_yield", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
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

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).Yield
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CmsRateBond.source + ".YIELD") 
                                               [| _CmsRateBond.source
                                               ;  _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_yield", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
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

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).Yield1
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CmsRateBond.source + ".YIELD") 
                                               [| _CmsRateBond.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_CASH", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CmsRateBond.source + ".CASH") 
                                               [| _CmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_errorEstimate", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CmsRateBond.source + ".ErrorEstimate") 
                                               [| _CmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_NPV", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CmsRateBond.source + ".NPV") 
                                               [| _CmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_result", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let _tag = Helper.toCell<string> tag "tag" true
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : object) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CmsRateBond.source + ".Result") 
                                               [| _CmsRateBond.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_setPricingEngine", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let _e = Helper.toCell<IPricingEngine> e "e" true
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : CmsRateBond) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CmsRateBond.source + ".SetPricingEngine") 
                                               [| _CmsRateBond.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_valuationDate", Description="Create a CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsRateBond",Description = "Reference to CmsRateBond")>] 
         cmsratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsRateBond = Helper.toCell<CmsRateBond> cmsratebond "CmsRateBond" true 
                let builder () = withMnemonic mnemonic ((_CmsRateBond.cell :?> CmsRateBondModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CmsRateBond.source + ".ValuationDate") 
                                               [| _CmsRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsRateBond.cell
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
    [<ExcelFunction(Name="_CmsRateBond_Range", Description="Create a range of CmsRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CmsRateBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CmsRateBond")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CmsRateBond> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CmsRateBond>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CmsRateBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CmsRateBond>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
