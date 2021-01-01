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
  if <tt>Settings::includeReferenceDateCashFlows()</tt> is set to <tt>true</tt>, payments occurring at the settlement date of the swap might be included in the NPV and therefore affect the fair-rate and fair-spread calculation. This might not be what you want.  - the correctness of the returned value is tested by checking - that the price of a swap paying the fair fixed rate is null. - that the price of a swap receiving the fair floating-rate spread is null. - that the price of a swap decreases with the paid fixed rate. - that the price of a swap increases with the received floating-rate spread. - the correctness of the returned value is tested by checking it against a known good value.
constructor
  </summary> *)
[<AutoSerializable(true)>]
type VanillaSwapModel
    ( Type                                         : ICell<VanillaSwap.Type>
    , nominal                                      : ICell<double>
    , fixedSchedule                                : ICell<Schedule>
    , fixedRate                                    : ICell<double>
    , fixedDayCount                                : ICell<DayCounter>
    , floatSchedule                                : ICell<Schedule>
    , iborIndex                                    : ICell<IborIndex>
    , spread                                       : ICell<double>
    , floatingDayCount                             : ICell<DayCounter>
    , paymentConvention                            : ICell<Nullable<BusinessDayConvention>>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<VanillaSwap> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _nominal                                   = nominal
    let _fixedSchedule                             = fixedSchedule
    let _fixedRate                                 = fixedRate
    let _fixedDayCount                             = fixedDayCount
    let _floatSchedule                             = floatSchedule
    let _iborIndex                                 = iborIndex
    let _spread                                    = spread
    let _floatingDayCount                          = floatingDayCount
    let _paymentConvention                         = paymentConvention
    let mutable
        _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _VanillaSwap                               = make (fun () -> withEngine pricingEngine evaluationDate (new VanillaSwap (Type.Value, nominal.Value, fixedSchedule.Value, fixedRate.Value, fixedDayCount.Value, floatSchedule.Value, iborIndex.Value, spread.Value, floatingDayCount.Value, paymentConvention.Value)))
    let _fairRate                                  = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).fairRate())
    let _fairSpread                                = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).fairSpread())
    let _fixedDayCount                             = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).fixedDayCount())
    let _fixedLeg                                  = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).fixedLeg())
    let _fixedLegBPS                               = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).fixedLegBPS())
    let _fixedLegNPV                               = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).fixedLegNPV())
    let _fixedRate                                 = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).fixedRate)
    let _fixedSchedule                             = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).fixedSchedule())
    let _floatingDayCount                          = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).floatingDayCount())
    let _floatingLeg                               = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).floatingLeg())
    let _floatingLegBPS                            = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).floatingLegBPS())
    let _floatingLegNPV                            = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).floatingLegNPV())
    let _floatingSchedule                          = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).floatingSchedule())
    let _iborIndex                                 = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).iborIndex())
    let _nominal                                   = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).nominal)
    let _spread                                    = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).spread)
    let _swapType                                  = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).swapType)
    let _endDiscounts                              (j : ICell<int>)   
                                                   = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).endDiscounts(j.Value))
    let _engine                                    = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).engine)
    let _isExpired                                 = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).isExpired())
    let _leg                                       (j : ICell<int>)   
                                                   = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).leg(j.Value))
    let _legBPS                                    (j : ICell<int>)   
                                                   = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).legBPS(j.Value))
    let _legNPV                                    (j : ICell<int>)   
                                                   = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).legNPV(j.Value))
    let _maturityDate                              = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).maturityDate())
    let _npvDateDiscount                           = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).npvDateDiscount())
    let _payer                                     (j : ICell<int>)   
                                                   = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).payer(j.Value))
    let _startDate                                 = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).startDate())
    let _startDiscounts                            (j : ICell<int>)   
                                                   = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).startDiscounts(j.Value))
    let _CASH                                      = cell _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).CASH())
    let _errorEstimate                             = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).errorEstimate())
    let _NPV                                       = cell _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).setPricingEngine(e.Value)
                                                                                  _VanillaSwap.Value)
    let _valuationDate                             = triv _VanillaSwap (fun () -> (withEvaluationDate _evaluationDate _VanillaSwap).valuationDate())
    do this.Bind(_VanillaSwap)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new VanillaSwapModel(null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _VanillaSwap <- v
    static member Cast (p : ICell<VanillaSwap>) = 
        if p :? VanillaSwapModel then 
            p :?> VanillaSwapModel
        else
            let o = new VanillaSwapModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.nominal                            = _nominal 
    member this.fixedSchedule                      = _fixedSchedule 
    member this.fixedRate                          = _fixedRate 
    member this.fixedDayCount                      = _fixedDayCount 
    member this.floatSchedule                      = _floatSchedule 
    member this.iborIndex                          = _iborIndex 
    member this.spread                             = _spread 
    member this.floatingDayCount                   = _floatingDayCount 
    member this.paymentConvention                  = _paymentConvention 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.FairRate                           = _fairRate
    member this.FairSpread                         = _fairSpread
    member this.FixedDayCount                      = _fixedDayCount
    member this.FixedLeg                           = _fixedLeg
    member this.FixedLegBPS                        = _fixedLegBPS
    member this.FixedLegNPV                        = _fixedLegNPV
    member this.FixedRate                          = _fixedRate
    member this.FixedSchedule                      = _fixedSchedule
    member this.FloatingDayCount                   = _floatingDayCount
    member this.FloatingLeg                        = _floatingLeg
    member this.FloatingLegBPS                     = _floatingLegBPS
    member this.FloatingLegNPV                     = _floatingLegNPV
    member this.FloatingSchedule                   = _floatingSchedule
    member this.IborIndex                          = _iborIndex
    member this.Nominal                            = _nominal
    member this.Spread                             = _spread
    member this.SwapType                           = _swapType
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
