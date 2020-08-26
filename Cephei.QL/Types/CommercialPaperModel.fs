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
type CommercialPaperModel
    ( Type                                         : ICell<Loan.Type>
    , nominal                                      : ICell<double>
    , fixedSchedule                                : ICell<Schedule>
    , fixedRate                                    : ICell<double>
    , fixedDayCount                                : ICell<DayCounter>
    , principalSchedule                            : ICell<Schedule>
    , paymentConvention                            : ICell<Nullable<BusinessDayConvention>>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<CommercialPaper> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _nominal                                   = nominal
    let _fixedSchedule                             = fixedSchedule
    let _fixedRate                                 = fixedRate
    let _fixedDayCount                             = fixedDayCount
    let _principalSchedule                         = principalSchedule
    let _paymentConvention                         = paymentConvention
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _CommercialPaper                           = cell (fun () -> withEngine pricingEngine (new CommercialPaper (Type.Value, nominal.Value, fixedSchedule.Value, fixedRate.Value, fixedDayCount.Value, principalSchedule.Value, paymentConvention.Value)))
    let _fixedLeg                                  = triv (fun () -> (withEvaluationDate _evaluationDate _CommercialPaper).fixedLeg())
    let _principalLeg                              = triv (fun () -> (withEvaluationDate _evaluationDate _CommercialPaper).principalLeg())
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _CommercialPaper).isExpired())
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _CommercialPaper).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _CommercialPaper).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _CommercialPaper).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CommercialPaper).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CommercialPaper).setPricingEngine(e.Value)
                                                                     _CommercialPaper.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _CommercialPaper).valuationDate())
    do this.Bind(_CommercialPaper)

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.nominal                            = _nominal 
    member this.fixedSchedule                      = _fixedSchedule 
    member this.fixedRate                          = _fixedRate 
    member this.fixedDayCount                      = _fixedDayCount 
    member this.principalSchedule                  = _principalSchedule 
    member this.paymentConvention                  = _paymentConvention 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.FixedLeg                           = _fixedLeg
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
