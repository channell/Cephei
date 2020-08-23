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
namespace Cephei.QL

open System
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System.Collections
open System.Collections.Generic
open QLNet
open Cephei.QLNetHelper

(* <summary>
  Bilateral (CVA and DVA) default adjusted vanilla swap pricing engine. Collateral is not considered. No wrong way risk is considered (rates and counterparty default are uncorrelated). Based on: Sorensen,  E.H.  and  Bollier,  T.F.,  Pricing  swap  default risk. Financial Analysts Journal, 1994, 50, 23–33 Also see sect. II-5 in: Risk Neutral Pricing of Counterparty Risk D. Brigo, M. Masetti, 2004 or in sections 3 and 4 of "A Formula for Interest Rate Swaps Valuation under Counterparty Risk in presence of Netting Agreements" D. Brigo and M. Masetti; May 4, 2005  to do: Compute fair rate through iteration instead of the current approximation . to do: write Issuer based constructors (event type) to do: Check consistency between option engine discount and the one given
! Creates an engine with a black volatility model for the exposure. The volatility is given as a quote. If the investor default model is not given a default free one is assumed.
@param discountCurve Used in pricing.
@param blackVol Black volatility used in the exposure model.
@param ctptyDTS Counterparty default curve.
@param ctptyRecoveryRate Counterparty recovey rate.
@param invstDTS Investor (swap holder) default curve.
@param invstRecoveryRate Investor recovery rate.
  </summary> *)
[<AutoSerializable(true)>]
type CounterpartyAdjSwapEngineModel
    ( discountCurve                                : ICell<Handle<YieldTermStructure>>
    , blackVol                                     : ICell<Handle<Quote>>
    , ctptyDTS                                     : ICell<Handle<DefaultProbabilityTermStructure>>
    , ctptyRecoveryRate                            : ICell<double>
    , invstDTS                                     : ICell<Handle<DefaultProbabilityTermStructure>>
    , invstRecoveryRate                            : ICell<double>
    ) as this =

    inherit Model<CounterpartyAdjSwapEngine> ()
(*
    Parameters
*)
    let _discountCurve                             = discountCurve
    let _blackVol                                  = blackVol
    let _ctptyDTS                                  = ctptyDTS
    let _ctptyRecoveryRate                         = ctptyRecoveryRate
    let _invstDTS                                  = invstDTS
    let _invstRecoveryRate                         = invstRecoveryRate
(*
    Functions
*)
    let _CounterpartyAdjSwapEngine                 = cell (fun () -> new CounterpartyAdjSwapEngine (discountCurve.Value, blackVol.Value, ctptyDTS.Value, ctptyRecoveryRate.Value, invstDTS.Value, invstRecoveryRate.Value))
    do this.Bind(_CounterpartyAdjSwapEngine)

(* 
    Externally visible/bindable properties
*)
    member this.discountCurve                      = _discountCurve 
    member this.blackVol                           = _blackVol 
    member this.ctptyDTS                           = _ctptyDTS 
    member this.ctptyRecoveryRate                  = _ctptyRecoveryRate 
    member this.invstDTS                           = _invstDTS 
    member this.invstRecoveryRate                  = _invstRecoveryRate 
(* <summary>
  Bilateral (CVA and DVA) default adjusted vanilla swap pricing engine. Collateral is not considered. No wrong way risk is considered (rates and counterparty default are uncorrelated). Based on: Sorensen,  E.H.  and  Bollier,  T.F.,  Pricing  swap  default risk. Financial Analysts Journal, 1994, 50, 23–33 Also see sect. II-5 in: Risk Neutral Pricing of Counterparty Risk D. Brigo, M. Masetti, 2004 or in sections 3 and 4 of "A Formula for Interest Rate Swaps Valuation under Counterparty Risk in presence of Netting Agreements" D. Brigo and M. Masetti; May 4, 2005  to do: Compute fair rate through iteration instead of the current approximation . to do: write Issuer based constructors (event type) to do: Check consistency between option engine discount and the one given
! Creates an engine with a black volatility model for the exposure. If the investor default model is not given a default free one is assumed.
@param discountCurve Used in pricing.
@param blackVol Black volatility used in the exposure model.
@param ctptyDTS Counterparty default curve.
@param ctptyRecoveryRate Counterparty recovey rate.
@param invstDTS Investor (swap holder) default curve.
@param invstRecoveryRate Investor recovery rate.
  </summary> *)
