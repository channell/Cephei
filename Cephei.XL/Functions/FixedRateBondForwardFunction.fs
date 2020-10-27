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
  1. valueDate refers to the settlement date of the bond forward contract.  maturityDate is the delivery (or repurchase) date for the underlying bond (not the bond's maturity date).  2. Relevant formulas used in the calculations  refers to a price):  a. P_{CleanFwd}(t) = P_{DirtyFwd}(t) - AI(t=deliveryDate) where AI refers to the accrued interest on the underlying bond.  b. P_{DirtyFwd}(t) = - SpotIncome(t)} {discountCurve->discount(t=deliveryDate)}  c. SpotIncome(t) = CF_i incomeDiscountCurve->discount(t_i) where CF_i represents the ith bond cash flow (coupon payment) associated with the underlying bond falling between the settlementDate and the deliveryDate. (Note the two different discount curves used in b. and c.) 
<b>Example: </b> Repo.cpp valuation of a repo on a fixed-rate bond  Add preconditions and tests  Create switch- if coupon goes to seller is toggled on, don't consider income in the P_{DirtyFwd}(t) calculation.  Verify this works when the underlying is paper (in which case ignore all AI.)  This class still needs to be rigorously tested  instruments
  </summary> *)
[<AutoSerializable(true)>]
module FixedRateBondForwardFunction =

    (*
        ! (dirty) forward bond price minus accrued on bond at delivery
    *)
    [<ExcelFunction(Name="_FixedRateBondForward_cleanForwardPrice", Description="Create a FixedRateBondForward",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBondForward_cleanForwardPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "FixedRateBondForward")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondForward",Description = "FixedRateBondForward")>] 
         fixedratebondforward : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondForward = Helper.toCell<FixedRateBondForward> fixedratebondforward "FixedRateBondForward"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondForwardModel.Cast _FixedRateBondForward.cell).CleanForwardPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateBondForward.source + ".CleanForwardPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedRateBondForward.cell
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
        ! If strike is given in the constructor, can calculate the NPV of the contract via NPV().  If strike/forward price is desired, it can be obtained via forwardPrice(). In this case, the strike variable in the constructor is irrelevant and will be ignored.
    *)
    [<ExcelFunction(Name="_FixedRateBondForward", Description="Create a FixedRateBondForward",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBondForward_create
        ([<ExcelArgument(Name="Mnemonic",Description = "FixedRateBondForward")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        ([<ExcelArgument(Name="maturityDate",Description = "Date")>] 
         maturityDate : obj)
        ([<ExcelArgument(Name="Type",Description = "Position.Type: Long, Short")>] 
         Type : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="businessDayConvention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         businessDayConvention : obj)
        ([<ExcelArgument(Name="fixedCouponBond",Description = "FixedRateBond")>] 
         fixedCouponBond : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="incomeDiscountCurve",Description = "YieldTermStructure")>] 
         incomeDiscountCurve : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let _maturityDate = Helper.toCell<Date> maturityDate "maturityDate" 
                let _Type = Helper.toCell<Position.Type> Type "Type" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _businessDayConvention = Helper.toCell<BusinessDayConvention> businessDayConvention "businessDayConvention" 
                let _fixedCouponBond = Helper.toCell<FixedRateBond> fixedCouponBond "fixedCouponBond" 
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _incomeDiscountCurve = Helper.toHandle<YieldTermStructure> incomeDiscountCurve "incomeDiscountCurve" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FixedRateBondForward 
                                                            _valueDate.cell 
                                                            _maturityDate.cell 
                                                            _Type.cell 
                                                            _strike.cell 
                                                            _settlementDays.cell 
                                                            _dayCounter.cell 
                                                            _calendar.cell 
                                                            _businessDayConvention.cell 
                                                            _fixedCouponBond.cell 
                                                            _discountCurve.cell 
                                                            _incomeDiscountCurve.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FixedRateBondForward>) l

                let source () = Helper.sourceFold "Fun.FixedRateBondForward" 
                                               [| _valueDate.source
                                               ;  _maturityDate.source
                                               ;  _Type.source
                                               ;  _strike.source
                                               ;  _settlementDays.source
                                               ;  _dayCounter.source
                                               ;  _calendar.source
                                               ;  _businessDayConvention.source
                                               ;  _fixedCouponBond.source
                                               ;  _discountCurve.source
                                               ;  _incomeDiscountCurve.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _valueDate.cell
                                ;  _maturityDate.cell
                                ;  _Type.cell
                                ;  _strike.cell
                                ;  _settlementDays.cell
                                ;  _dayCounter.cell
                                ;  _calendar.cell
                                ;  _businessDayConvention.cell
                                ;  _fixedCouponBond.cell
                                ;  _discountCurve.cell
                                ;  _incomeDiscountCurve.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateBondForward> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! (dirty) forward bond price
    *)
    [<ExcelFunction(Name="_FixedRateBondForward_forwardPrice", Description="Create a FixedRateBondForward",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBondForward_forwardPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "InterestRate")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondForward",Description = "FixedRateBondForward")>] 
         fixedratebondforward : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondForward = Helper.toCell<FixedRateBondForward> fixedratebondforward "FixedRateBondForward"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondForwardModel.Cast _FixedRateBondForward.cell).ForwardPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateBondForward.source + ".ForwardPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedRateBondForward.cell
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
        ! Here only coupons between max(evaluation date,settlement date) and maturity date of bond forward contract are considered income.
    *)
    [<ExcelFunction(Name="_FixedRateBondForward_spotIncome", Description="Create a FixedRateBondForward",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBondForward_spotIncome
        ([<ExcelArgument(Name="Mnemonic",Description = "InterestRate")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondForward",Description = "FixedRateBondForward")>] 
         fixedratebondforward : obj)
        ([<ExcelArgument(Name="incomeDiscountCurve",Description = "YieldTermStructure")>] 
         incomeDiscountCurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondForward = Helper.toCell<FixedRateBondForward> fixedratebondforward "FixedRateBondForward"  
                let _incomeDiscountCurve = Helper.toHandle<YieldTermStructure> incomeDiscountCurve "incomeDiscountCurve" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondForwardModel.Cast _FixedRateBondForward.cell).SpotIncome
                                                            _incomeDiscountCurve.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateBondForward.source + ".SpotIncome") 

                                               [| _incomeDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBondForward.cell
                                ;  _incomeDiscountCurve.cell
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
        !  NPV of underlying bond
    *)
    [<ExcelFunction(Name="_FixedRateBondForward_spotValue", Description="Create a FixedRateBondForward",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBondForward_spotValue
        ([<ExcelArgument(Name="Mnemonic",Description = "InterestRate")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondForward",Description = "FixedRateBondForward")>] 
         fixedratebondforward : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondForward = Helper.toCell<FixedRateBondForward> fixedratebondforward "FixedRateBondForward"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondForwardModel.Cast _FixedRateBondForward.cell).SpotValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateBondForward.source + ".SpotValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedRateBondForward.cell
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
        ! \note if this is a bond forward price, is must be a dirty forward price.
    *)
    [<ExcelFunction(Name="_FixedRateBondForward_forwardValue", Description="Create a FixedRateBondForward",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBondForward_forwardValue
        ([<ExcelArgument(Name="Mnemonic",Description = "InterestRate")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondForward",Description = "FixedRateBondForward")>] 
         fixedratebondforward : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondForward = Helper.toCell<FixedRateBondForward> fixedratebondforward "FixedRateBondForward"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondForwardModel.Cast _FixedRateBondForward.cell).ForwardValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateBondForward.source + ".ForwardValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedRateBondForward.cell
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
        ! Simple yield calculation based on underlying spot and forward values, taking into account underlying income. When \f$ t>0 \f$, call with: underlyingSpotValue=spotValue(t), forwardValue=strikePrice, to get current yield. For a repo, if \f$ t=0 \f$, impliedYield should reproduce the spot repo rate. For FRA's, this should reproduce the relevant zero rate at the FRA's maturityDate_
    *)
    [<ExcelFunction(Name="_FixedRateBondForward_impliedYield", Description="Create a FixedRateBondForward",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBondForward_impliedYield
        ([<ExcelArgument(Name="Mnemonic",Description = "InterestRate")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondForward",Description = "FixedRateBondForward")>] 
         fixedratebondforward : obj)
        ([<ExcelArgument(Name="underlyingSpotValue",Description = "double")>] 
         underlyingSpotValue : obj)
        ([<ExcelArgument(Name="forwardValue",Description = "double")>] 
         forwardValue : obj)
        ([<ExcelArgument(Name="settlementDate",Description = "Date")>] 
         settlementDate : obj)
        ([<ExcelArgument(Name="compoundingConvention",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         compoundingConvention : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondForward = Helper.toCell<FixedRateBondForward> fixedratebondforward "FixedRateBondForward"  
                let _underlyingSpotValue = Helper.toCell<double> underlyingSpotValue "underlyingSpotValue" 
                let _forwardValue = Helper.toCell<double> forwardValue "forwardValue" 
                let _settlementDate = Helper.toCell<Date> settlementDate "settlementDate" 
                let _compoundingConvention = Helper.toCell<Compounding> compoundingConvention "compoundingConvention" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondForwardModel.Cast _FixedRateBondForward.cell).ImpliedYield
                                                            _underlyingSpotValue.cell 
                                                            _forwardValue.cell 
                                                            _settlementDate.cell 
                                                            _compoundingConvention.cell 
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source () = Helper.sourceFold (_FixedRateBondForward.source + ".ImpliedYield") 

                                               [| _underlyingSpotValue.source
                                               ;  _forwardValue.source
                                               ;  _settlementDate.source
                                               ;  _compoundingConvention.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBondForward.cell
                                ;  _underlyingSpotValue.cell
                                ;  _forwardValue.cell
                                ;  _settlementDate.cell
                                ;  _compoundingConvention.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateBondForward> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FixedRateBondForward_isExpired", Description="Create a FixedRateBondForward",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBondForward_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondForward",Description = "FixedRateBondForward")>] 
         fixedratebondforward : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondForward = Helper.toCell<FixedRateBondForward> fixedratebondforward "FixedRateBondForward"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondForwardModel.Cast _FixedRateBondForward.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FixedRateBondForward.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedRateBondForward.cell
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
    [<ExcelFunction(Name="_FixedRateBondForward_settlementDate", Description="Create a FixedRateBondForward",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBondForward_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondForward",Description = "FixedRateBondForward")>] 
         fixedratebondforward : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondForward = Helper.toCell<FixedRateBondForward> fixedratebondforward "FixedRateBondForward"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondForwardModel.Cast _FixedRateBondForward.cell).SettlementDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FixedRateBondForward.source + ".SettlementDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedRateBondForward.cell
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
    [<ExcelFunction(Name="_FixedRateBondForward_CASH", Description="Create a FixedRateBondForward",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBondForward_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondForward",Description = "FixedRateBondForward")>] 
         fixedratebondforward : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondForward = Helper.toCell<FixedRateBondForward> fixedratebondforward "FixedRateBondForward"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondForwardModel.Cast _FixedRateBondForward.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateBondForward.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedRateBondForward.cell
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
    [<ExcelFunction(Name="_FixedRateBondForward_errorEstimate", Description="Create a FixedRateBondForward",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBondForward_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondForward",Description = "FixedRateBondForward")>] 
         fixedratebondforward : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondForward = Helper.toCell<FixedRateBondForward> fixedratebondforward "FixedRateBondForward"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondForwardModel.Cast _FixedRateBondForward.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateBondForward.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedRateBondForward.cell
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
    [<ExcelFunction(Name="_FixedRateBondForward_NPV", Description="Create a FixedRateBondForward",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBondForward_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondForward",Description = "FixedRateBondForward")>] 
         fixedratebondforward : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondForward = Helper.toCell<FixedRateBondForward> fixedratebondforward "FixedRateBondForward"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondForwardModel.Cast _FixedRateBondForward.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateBondForward.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedRateBondForward.cell
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
    [<ExcelFunction(Name="_FixedRateBondForward_result", Description="Create a FixedRateBondForward",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBondForward_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondForward",Description = "FixedRateBondForward")>] 
         fixedratebondforward : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondForward = Helper.toCell<FixedRateBondForward> fixedratebondforward "FixedRateBondForward"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondForwardModel.Cast _FixedRateBondForward.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FixedRateBondForward.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBondForward.cell
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
    [<ExcelFunction(Name="_FixedRateBondForward_setPricingEngine", Description="Create a FixedRateBondForward",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBondForward_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondForward",Description = "FixedRateBondForward")>] 
         fixedratebondforward : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondForward = Helper.toCell<FixedRateBondForward> fixedratebondforward "FixedRateBondForward"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondForwardModel.Cast _FixedRateBondForward.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : FixedRateBondForward) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FixedRateBondForward.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBondForward.cell
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
    [<ExcelFunction(Name="_FixedRateBondForward_valuationDate", Description="Create a FixedRateBondForward",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBondForward_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondForward",Description = "FixedRateBondForward")>] 
         fixedratebondforward : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondForward = Helper.toCell<FixedRateBondForward> fixedratebondforward "FixedRateBondForward"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondForwardModel.Cast _FixedRateBondForward.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FixedRateBondForward.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedRateBondForward.cell
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
    [<ExcelFunction(Name="_FixedRateBondForward_Range", Description="Create a range of FixedRateBondForward",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBondForward_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FixedRateBondForward> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FixedRateBondForward>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<FixedRateBondForward>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<FixedRateBondForward>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
