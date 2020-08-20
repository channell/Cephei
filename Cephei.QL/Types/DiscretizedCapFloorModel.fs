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
type DiscretizedCapFloorModel
    ( args                                         : ICell<CapFloor.Arguments>
    , referenceDate                                : ICell<Date>
    , dayCounter                                   : ICell<DayCounter>
    ) as this =

    inherit Model<DiscretizedCapFloor> ()
(*
    Parameters
*)
    let _args                                      = args
    let _referenceDate                             = referenceDate
    let _dayCounter                                = dayCounter
(*
    Functions
*)
    let _DiscretizedCapFloor                       = cell (fun () -> new DiscretizedCapFloor (args.Value, referenceDate.Value, dayCounter.Value))
    let _mandatoryTimes                            = cell (fun () -> _DiscretizedCapFloor.Value.mandatoryTimes())
    let _reset                                     (size : ICell<int>)   
                                                   = cell (fun () -> _DiscretizedCapFloor.Value.reset(size.Value)
                                                                     _DiscretizedCapFloor.Value)
    let _adjustValues                              = cell (fun () -> _DiscretizedCapFloor.Value.adjustValues()
                                                                     _DiscretizedCapFloor.Value)
    let _initialize                                (Method : ICell<Lattice>) (t : ICell<double>)   
                                                   = cell (fun () -> _DiscretizedCapFloor.Value.initialize(Method.Value, t.Value)
                                                                     _DiscretizedCapFloor.Value)
    let _method                                    = cell (fun () -> _DiscretizedCapFloor.Value.METHOD())
    let _partialRollback                           (To : ICell<double>)   
                                                   = cell (fun () -> _DiscretizedCapFloor.Value.partialRollback(To.Value)
                                                                     _DiscretizedCapFloor.Value)
    let _postAdjustValues                          = cell (fun () -> _DiscretizedCapFloor.Value.postAdjustValues()
                                                                     _DiscretizedCapFloor.Value)
    let _preAdjustValues                           = cell (fun () -> _DiscretizedCapFloor.Value.preAdjustValues()
                                                                     _DiscretizedCapFloor.Value)
    let _presentValue                              = cell (fun () -> _DiscretizedCapFloor.Value.presentValue())
    let _rollback                                  (To : ICell<double>)   
                                                   = cell (fun () -> _DiscretizedCapFloor.Value.rollback(To.Value)
                                                                     _DiscretizedCapFloor.Value)
    let _setTime                                   (t : ICell<double>)   
                                                   = cell (fun () -> _DiscretizedCapFloor.Value.setTime(t.Value)
                                                                     _DiscretizedCapFloor.Value)
    let _setValues                                 (v : ICell<Vector>)   
                                                   = cell (fun () -> _DiscretizedCapFloor.Value.setValues(v.Value)
                                                                     _DiscretizedCapFloor.Value)
    let _time                                      = cell (fun () -> _DiscretizedCapFloor.Value.time())
    let _values                                    = cell (fun () -> _DiscretizedCapFloor.Value.values())
    do this.Bind(_DiscretizedCapFloor)

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
