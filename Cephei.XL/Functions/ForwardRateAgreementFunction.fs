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
  1. Unlike the forward contract conventions on carryable financial assets (stocks, bonds, commodities), the valueDate for a FRA is taken to be the day when the forward loan or deposit begins and when full settlement takes place (based on the NPV of the contract on that date). maturityDate is the date when the forward loan or deposit ends. In fact, the FRA settles and expires on the valueDate, not on the (later) maturityDate. It follows that (maturityDate - valueDate) is the tenor/term of the underlying loan or deposit  2. Choose position type = Long for an "FRA purchase" (future long loan, short deposit [borrower])  3. Choose position type = Short for an "FRA sale" (future short loan, long deposit [lender])  4. If strike is given in the constructor, can calculate the NPV of the contract via NPV().  5. If forward rate is desired/unknown, it can be obtained via forwardRate(). In this case, the strike variable in the constructor is irrelevant and will be ignored. 
<b>Example: </b> FRA.cs valuation of a forward-rate agreement  Add preconditions and tests  Should put an instance of ForwardRateAgreement in the FraRateHelper to ensure consistency with the piecewise yield curve.  Differentiate between BBA (British)/AFB (French) [assumed here] and ABA (Australian) banker conventions in the calculations.  This class still needs to be rigorously tested  instruments
  </summary> *)
