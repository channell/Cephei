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
type DiscretizedSwapModel
    ( args                                         : ICell<VanillaSwap.Arguments>
    , referenceDate                                : ICell<Date>
    , dayCounter                                   : ICell<DayCounter>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<DiscretizedSwap> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _args                                      = args
    let _referenceDate                             = referenceDate
    let _dayCounter                                = dayCounter
(*
    Functions
*)
    let mutable
        _DiscretizedSwap                           = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new DiscretizedSwap (args.Value, referenceDate.Value, dayCounter.Value))))
    let _mandatoryTimes                            = triv _DiscretizedSwap (fun () -> (curryEvaluationDate _evaluationDate _DiscretizedSwap).Value.mandatoryTimes())
    let _reset                                     (size : ICell<int>)   
                                                   = triv _DiscretizedSwap (fun () -> (curryEvaluationDate _evaluationDate _DiscretizedSwap).Value.reset(size.Value)
                                                                                      _DiscretizedSwap.Value)
    let _adjustValues                              = triv _DiscretizedSwap (fun () -> (curryEvaluationDate _evaluationDate _DiscretizedSwap).Value.adjustValues()
                                                                                      _DiscretizedSwap.Value)
    let _initialize                                (Method : ICell<Lattice>) (t : ICell<double>)   
                                                   = triv _DiscretizedSwap (fun () -> (curryEvaluationDate _evaluationDate _DiscretizedSwap).Value.initialize(Method.Value, t.Value)
                                                                                      _DiscretizedSwap.Value)
    let _method                                    = triv _DiscretizedSwap (fun () -> (curryEvaluationDate _evaluationDate _DiscretizedSwap).Value.METHOD())
    let _partialRollback                           (To : ICell<double>)   
                                                   = triv _DiscretizedSwap (fun () -> (curryEvaluationDate _evaluationDate _DiscretizedSwap).Value.partialRollback(To.Value)
                                                                                      _DiscretizedSwap.Value)
    let _postAdjustValues                          = triv _DiscretizedSwap (fun () -> (curryEvaluationDate _evaluationDate _DiscretizedSwap).Value.postAdjustValues()
                                                                                      _DiscretizedSwap.Value)
    let _preAdjustValues                           = triv _DiscretizedSwap (fun () -> (curryEvaluationDate _evaluationDate _DiscretizedSwap).Value.preAdjustValues()
                                                                                      _DiscretizedSwap.Value)
    let _presentValue                              = triv _DiscretizedSwap (fun () -> (curryEvaluationDate _evaluationDate _DiscretizedSwap).Value.presentValue())
    let _rollback                                  (To : ICell<double>)   
                                                   = triv _DiscretizedSwap (fun () -> (curryEvaluationDate _evaluationDate _DiscretizedSwap).Value.rollback(To.Value)
                                                                                      _DiscretizedSwap.Value)
    let _setTime                                   (t : ICell<double>)   
                                                   = triv _DiscretizedSwap (fun () -> (curryEvaluationDate _evaluationDate _DiscretizedSwap).Value.setTime(t.Value)
                                                                                      _DiscretizedSwap.Value)
    let _setValues                                 (v : ICell<Vector>)   
                                                   = triv _DiscretizedSwap (fun () -> (curryEvaluationDate _evaluationDate _DiscretizedSwap).Value.setValues(v.Value)
                                                                                      _DiscretizedSwap.Value)
    let _time                                      = triv _DiscretizedSwap (fun () -> (curryEvaluationDate _evaluationDate _DiscretizedSwap).Value.time())
    let _values                                    = triv _DiscretizedSwap (fun () -> (curryEvaluationDate _evaluationDate _DiscretizedSwap).Value.values())
    do this.Bind(_DiscretizedSwap)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new DiscretizedSwapModel(null,null,null,null)
    member internal this.Inject v = _DiscretizedSwap <- v
    static member Cast (p : ICell<DiscretizedSwap>) = 
        if p :? DiscretizedSwapModel then 
            p :?> DiscretizedSwapModel
        else
            let o = new DiscretizedSwapModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.args                               = _args 
    member this.referenceDate                      = _referenceDate 
    member this.dayCounter                         = _dayCounter 
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
