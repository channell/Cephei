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


  </summary> *)
[<AutoSerializable(true)>]
type FloatingLoanModel
    ( Type                                         : ICell<Loan.Type>
    , nominal                                      : ICell<double>
    , floatingSchedule                             : ICell<Schedule>
    , floatingSpread                               : ICell<double>
    , floatingDayCount                             : ICell<DayCounter>
    , principalSchedule                            : ICell<Schedule>
    , paymentConvention                            : ICell<Nullable<BusinessDayConvention>>
    , index                                        : ICell<IborIndex>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FloatingLoan> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _nominal                                   = nominal
    let _floatingSchedule                          = floatingSchedule
    let _floatingSpread                            = floatingSpread
    let _floatingDayCount                          = floatingDayCount
    let _principalSchedule                         = principalSchedule
    let _paymentConvention                         = paymentConvention
    let _index                                     = index
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _FloatingLoan                              = cell (fun () -> withEngine pricingEngine (new FloatingLoan (Type.Value, nominal.Value, floatingSchedule.Value, floatingSpread.Value, floatingDayCount.Value, principalSchedule.Value, paymentConvention.Value, index.Value)))
    let _floatingLeg                               = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingLoan).floatingLeg())
    let _principalLeg                              = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingLoan).principalLeg())
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingLoan).isExpired())
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingLoan).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingLoan).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingLoan).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingLoan).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingLoan).setPricingEngine(e.Value)
                                                                     _FloatingLoan.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingLoan).valuationDate())
    do this.Bind(_FloatingLoan)
(* 
    casting 
*)
    internal new () = FloatingLoanModel(null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _FloatingLoan.Value <- v
    static member Cast (p : ICell<FloatingLoan>) = 
        if p :? FloatingLoanModel then 
            p :?> FloatingLoanModel
        else
            let o = new FloatingLoanModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.nominal                            = _nominal 
    member this.floatingSchedule                   = _floatingSchedule 
    member this.floatingSpread                     = _floatingSpread 
    member this.floatingDayCount                   = _floatingDayCount 
    member this.principalSchedule                  = _principalSchedule 
    member this.paymentConvention                  = _paymentConvention 
    member this.index                              = _index 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.FloatingLeg                        = _floatingLeg
    member this.PrincipalLeg                       = _principalLeg
    member this.IsExpired                          = _isExpired
    member this.CASH                               = _CASH
    member this.ErrorEstimate                      = _errorEstimate
    member this.NPV                                = _NPV
    member this.Result                             tag   
                                                   = _result tag 
    member this.SetPricingEngine                   e   
                                                   = _setPricingEngine e 
    member this.ValuationDate                      = _valuationDate
