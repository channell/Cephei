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
type DiscretizedDermanKaniBarrierOptionModel
    ( args                                         : ICell<BarrierOption.Arguments>
    , Process                                      : ICell<StochasticProcess>
    , grid                                         : ICell<TimeGrid>
    ) as this =

    inherit Model<DiscretizedDermanKaniBarrierOption> ()
(*
    Parameters
*)
    let _args                                      = args
    let _Process                                   = Process
    let _grid                                      = grid
(*
    Functions
*)
    let _DiscretizedDermanKaniBarrierOption        = cell (fun () -> new DiscretizedDermanKaniBarrierOption (args.Value, Process.Value, grid.Value))
    let _mandatoryTimes                            = triv (fun () -> _DiscretizedDermanKaniBarrierOption.Value.mandatoryTimes())
    let _reset                                     (size : ICell<int>)   
                                                   = triv (fun () -> _DiscretizedDermanKaniBarrierOption.Value.reset(size.Value)
                                                                     _DiscretizedDermanKaniBarrierOption.Value)
    let _adjustValues                              = triv (fun () -> _DiscretizedDermanKaniBarrierOption.Value.adjustValues()
                                                                     _DiscretizedDermanKaniBarrierOption.Value)
    let _initialize                                (Method : ICell<Lattice>) (t : ICell<double>)   
                                                   = triv (fun () -> _DiscretizedDermanKaniBarrierOption.Value.initialize(Method.Value, t.Value)
                                                                     _DiscretizedDermanKaniBarrierOption.Value)
    let _method                                    = triv (fun () -> _DiscretizedDermanKaniBarrierOption.Value.METHOD())
    let _partialRollback                           (To : ICell<double>)   
                                                   = triv (fun () -> _DiscretizedDermanKaniBarrierOption.Value.partialRollback(To.Value)
                                                                     _DiscretizedDermanKaniBarrierOption.Value)
    let _postAdjustValues                          = triv (fun () -> _DiscretizedDermanKaniBarrierOption.Value.postAdjustValues()
                                                                     _DiscretizedDermanKaniBarrierOption.Value)
    let _preAdjustValues                           = triv (fun () -> _DiscretizedDermanKaniBarrierOption.Value.preAdjustValues()
                                                                     _DiscretizedDermanKaniBarrierOption.Value)
    let _presentValue                              = triv (fun () -> _DiscretizedDermanKaniBarrierOption.Value.presentValue())
    let _rollback                                  (To : ICell<double>)   
                                                   = triv (fun () -> _DiscretizedDermanKaniBarrierOption.Value.rollback(To.Value)
                                                                     _DiscretizedDermanKaniBarrierOption.Value)
    let _setTime                                   (t : ICell<double>)   
                                                   = triv (fun () -> _DiscretizedDermanKaniBarrierOption.Value.setTime(t.Value)
                                                                     _DiscretizedDermanKaniBarrierOption.Value)
    let _setValues                                 (v : ICell<Vector>)   
                                                   = triv (fun () -> _DiscretizedDermanKaniBarrierOption.Value.setValues(v.Value)
                                                                     _DiscretizedDermanKaniBarrierOption.Value)
    let _time                                      = triv (fun () -> _DiscretizedDermanKaniBarrierOption.Value.time())
    let _values                                    = triv (fun () -> _DiscretizedDermanKaniBarrierOption.Value.values())
    do this.Bind(_DiscretizedDermanKaniBarrierOption)

(* 
    Externally visible/bindable properties
*)
    member this.args                               = _args 
    member this.Process                            = _Process 
    member this.grid                               = _grid 
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