[<AutoSerializable(true)>]
module ForwardRateAgreementFunction =

    (*
        ! Returns the relevant forward rate associated with the FRA term
    *)
    [<ExcelFunction(Name="_ForwardRateAgreement_forwardRate", Description="Create a ForwardRateAgreement",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardRateAgreement_forwardRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardRateAgreement",Description = "ForwardRateAgreement")>] 
         forwardrateagreement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardRateAgreement = Helper.toCell<ForwardRateAgreement> forwardrateagreement "ForwardRateAgreement"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardRateAgreementModel.Cast _ForwardRateAgreement.cell).ForwardRate
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source () = Helper.sourceFold (_ForwardRateAgreement.source + ".ForwardRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardRateAgreement.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ForwardRateAgreement> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ForwardRateAgreement", Description="Create a ForwardRateAgreement",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardRateAgreement_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        ([<ExcelArgument(Name="maturityDate",Description = "Date")>] 
         maturityDate : obj)
        ([<ExcelArgument(Name="Type",Description = "Position.Type: Long, Short")>] 
         Type : obj)
        ([<ExcelArgument(Name="strikeForwardRate",Description = "double")>] 
         strikeForwardRate : obj)
        ([<ExcelArgument(Name="notionalAmount",Description = "double")>] 
         notionalAmount : obj)
        ([<ExcelArgument(Name="index",Description = "IborIndex")>] 
         index : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
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
                let _strikeForwardRate = Helper.toCell<double> strikeForwardRate "strikeForwardRate" 
                let _notionalAmount = Helper.toCell<double> notionalAmount "notionalAmount" 
                let _index = Helper.toCell<IborIndex> index "index" 
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.ForwardRateAgreement 
                                                            _valueDate.cell 
                                                            _maturityDate.cell 
                                                            _Type.cell 
                                                            _strikeForwardRate.cell 
                                                            _notionalAmount.cell 
                                                            _index.cell 
                                                            _discountCurve.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ForwardRateAgreement>) l

                let source () = Helper.sourceFold "Fun.ForwardRateAgreement" 
                                               [| _valueDate.source
                                               ;  _maturityDate.source
                                               ;  _Type.source
                                               ;  _strikeForwardRate.source
                                               ;  _notionalAmount.source
                                               ;  _index.source
                                               ;  _discountCurve.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _valueDate.cell
                                ;  _maturityDate.cell
                                ;  _Type.cell
                                ;  _strikeForwardRate.cell
                                ;  _notionalAmount.cell
                                ;  _index.cell
                                ;  _discountCurve.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ForwardRateAgreement> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! A FRA expires/settles on the valueDate
    *)
    [<ExcelFunction(Name="_ForwardRateAgreement_isExpired", Description="Create a ForwardRateAgreement",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardRateAgreement_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardRateAgreement",Description = "ForwardRateAgreement")>] 
         forwardrateagreement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardRateAgreement = Helper.toCell<ForwardRateAgreement> forwardrateagreement "ForwardRateAgreement"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardRateAgreementModel.Cast _ForwardRateAgreement.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardRateAgreement.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardRateAgreement.cell
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
        Calculations
    *)
    [<ExcelFunction(Name="_ForwardRateAgreement_settlementDate", Description="Create a ForwardRateAgreement",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardRateAgreement_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardRateAgreement",Description = "ForwardRateAgreement")>] 
         forwardrateagreement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardRateAgreement = Helper.toCell<ForwardRateAgreement> forwardrateagreement "ForwardRateAgreement"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardRateAgreementModel.Cast _ForwardRateAgreement.cell).SettlementDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ForwardRateAgreement.source + ".SettlementDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardRateAgreement.cell
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
        !  Income is zero for a FRA
    *)
    [<ExcelFunction(Name="_ForwardRateAgreement_spotIncome", Description="Create a ForwardRateAgreement",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardRateAgreement_spotIncome
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardRateAgreement",Description = "ForwardRateAgreement")>] 
         forwardrateagreement : obj)
        ([<ExcelArgument(Name="t",Description = "YieldTermStructure")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardRateAgreement = Helper.toCell<ForwardRateAgreement> forwardrateagreement "ForwardRateAgreement"  
                let _t = Helper.toHandle<YieldTermStructure> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardRateAgreementModel.Cast _ForwardRateAgreement.cell).SpotIncome
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardRateAgreement.source + ".SpotIncome") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardRateAgreement.cell
                                ;  _t.cell
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
        ! This has always a positive value (asset), even if short the FRA
    *)
    [<ExcelFunction(Name="_ForwardRateAgreement_spotValue", Description="Create a ForwardRateAgreement",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardRateAgreement_spotValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardRateAgreement",Description = "ForwardRateAgreement")>] 
         forwardrateagreement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardRateAgreement = Helper.toCell<ForwardRateAgreement> forwardrateagreement "ForwardRateAgreement"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardRateAgreementModel.Cast _ForwardRateAgreement.cell).SpotValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardRateAgreement.source + ".SpotValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardRateAgreement.cell
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
    [<ExcelFunction(Name="_ForwardRateAgreement_forwardValue", Description="Create a ForwardRateAgreement",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardRateAgreement_forwardValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardRateAgreement",Description = "ForwardRateAgreement")>] 
         forwardrateagreement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardRateAgreement = Helper.toCell<ForwardRateAgreement> forwardrateagreement "ForwardRateAgreement"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardRateAgreementModel.Cast _ForwardRateAgreement.cell).ForwardValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardRateAgreement.source + ".ForwardValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardRateAgreement.cell
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
    [<ExcelFunction(Name="_ForwardRateAgreement_impliedYield", Description="Create a ForwardRateAgreement",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardRateAgreement_impliedYield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardRateAgreement",Description = "ForwardRateAgreement")>] 
         forwardrateagreement : obj)
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

                let _ForwardRateAgreement = Helper.toCell<ForwardRateAgreement> forwardrateagreement "ForwardRateAgreement"  
                let _underlyingSpotValue = Helper.toCell<double> underlyingSpotValue "underlyingSpotValue" 
                let _forwardValue = Helper.toCell<double> forwardValue "forwardValue" 
                let _settlementDate = Helper.toCell<Date> settlementDate "settlementDate" 
                let _compoundingConvention = Helper.toCell<Compounding> compoundingConvention "compoundingConvention" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardRateAgreementModel.Cast _ForwardRateAgreement.cell).ImpliedYield
                                                            _underlyingSpotValue.cell 
                                                            _forwardValue.cell 
                                                            _settlementDate.cell 
                                                            _compoundingConvention.cell 
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source () = Helper.sourceFold (_ForwardRateAgreement.source + ".ImpliedYield") 

                                               [| _underlyingSpotValue.source
                                               ;  _forwardValue.source
                                               ;  _settlementDate.source
                                               ;  _compoundingConvention.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardRateAgreement.cell
                                ;  _underlyingSpotValue.cell
                                ;  _forwardValue.cell
                                ;  _settlementDate.cell
                                ;  _compoundingConvention.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ForwardRateAgreement> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ForwardRateAgreement_CASH", Description="Create a ForwardRateAgreement",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardRateAgreement_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardRateAgreement",Description = "ForwardRateAgreement")>] 
         forwardrateagreement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardRateAgreement = Helper.toCell<ForwardRateAgreement> forwardrateagreement "ForwardRateAgreement"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardRateAgreementModel.Cast _ForwardRateAgreement.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardRateAgreement.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardRateAgreement.cell
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
    [<ExcelFunction(Name="_ForwardRateAgreement_errorEstimate", Description="Create a ForwardRateAgreement",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardRateAgreement_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardRateAgreement",Description = "ForwardRateAgreement")>] 
         forwardrateagreement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardRateAgreement = Helper.toCell<ForwardRateAgreement> forwardrateagreement "ForwardRateAgreement"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardRateAgreementModel.Cast _ForwardRateAgreement.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardRateAgreement.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardRateAgreement.cell
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
    [<ExcelFunction(Name="_ForwardRateAgreement_NPV", Description="Create a ForwardRateAgreement",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardRateAgreement_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardRateAgreement",Description = "ForwardRateAgreement")>] 
         forwardrateagreement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardRateAgreement = Helper.toCell<ForwardRateAgreement> forwardrateagreement "ForwardRateAgreement"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardRateAgreementModel.Cast _ForwardRateAgreement.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardRateAgreement.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardRateAgreement.cell
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
    [<ExcelFunction(Name="_ForwardRateAgreement_result", Description="Create a ForwardRateAgreement",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardRateAgreement_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardRateAgreement",Description = "ForwardRateAgreement")>] 
         forwardrateagreement : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardRateAgreement = Helper.toCell<ForwardRateAgreement> forwardrateagreement "ForwardRateAgreement"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardRateAgreementModel.Cast _ForwardRateAgreement.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardRateAgreement.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardRateAgreement.cell
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
    [<ExcelFunction(Name="_ForwardRateAgreement_setPricingEngine", Description="Create a ForwardRateAgreement",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardRateAgreement_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardRateAgreement",Description = "ForwardRateAgreement")>] 
         forwardrateagreement : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardRateAgreement = Helper.toCell<ForwardRateAgreement> forwardrateagreement "ForwardRateAgreement"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardRateAgreementModel.Cast _ForwardRateAgreement.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : ForwardRateAgreement) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardRateAgreement.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardRateAgreement.cell
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
    [<ExcelFunction(Name="_ForwardRateAgreement_valuationDate", Description="Create a ForwardRateAgreement",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardRateAgreement_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardRateAgreement",Description = "ForwardRateAgreement")>] 
         forwardrateagreement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardRateAgreement = Helper.toCell<ForwardRateAgreement> forwardrateagreement "ForwardRateAgreement"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardRateAgreementModel.Cast _ForwardRateAgreement.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ForwardRateAgreement.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardRateAgreement.cell
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
    [<ExcelFunction(Name="_ForwardRateAgreement_Range", Description="Create a range of ForwardRateAgreement",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardRateAgreement_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ForwardRateAgreement> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<ForwardRateAgreement> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<ForwardRateAgreement>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<ForwardRateAgreement>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
