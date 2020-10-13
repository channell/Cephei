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
type DiscretizedDoubleBarrierOptionModel
    ( args                                         : ICell<DoubleBarrierOption.Arguments>
    , Process                                      : ICell<StochasticProcess>
    , grid                                         : ICell<TimeGrid>
    ) as this =

    inherit Model<DiscretizedDoubleBarrierOption> ()
(*
    Parameters
*)
    let _args                                      = args
    let _Process                                   = Process
    let _grid                                      = grid
(*
    Functions
*)
    let _DiscretizedDoubleBarrierOption            = cell (fun () -> new DiscretizedDoubleBarrierOption (args.Value, Process.Value, grid.Value))
    let _checkBarrier                              (optvalues : ICell<Vector>) (grid : ICell<Vector>)   
                                                   = triv (fun () -> _DiscretizedDoubleBarrierOption.Value.checkBarrier(optvalues.Value, grid.Value)
                                                                     _DiscretizedDoubleBarrierOption.Value)
    let _mandatoryTimes                            = triv (fun () -> _DiscretizedDoubleBarrierOption.Value.mandatoryTimes())
    let _reset                                     (size : ICell<int>)   
                                                   = triv (fun () -> _DiscretizedDoubleBarrierOption.Value.reset(size.Value)
                                                                     _DiscretizedDoubleBarrierOption.Value)
    let _vanilla                                   = triv (fun () -> _DiscretizedDoubleBarrierOption.Value.vanilla())
    let _adjustValues                              = triv (fun () -> _DiscretizedDoubleBarrierOption.Value.adjustValues()
                                                                     _DiscretizedDoubleBarrierOption.Value)
    let _initialize                                (Method : ICell<Lattice>) (t : ICell<double>)   
                                                   = triv (fun () -> _DiscretizedDoubleBarrierOption.Value.initialize(Method.Value, t.Value)
                                                                     _DiscretizedDoubleBarrierOption.Value)
    let _method                                    = triv (fun () -> _DiscretizedDoubleBarrierOption.Value.METHOD())
    let _partialRollback                           (To : ICell<double>)   
                                                   = triv (fun () -> _DiscretizedDoubleBarrierOption.Value.partialRollback(To.Value)
                                                                     _DiscretizedDoubleBarrierOption.Value)
    let _postAdjustValues                          = triv (fun () -> _DiscretizedDoubleBarrierOption.Value.postAdjustValues()
                                                                     _DiscretizedDoubleBarrierOption.Value)
    let _preAdjustValues                           = triv (fun () -> _DiscretizedDoubleBarrierOption.Value.preAdjustValues()
                                                                     _DiscretizedDoubleBarrierOption.Value)
    let _presentValue                              = triv (fun () -> _DiscretizedDoubleBarrierOption.Value.presentValue())
    let _rollback                                  (To : ICell<double>)   
                                                   = triv (fun () -> _DiscretizedDoubleBarrierOption.Value.rollback(To.Value)
                                                                     _DiscretizedDoubleBarrierOption.Value)
    let _setTime                                   (t : ICell<double>)   
                                                   = triv (fun () -> _DiscretizedDoubleBarrierOption.Value.setTime(t.Value)
                                                                     _DiscretizedDoubleBarrierOption.Value)
    let _setValues                                 (v : ICell<Vector>)   
                                                   = triv (fun () -> _DiscretizedDoubleBarrierOption.Value.setValues(v.Value)
                                                                     _DiscretizedDoubleBarrierOption.Value)
    let _time                                      = triv (fun () -> _DiscretizedDoubleBarrierOption.Value.time())
    let _values                                    = triv (fun () -> _DiscretizedDoubleBarrierOption.Value.values())
    do this.Bind(_DiscretizedDoubleBarrierOption)
(* 
    casting 
*)
    internal new () = new DiscretizedDoubleBarrierOptionModel(null,null,null)
    member internal this.Inject v = _DiscretizedDoubleBarrierOption.Value <- v
    static member Cast (p : ICell<DiscretizedDoubleBarrierOption>) = 
        if p :? DiscretizedDoubleBarrierOptionModel then 
            p :?> DiscretizedDoubleBarrierOptionModel
        else
            let o = new DiscretizedDoubleBarrierOptionModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.args                               = _args 
    member this.Process                            = _Process 
    member this.grid                               = _grid 
    member this.CheckBarrier                       optvalues grid   
                                                   = _checkBarrier optvalues grid 
    member this.MandatoryTimes                     = _mandatoryTimes
    member this.Reset                              size   
                                                   = _reset size 
    member this.Vanilla                            = _vanilla
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
