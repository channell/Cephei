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
type DiscretizedSwaptionModel
    ( args                                         : ICell<Swaption.Arguments>
    , referenceDate                                : ICell<Date>
    , dayCounter                                   : ICell<DayCounter>
    ) as this =

    inherit Model<DiscretizedSwaption> ()
(*
    Parameters
*)
    let _args                                      = args
    let _referenceDate                             = referenceDate
    let _dayCounter                                = dayCounter
(*
    Functions
*)
    let mutable
        _DiscretizedSwaption                       = make (fun () -> new DiscretizedSwaption (args.Value, referenceDate.Value, dayCounter.Value))
    let _reset                                     (size : ICell<int>)   
                                                   = triv _DiscretizedSwaption (fun () -> _DiscretizedSwaption.Value.reset(size.Value)
                                                                                          _DiscretizedSwaption.Value)
    let _withinNextWeek                            (d1 : ICell<Date>) (d2 : ICell<Date>)   
                                                   = triv _DiscretizedSwaption (fun () -> _DiscretizedSwaption.Value.withinNextWeek(d1.Value, d2.Value))
    let _withinPreviousWeek                        (d1 : ICell<Date>) (d2 : ICell<Date>)   
                                                   = triv _DiscretizedSwaption (fun () -> _DiscretizedSwaption.Value.withinPreviousWeek(d1.Value, d2.Value))
    let _mandatoryTimes                            = triv _DiscretizedSwaption (fun () -> _DiscretizedSwaption.Value.mandatoryTimes())
    let _adjustValues                              = triv _DiscretizedSwaption (fun () -> _DiscretizedSwaption.Value.adjustValues()
                                                                                          _DiscretizedSwaption.Value)
    let _initialize                                (Method : ICell<Lattice>) (t : ICell<double>)   
                                                   = triv _DiscretizedSwaption (fun () -> _DiscretizedSwaption.Value.initialize(Method.Value, t.Value)
                                                                                          _DiscretizedSwaption.Value)
    let _method                                    = triv _DiscretizedSwaption (fun () -> _DiscretizedSwaption.Value.METHOD())
    let _partialRollback                           (To : ICell<double>)   
                                                   = triv _DiscretizedSwaption (fun () -> _DiscretizedSwaption.Value.partialRollback(To.Value)
                                                                                          _DiscretizedSwaption.Value)
    let _postAdjustValues                          = triv _DiscretizedSwaption (fun () -> _DiscretizedSwaption.Value.postAdjustValues()
                                                                                          _DiscretizedSwaption.Value)
    let _preAdjustValues                           = triv _DiscretizedSwaption (fun () -> _DiscretizedSwaption.Value.preAdjustValues()
                                                                                          _DiscretizedSwaption.Value)
    let _presentValue                              = triv _DiscretizedSwaption (fun () -> _DiscretizedSwaption.Value.presentValue())
    let _rollback                                  (To : ICell<double>)   
                                                   = triv _DiscretizedSwaption (fun () -> _DiscretizedSwaption.Value.rollback(To.Value)
                                                                                          _DiscretizedSwaption.Value)
    let _setTime                                   (t : ICell<double>)   
                                                   = triv _DiscretizedSwaption (fun () -> _DiscretizedSwaption.Value.setTime(t.Value)
                                                                                          _DiscretizedSwaption.Value)
    let _setValues                                 (v : ICell<Vector>)   
                                                   = triv _DiscretizedSwaption (fun () -> _DiscretizedSwaption.Value.setValues(v.Value)
                                                                                          _DiscretizedSwaption.Value)
    let _time                                      = triv _DiscretizedSwaption (fun () -> _DiscretizedSwaption.Value.time())
    let _values                                    = triv _DiscretizedSwaption (fun () -> _DiscretizedSwaption.Value.values())
    do this.Bind(_DiscretizedSwaption)
(* 
    casting 
*)
    internal new () = new DiscretizedSwaptionModel(null,null,null)
    member internal this.Inject v = _DiscretizedSwaption <- v
    static member Cast (p : ICell<DiscretizedSwaption>) = 
        if p :? DiscretizedSwaptionModel then 
            p :?> DiscretizedSwaptionModel
        else
            let o = new DiscretizedSwaptionModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.args                               = _args 
    member this.referenceDate                      = _referenceDate 
    member this.dayCounter                         = _dayCounter 
    member this.Reset                              size   
                                                   = _reset size 
    member this.WithinNextWeek                     d1 d2   
                                                   = _withinNextWeek d1 d2 
    member this.WithinPreviousWeek                 d1 d2   
                                                   = _withinPreviousWeek d1 d2 
    member this.MandatoryTimes                     = _mandatoryTimes
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
