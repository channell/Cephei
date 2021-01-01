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
  Useful discretized discount bond asset
Missing Constructor
  </summary> *)
[<AutoSerializable(true)>]
type DiscretizedDiscountBondModel
    ( evaluationDate                               : ICell<Date>
    ) as this =
    inherit Model<DiscretizedDiscountBond> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
(*
    Functions
*)
    let mutable
        _DiscretizedDiscountBond                   = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new DiscretizedDiscountBond ())))
    let _mandatoryTimes                            = triv _DiscretizedDiscountBond (fun () -> (curryEvaluationDate _evaluationDate _DiscretizedDiscountBond).Value.mandatoryTimes())
    let _reset                                     (size : ICell<int>)   
                                                   = triv _DiscretizedDiscountBond (fun () -> (curryEvaluationDate _evaluationDate _DiscretizedDiscountBond).Value.reset(size.Value)
                                                                                              _DiscretizedDiscountBond.Value)
    let _adjustValues                              = triv _DiscretizedDiscountBond (fun () -> (curryEvaluationDate _evaluationDate _DiscretizedDiscountBond).Value.adjustValues()
                                                                                              _DiscretizedDiscountBond.Value)
    let _initialize                                (Method : ICell<Lattice>) (t : ICell<double>)   
                                                   = triv _DiscretizedDiscountBond (fun () -> (curryEvaluationDate _evaluationDate _DiscretizedDiscountBond).Value.initialize(Method.Value, t.Value)
                                                                                              _DiscretizedDiscountBond.Value)
    let _method                                    = triv _DiscretizedDiscountBond (fun () -> (curryEvaluationDate _evaluationDate _DiscretizedDiscountBond).Value.METHOD())
    let _partialRollback                           (To : ICell<double>)   
                                                   = triv _DiscretizedDiscountBond (fun () -> (curryEvaluationDate _evaluationDate _DiscretizedDiscountBond).Value.partialRollback(To.Value)
                                                                                              _DiscretizedDiscountBond.Value)
    let _postAdjustValues                          = triv _DiscretizedDiscountBond (fun () -> (curryEvaluationDate _evaluationDate _DiscretizedDiscountBond).Value.postAdjustValues()
                                                                                              _DiscretizedDiscountBond.Value)
    let _preAdjustValues                           = triv _DiscretizedDiscountBond (fun () -> (curryEvaluationDate _evaluationDate _DiscretizedDiscountBond).Value.preAdjustValues()
                                                                                              _DiscretizedDiscountBond.Value)
    let _presentValue                              = triv _DiscretizedDiscountBond (fun () -> (curryEvaluationDate _evaluationDate _DiscretizedDiscountBond).Value.presentValue())
    let _rollback                                  (To : ICell<double>)   
                                                   = triv _DiscretizedDiscountBond (fun () -> (curryEvaluationDate _evaluationDate _DiscretizedDiscountBond).Value.rollback(To.Value)
                                                                                              _DiscretizedDiscountBond.Value)
    let _setTime                                   (t : ICell<double>)   
                                                   = triv _DiscretizedDiscountBond (fun () -> (curryEvaluationDate _evaluationDate _DiscretizedDiscountBond).Value.setTime(t.Value)
                                                                                              _DiscretizedDiscountBond.Value)
    let _setValues                                 (v : ICell<Vector>)   
                                                   = triv _DiscretizedDiscountBond (fun () -> (curryEvaluationDate _evaluationDate _DiscretizedDiscountBond).Value.setValues(v.Value)
                                                                                              _DiscretizedDiscountBond.Value)
    let _time                                      = triv _DiscretizedDiscountBond (fun () -> (curryEvaluationDate _evaluationDate _DiscretizedDiscountBond).Value.time())
    let _values                                    = triv _DiscretizedDiscountBond (fun () -> (curryEvaluationDate _evaluationDate _DiscretizedDiscountBond).Value.values())
    do this.Bind(_DiscretizedDiscountBond)
(* 
    casting 
*)
    
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new DiscretizedDiscountBondModel(null)
    member internal this.Inject v = _DiscretizedDiscountBond <- v
    static member Cast (p : ICell<DiscretizedDiscountBond>) = 
        if p :? DiscretizedDiscountBondModel then 
            p :?> DiscretizedDiscountBondModel
        else
            let o = new DiscretizedDiscountBondModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.MandatoryTimes                     = _mandatoryTimes
    member this.Reset                              size   
                                                   = _reset size 
    member this.AdjustValues                       = _adjustValues
    member this.Initialize                         Method t   
                                                   = _initialize Method t 
    member this.Method                             = _method
    member this.PartialRollback                    To   
                                                   = _partialRollback To 
    member this.PostAdjustValues                   = _postAdjustValues
    member this.PreAdjustValues                    = _preAdjustValues
    member this.PresentValue                       = _presentValue
    member this.Rollback                           To   
                                                   = _rollback To 
    member this.SetTime                            t   
                                                   = _setTime t 
    member this.SetValues                          v   
                                                   = _setValues v 
    member this.Time                               = _time
    member this.Values                             = _values