[<AutoSerializable(true)>]
type CounterpartyAdjSwapEngineModel1
    ( discountCurve                                : ICell<Handle<YieldTermStructure>>
    , blackVol                                     : ICell<double>
    , ctptyDTS                                     : ICell<Handle<DefaultProbabilityTermStructure>>
    , ctptyRecoveryRate                            : ICell<double>
    , invstDTS                                     : ICell<Handle<DefaultProbabilityTermStructure>>
    , invstRecoveryRate                            : ICell<double>
    ) as this =

    inherit Model<CounterpartyAdjSwapEngine> ()
(*
    Parameters
*)
    let _discountCurve                             = discountCurve
    let _blackVol                                  = blackVol
    let _ctptyDTS                                  = ctptyDTS
    let _ctptyRecoveryRate                         = ctptyRecoveryRate
    let _invstDTS                                  = invstDTS
    let _invstRecoveryRate                         = invstRecoveryRate
(*
    Functions
*)
    let _CounterpartyAdjSwapEngine                 = cell (fun () -> new CounterpartyAdjSwapEngine (discountCurve.Value, blackVol.Value, ctptyDTS.Value, ctptyRecoveryRate.Value, invstDTS.Value, invstRecoveryRate.Value))
    do this.Bind(_CounterpartyAdjSwapEngine)

(* 
    Externally visible/bindable properties
*)
    member this.discountCurve                      = _discountCurve 
    member this.blackVol                           = _blackVol 
    member this.ctptyDTS                           = _ctptyDTS 
    member this.ctptyRecoveryRate                  = _ctptyRecoveryRate 
    member this.invstDTS                           = _invstDTS 
    member this.invstRecoveryRate                  = _invstRecoveryRate 
(* <summary>
  Bilateral (CVA and DVA) default adjusted vanilla swap pricing engine. Collateral is not considered. No wrong way risk is considered (rates and counterparty default are uncorrelated). Based on: Sorensen,  E.H.  and  Bollier,  T.F.,  Pricing  swap  default risk. Financial Analysts Journal, 1994, 50, 23–33 Also see sect. II-5 in: Risk Neutral Pricing of Counterparty Risk D. Brigo, M. Masetti, 2004 or in sections 3 and 4 of "A Formula for Interest Rate Swaps Valuation under Counterparty Risk in presence of Netting Agreements" D. Brigo and M. Masetti; May 4, 2005  to do: Compute fair rate through iteration instead of the current approximation . to do: write Issuer based constructors (event type) to do: Check consistency between option engine discount and the one given
! Creates the engine from an arbitrary swaption engine. If the investor default model is not given a default free one is assumed.
@param discountCurve Used in pricing.
@param swaptionEngine Determines the volatility and thus the exposure model.
@param ctptyDTS Counterparty default curve.
@param ctptyRecoveryRate Counterparty recovey rate.
@param invstDTS Investor (swap holder) default curve.
@param invstRecoveryRate Investor recovery rate.
  </summary> *)
[<AutoSerializable(true)>]
type CounterpartyAdjSwapEngineModel2
    ( discountCurve                                : ICell<Handle<YieldTermStructure>>
    , swaptionEngine                               : ICell<Handle<IPricingEngine>>
    , ctptyDTS                                     : ICell<Handle<DefaultProbabilityTermStructure>>
    , ctptyRecoveryRate                            : ICell<double>
    , invstDTS                                     : ICell<Handle<DefaultProbabilityTermStructure>>
    , invstRecoveryRate                            : ICell<double>
    ) as this =

    inherit Model<CounterpartyAdjSwapEngine> ()
(*
    Parameters
*)
    let _discountCurve                             = discountCurve
    let _swaptionEngine                            = swaptionEngine
    let _ctptyDTS                                  = ctptyDTS
    let _ctptyRecoveryRate                         = ctptyRecoveryRate
    let _invstDTS                                  = invstDTS
    let _invstRecoveryRate                         = invstRecoveryRate
(*
    Functions
*)
    let _CounterpartyAdjSwapEngine                 = cell (fun () -> new CounterpartyAdjSwapEngine (discountCurve.Value, swaptionEngine.Value, ctptyDTS.Value, ctptyRecoveryRate.Value, invstDTS.Value, invstRecoveryRate.Value))
    do this.Bind(_CounterpartyAdjSwapEngine)

(* 
    Externally visible/bindable properties
*)
    member this.discountCurve                      = _discountCurve 
    member this.swaptionEngine                     = _swaptionEngine 
    member this.ctptyDTS                           = _ctptyDTS 
    member this.ctptyRecoveryRate                  = _ctptyRecoveryRate 
    member this.invstDTS                           = _invstDTS 
    member this.invstRecoveryRate                  = _invstRecoveryRate 
