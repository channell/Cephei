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
  Base class for options on multiple assets

  </summary> *)
[<AutoSerializable(true)>]
type MultiAssetOptionModel
    ( payoff                                       : ICell<Payoff>
    , exercise                                     : ICell<Exercise>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<MultiAssetOption> ()
(*
    Parameters
*)
    let _payoff                                    = payoff
    let _exercise                                  = exercise
    let mutable
        _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _MultiAssetOption                          = cell (fun () -> withEngine pricingEngine evaluationDate (new MultiAssetOption (payoff.Value, exercise.Value)))
    let _delta                                     = triv (fun () -> (withEvaluationDate _evaluationDate _MultiAssetOption).delta())
    let _dividendRho                               = triv (fun () -> (withEvaluationDate _evaluationDate _MultiAssetOption).dividendRho())
    let _gamma                                     = triv (fun () -> (withEvaluationDate _evaluationDate _MultiAssetOption).gamma())
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _MultiAssetOption).isExpired())
    let _rho                                       = triv (fun () -> (withEvaluationDate _evaluationDate _MultiAssetOption).rho())
    let _theta                                     = triv (fun () -> (withEvaluationDate _evaluationDate _MultiAssetOption).theta())
    let _vega                                      = triv (fun () -> (withEvaluationDate _evaluationDate _MultiAssetOption).vega())
    let _exercise                                  = cell (fun () -> (withEvaluationDate _evaluationDate _MultiAssetOption).exercise())
    let _payoff                                    = cell (fun () -> (withEvaluationDate _evaluationDate _MultiAssetOption).payoff())
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _MultiAssetOption).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _MultiAssetOption).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _MultiAssetOption).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _MultiAssetOption).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _MultiAssetOption).setPricingEngine(e.Value)
                                                                     _MultiAssetOption.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _MultiAssetOption).valuationDate())
    do this.Bind(_MultiAssetOption)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new MultiAssetOptionModel(null,null,null,null)
    member internal this.Inject v = _MultiAssetOption <- v
    static member Cast (p : ICell<MultiAssetOption>) = 
        if p :? MultiAssetOptionModel then 
            p :?> MultiAssetOptionModel
        else
            let o = new MultiAssetOptionModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.payoff                             = _payoff 
    member this.exercise                           = _exercise 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.Delta                              = _delta
    member this.DividendRho                        = _dividendRho
    member this.Gamma                              = _gamma
    member this.IsExpired                          = _isExpired
    member this.Rho                                = _rho
    member this.Theta                              = _theta
    member this.Vega                               = _vega
    member this.Exercise                           = _exercise
    member this.Payoff                             = _payoff
    member this.CASH                               = _CASH
    member this.ErrorEstimate                      = _errorEstimate
    member this.NPV                                = _NPV
    member this.Result                             tag   
                                                   = _result tag 
    member this.SetPricingEngine                   e   
                                                   = _setPricingEngine e 
    member this.ValuationDate                      = _valuationDate
