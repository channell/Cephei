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
  Quanto term structure for modelling quanto effect in option pricing.  This term structure will remain linked to the original structures, i.e., any changes in the latters will be reflected in this structure as well.

  </summary> *)
[<AutoSerializable(true)>]
type QuantoTermStructureModel
    ( underlyingDividendTS                         : ICell<Handle<YieldTermStructure>>
    , riskFreeTS                                   : ICell<Handle<YieldTermStructure>>
    , foreignRiskFreeTS                            : ICell<Handle<YieldTermStructure>>
    , underlyingBlackVolTS                         : ICell<Handle<BlackVolTermStructure>>
    , strike                                       : ICell<double>
    , exchRateBlackVolTS                           : ICell<Handle<BlackVolTermStructure>>
    , exchRateATMlevel                             : ICell<double>
    , underlyingExchRateCorrelation                : ICell<double>
    ) as this =

    inherit Model<QuantoTermStructure> ()
(*
    Parameters
*)
    let _underlyingDividendTS                      = underlyingDividendTS
    let _riskFreeTS                                = riskFreeTS
    let _foreignRiskFreeTS                         = foreignRiskFreeTS
    let _underlyingBlackVolTS                      = underlyingBlackVolTS
    let _strike                                    = strike
    let _exchRateBlackVolTS                        = exchRateBlackVolTS
    let _exchRateATMlevel                          = exchRateATMlevel
    let _underlyingExchRateCorrelation             = underlyingExchRateCorrelation
(*
    Functions
*)
    let _QuantoTermStructure                       = cell (fun () -> new QuantoTermStructure (underlyingDividendTS.Value, riskFreeTS.Value, foreignRiskFreeTS.Value, underlyingBlackVolTS.Value, strike.Value, exchRateBlackVolTS.Value, exchRateATMlevel.Value, underlyingExchRateCorrelation.Value))
    let _calendar                                  = triv (fun () -> _QuantoTermStructure.Value.calendar())
    let _dayCounter                                = triv (fun () -> _QuantoTermStructure.Value.dayCounter())
    let _maxDate                                   = triv (fun () -> _QuantoTermStructure.Value.maxDate())
    let _referenceDate                             = triv (fun () -> _QuantoTermStructure.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _QuantoTermStructure.Value.settlementDays())
    do this.Bind(_QuantoTermStructure)
(* 
    casting 
*)
    internal new () = new QuantoTermStructureModel(null,null,null,null,null,null,null,null)
    member internal this.Inject v = _QuantoTermStructure.Value <- v
    static member Cast (p : ICell<QuantoTermStructure>) = 
        if p :? QuantoTermStructureModel then 
            p :?> QuantoTermStructureModel
        else
            let o = new QuantoTermStructureModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.underlyingDividendTS               = _underlyingDividendTS 
    member this.riskFreeTS                         = _riskFreeTS 
    member this.foreignRiskFreeTS                  = _foreignRiskFreeTS 
    member this.underlyingBlackVolTS               = _underlyingBlackVolTS 
    member this.strike                             = _strike 
    member this.exchRateBlackVolTS                 = _exchRateBlackVolTS 
    member this.exchRateATMlevel                   = _exchRateATMlevel 
    member this.underlyingExchRateCorrelation      = _underlyingExchRateCorrelation 
    member this.Calendar                           = _calendar
    member this.DayCounter                         = _dayCounter
    member this.MaxDate                            = _maxDate
    member this.ReferenceDate                      = _referenceDate
    member this.SettlementDays                     = _settlementDays
