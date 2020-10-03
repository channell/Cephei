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
  it is advised that derived classes take care of creating and initializing themselves an instance of the underlying.

  </summary> *)
[<AutoSerializable(true)>]
type DiscretizedOptionModel
    ( underlying                                   : ICell<DiscretizedAsset>
    , exerciseType                                 : ICell<Exercise.Type>
    , exerciseTimes                                : ICell<Generic.List<double>>
    ) as this =

    inherit Model<DiscretizedOption> ()
(*
    Parameters
*)
    let _underlying                                = underlying
    let _exerciseType                              = exerciseType
    let _exerciseTimes                             = exerciseTimes
(*
    Functions
*)
    let _DiscretizedOption                         = cell (fun () -> new DiscretizedOption (underlying.Value, exerciseType.Value, exerciseTimes.Value))
    let _mandatoryTimes                            = triv (fun () -> _DiscretizedOption.Value.mandatoryTimes())
    let _reset                                     (size : ICell<int>)   
                                                   = triv (fun () -> _DiscretizedOption.Value.reset(size.Value)
                                                                     _DiscretizedOption.Value)
    let _adjustValues                              = triv (fun () -> _DiscretizedOption.Value.adjustValues()
                                                                     _DiscretizedOption.Value)
    let _initialize                                (Method : ICell<Lattice>) (t : ICell<double>)   
                                                   = triv (fun () -> _DiscretizedOption.Value.initialize(Method.Value, t.Value)
                                                                     _DiscretizedOption.Value)
    let _method                                    = triv (fun () -> _DiscretizedOption.Value.METHOD())
    let _partialRollback                           (To : ICell<double>)   
                                                   = triv (fun () -> _DiscretizedOption.Value.partialRollback(To.Value)
                                                                     _DiscretizedOption.Value)
    let _postAdjustValues                          = triv (fun () -> _DiscretizedOption.Value.postAdjustValues()
                                                                     _DiscretizedOption.Value)
    let _preAdjustValues                           = triv (fun () -> _DiscretizedOption.Value.preAdjustValues()
                                                                     _DiscretizedOption.Value)
    let _presentValue                              = triv (fun () -> _DiscretizedOption.Value.presentValue())
    let _rollback                                  (To : ICell<double>)   
                                                   = triv (fun () -> _DiscretizedOption.Value.rollback(To.Value)
                                                                     _DiscretizedOption.Value)
    let _setTime                                   (t : ICell<double>)   
                                                   = triv (fun () -> _DiscretizedOption.Value.setTime(t.Value)
                                                                     _DiscretizedOption.Value)
    let _setValues                                 (v : ICell<Vector>)   
                                                   = triv (fun () -> _DiscretizedOption.Value.setValues(v.Value)
                                                                     _DiscretizedOption.Value)
    let _time                                      = triv (fun () -> _DiscretizedOption.Value.time())
    let _values                                    = triv (fun () -> _DiscretizedOption.Value.values())
    do this.Bind(_DiscretizedOption)
(* 
    casting 
*)
    internal new () = DiscretizedOptionModel(null,null,null)
    member internal this.Inject v = _DiscretizedOption.Value <- v
    static member Cast (p : ICell<DiscretizedOption>) = 
        if p :? DiscretizedOptionModel then 
            p :?> DiscretizedOptionModel
        else
            let o = new DiscretizedOptionModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.underlying                         = _underlying 
    member this.exerciseType                       = _exerciseType 
    member this.exerciseTimes                      = _exerciseTimes 
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
