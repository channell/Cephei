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
  Quoted as a fixed strike rate K  Payoff: P_n(0,T) (N [(1+K)^{T}-1] - N -1 0) where T is the maturity time, P_n(0,t) is the nominal discount factor at time t N is the notional, and I(t) is the inflation index value at time t  Inflation is generally available on every day, including holidays and weekends.  Hence there is a variable to state whether the observe/fix dates for inflation are adjusted or not.  The default is not to adjust.  N.B. a cpi cap or floor is an option, not a cap or floor on a coupon. Thus this is very similar to a ZCIIS and has a single flow, this is as usual for cpi because it is cumulative up to option maturity from base date.  We do not inherit from Option, although this would be reasonable, because we do not have that degree of generality.

  </summary> *)
[<AutoSerializable(true)>]
type CPICapFloorModel
    ( Type                                         : ICell<Option.Type>
    , nominal                                      : ICell<double>
    , startDate                                    : ICell<Date>
    , baseCPI                                      : ICell<double>
    , maturity                                     : ICell<Date>
    , fixCalendar                                  : ICell<Calendar>
    , fixConvention                                : ICell<BusinessDayConvention>
    , payCalendar                                  : ICell<Calendar>
    , payConvention                                : ICell<BusinessDayConvention>
    , strike                                       : ICell<double>
    , infIndex                                     : ICell<Handle<ZeroInflationIndex>>
    , observationLag                               : ICell<Period>
    , observationInterpolation                     : ICell<InterpolationType>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<CPICapFloor> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _nominal                                   = nominal
    let _startDate                                 = startDate
    let _baseCPI                                   = baseCPI
    let _maturity                                  = maturity
    let _fixCalendar                               = fixCalendar
    let _fixConvention                             = fixConvention
    let _payCalendar                               = payCalendar
    let _payConvention                             = payConvention
    let _strike                                    = strike
    let _infIndex                                  = infIndex
    let _observationLag                            = observationLag
    let _observationInterpolation                  = observationInterpolation
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _CPICapFloor                               = cell (fun () -> withEngine pricingEngine (new CPICapFloor (Type.Value, nominal.Value, startDate.Value, baseCPI.Value, maturity.Value, fixCalendar.Value, fixConvention.Value, payCalendar.Value, payConvention.Value, strike.Value, infIndex.Value, observationLag.Value, observationInterpolation.Value)))
    let _fixingDate                                = triv (fun () -> (withEvaluationDate _evaluationDate _CPICapFloor).fixingDate())
    let _inflationIndex                            = triv (fun () -> (withEvaluationDate _evaluationDate _CPICapFloor).inflationIndex())
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _CPICapFloor).isExpired())
    let _nominal                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CPICapFloor).nominal())
    let _observationLag                            = triv (fun () -> (withEvaluationDate _evaluationDate _CPICapFloor).observationLag())
    let _payDate                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CPICapFloor).payDate())
    let _strike                                    = triv (fun () -> (withEvaluationDate _evaluationDate _CPICapFloor).strike())
    let _type                                      = triv (fun () -> (withEvaluationDate _evaluationDate _CPICapFloor).TYPE())
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _CPICapFloor).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _CPICapFloor).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _CPICapFloor).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CPICapFloor).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CPICapFloor).setPricingEngine(e.Value)
                                                                     _CPICapFloor.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _CPICapFloor).valuationDate())
    do this.Bind(_CPICapFloor)
(* 
    casting 
*)
    internal new () = new CPICapFloorModel(null,null,null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _CPICapFloor <- v
    static member Cast (p : ICell<CPICapFloor>) = 
        if p :? CPICapFloorModel then 
            p :?> CPICapFloorModel
        else
            let o = new CPICapFloorModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.nominal                            = _nominal 
    member this.startDate                          = _startDate 
    member this.baseCPI                            = _baseCPI 
    member this.maturity                           = _maturity 
    member this.fixCalendar                        = _fixCalendar 
    member this.fixConvention                      = _fixConvention 
    member this.payCalendar                        = _payCalendar 
    member this.payConvention                      = _payConvention 
    member this.strike                             = _strike 
    member this.infIndex                           = _infIndex 
    member this.observationLag                     = _observationLag 
    member this.observationInterpolation           = _observationInterpolation 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.FixingDate                         = _fixingDate
    member this.InflationIndex                     = _inflationIndex
    member this.IsExpired                          = _isExpired
    member this.Nominal                            = _nominal
    member this.ObservationLag                     = _observationLag
    member this.PayDate                            = _payDate
    member this.Strike                             = _strike
    member this.Type1                               = _type
    member this.CASH                               = _CASH
    member this.ErrorEstimate                      = _errorEstimate
    member this.NPV                                = _NPV
    member this.Result                             tag   
                                                   = _result tag 
    member this.SetPricingEngine                   e   
                                                   = _setPricingEngine e 
    member this.ValuationDate                      = _valuationDate
