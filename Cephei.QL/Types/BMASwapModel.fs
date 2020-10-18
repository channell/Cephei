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
  swap paying Libor against BMA coupons

  </summary> *)
[<AutoSerializable(true)>]
type BMASwapModel
    ( Type                                         : ICell<BMASwap.Type>
    , nominal                                      : ICell<double>
    , liborSchedule                                : ICell<Schedule>
    , liborFraction                                : ICell<double>
    , liborSpread                                  : ICell<double>
    , liborIndex                                   : ICell<IborIndex>
    , liborDayCount                                : ICell<DayCounter>
    , bmaSchedule                                  : ICell<Schedule>
    , bmaIndex                                     : ICell<BMAIndex>
    , bmaDayCount                                  : ICell<DayCounter>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<BMASwap> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _nominal                                   = nominal
    let _liborSchedule                             = liborSchedule
    let _liborFraction                             = liborFraction
    let _liborSpread                               = liborSpread
    let _liborIndex                                = liborIndex
    let _liborDayCount                             = liborDayCount
    let _bmaSchedule                               = bmaSchedule
    let _bmaIndex                                  = bmaIndex
    let _bmaDayCount                               = bmaDayCount
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _BMASwap                                   = cell (fun () -> withEngine pricingEngine (new BMASwap (Type.Value, nominal.Value, liborSchedule.Value, liborFraction.Value, liborSpread.Value, liborIndex.Value, liborDayCount.Value, bmaSchedule.Value, bmaIndex.Value, bmaDayCount.Value)))
    let _bmaLeg                                    = triv (fun () -> (withEvaluationDate _evaluationDate _BMASwap).bmaLeg())
    let _bmaLegBPS                                 = triv (fun () -> (withEvaluationDate _evaluationDate _BMASwap).bmaLegBPS())
    let _bmaLegNPV                                 = triv (fun () -> (withEvaluationDate _evaluationDate _BMASwap).bmaLegNPV())
    let _fairLiborFraction                         = triv (fun () -> (withEvaluationDate _evaluationDate _BMASwap).fairLiborFraction())
    let _fairLiborSpread                           = triv (fun () -> (withEvaluationDate _evaluationDate _BMASwap).fairLiborSpread())
    let _liborFraction                             = triv (fun () -> (withEvaluationDate _evaluationDate _BMASwap).liborFraction())
    let _liborLeg                                  = triv (fun () -> (withEvaluationDate _evaluationDate _BMASwap).liborLeg())
    let _liborLegBPS                               = triv (fun () -> (withEvaluationDate _evaluationDate _BMASwap).liborLegBPS())
    let _liborLegNPV                               = triv (fun () -> (withEvaluationDate _evaluationDate _BMASwap).liborLegNPV())
    let _liborSpread                               = triv (fun () -> (withEvaluationDate _evaluationDate _BMASwap).liborSpread())
    let _nominal                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BMASwap).nominal())
    let _type                                      = triv (fun () -> (withEvaluationDate _evaluationDate _BMASwap).TYPE())
    let _endDiscounts                              (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BMASwap).endDiscounts(j.Value))
    let _engine                                    = triv (fun () -> (withEvaluationDate _evaluationDate _BMASwap).engine)
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _BMASwap).isExpired())
    let _leg                                       (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BMASwap).leg(j.Value))
    let _legBPS                                    (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BMASwap).legBPS(j.Value))
    let _legNPV                                    (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BMASwap).legNPV(j.Value))
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _BMASwap).maturityDate())
    let _npvDateDiscount                           = triv (fun () -> (withEvaluationDate _evaluationDate _BMASwap).npvDateDiscount())
    let _payer                                     (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BMASwap).payer(j.Value))
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _BMASwap).startDate())
    let _startDiscounts                            (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BMASwap).startDiscounts(j.Value))
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _BMASwap).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _BMASwap).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _BMASwap).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BMASwap).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BMASwap).setPricingEngine(e.Value)
                                                                     _BMASwap.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _BMASwap).valuationDate())
    do this.Bind(_BMASwap)
(* 
    casting 
*)
    internal new () = new BMASwapModel(null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _BMASwap <- v
    static member Cast (p : ICell<BMASwap>) = 
        if p :? BMASwapModel then 
            p :?> BMASwapModel
        else
            let o = new BMASwapModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.nominal                            = _nominal 
    member this.liborSchedule                      = _liborSchedule 
    member this.liborFraction                      = _liborFraction 
    member this.liborSpread                        = _liborSpread 
    member this.liborIndex                         = _liborIndex 
    member this.liborDayCount                      = _liborDayCount 
    member this.bmaSchedule                        = _bmaSchedule 
    member this.bmaIndex                           = _bmaIndex 
    member this.bmaDayCount                        = _bmaDayCount 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.BmaLeg                             = _bmaLeg
    member this.BmaLegBPS                          = _bmaLegBPS
    member this.BmaLegNPV                          = _bmaLegNPV
    member this.FairLiborFraction                  = _fairLiborFraction
    member this.FairLiborSpread                    = _fairLiborSpread
    member this.LiborFraction                      = _liborFraction
    member this.LiborLeg                           = _liborLeg
    member this.LiborLegBPS                        = _liborLegBPS
    member this.LiborLegNPV                        = _liborLegNPV
    member this.LiborSpread                        = _liborSpread
    member this.Nominal                            = _nominal
    member this.Type1                              = _type
    member this.EndDiscounts                       j   
                                                   = _endDiscounts j 
    member this.Engine                             = _engine
    member this.IsExpired                          = _isExpired
    member this.Leg                                j   
                                                   = _leg j 
    member this.LegBPS                             j   
                                                   = _legBPS j 
    member this.LegNPV                             j   
                                                   = _legNPV j 
    member this.MaturityDate                       = _maturityDate
    member this.NpvDateDiscount                    = _npvDateDiscount
    member this.Payer                              j   
                                                   = _payer j 
    member this.StartDate                          = _startDate
    member this.StartDiscounts                     j   
                                                   = _startDiscounts j 
    member this.CASH                               = _CASH
    member this.ErrorEstimate                      = _errorEstimate
    member this.NPV                                = _NPV
    member this.Result                             tag   
                                                   = _result tag 
    member this.SetPricingEngine                   e   
                                                   = _setPricingEngine e 
    member this.ValuationDate                      = _valuationDate
