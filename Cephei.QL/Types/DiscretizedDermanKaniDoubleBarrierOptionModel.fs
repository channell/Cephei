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
  This class is used with the BinomialDoubleBarrierEngine to implement the enhanced binomial algorithm of E.Derman, I.Kani, D.Ergener, I.Bardhan ("Enhanced Numerical Methods for Options with Barriers", 1995)  This algorithm is only suitable if the payoff can be approximated linearly, e.g. is not usable for cash-or-nothing payoffs.

  </summary> *)
[<AutoSerializable(true)>]
type DiscretizedDermanKaniDoubleBarrierOptionModel
    ( args                                         : ICell<DoubleBarrierOption.Arguments>
    , Process                                      : ICell<StochasticProcess>
    , grid                                         : ICell<TimeGrid>
    ) as this =

    inherit Model<DiscretizedDermanKaniDoubleBarrierOption> ()
(*
    Parameters
*)
    let _args                                      = args
    let _Process                                   = Process
    let _grid                                      = grid
(*
    Functions
*)
    let _DiscretizedDermanKaniDoubleBarrierOption  = cell (fun () -> new DiscretizedDermanKaniDoubleBarrierOption (args.Value, Process.Value, grid.Value))
    let _mandatoryTimes                            = triv (fun () -> _DiscretizedDermanKaniDoubleBarrierOption.Value.mandatoryTimes())
    let _reset                                     (size : ICell<int>)   
                                                   = triv (fun () -> _DiscretizedDermanKaniDoubleBarrierOption.Value.reset(size.Value)
                                                                     _DiscretizedDermanKaniDoubleBarrierOption.Value)
    let _adjustValues                              = triv (fun () -> _DiscretizedDermanKaniDoubleBarrierOption.Value.adjustValues()
                                                                     _DiscretizedDermanKaniDoubleBarrierOption.Value)
    let _initialize                                (Method : ICell<Lattice>) (t : ICell<double>)   
                                                   = triv (fun () -> _DiscretizedDermanKaniDoubleBarrierOption.Value.initialize(Method.Value, t.Value)
                                                                     _DiscretizedDermanKaniDoubleBarrierOption.Value)
    let _method                                    = triv (fun () -> _DiscretizedDermanKaniDoubleBarrierOption.Value.METHOD())
    let _partialRollback                           (To : ICell<double>)   
                                                   = triv (fun () -> _DiscretizedDermanKaniDoubleBarrierOption.Value.partialRollback(To.Value)
                                                                     _DiscretizedDermanKaniDoubleBarrierOption.Value)
    let _postAdjustValues                          = triv (fun () -> _DiscretizedDermanKaniDoubleBarrierOption.Value.postAdjustValues()
                                                                     _DiscretizedDermanKaniDoubleBarrierOption.Value)
    let _preAdjustValues                           = triv (fun () -> _DiscretizedDermanKaniDoubleBarrierOption.Value.preAdjustValues()
                                                                     _DiscretizedDermanKaniDoubleBarrierOption.Value)
    let _presentValue                              = triv (fun () -> _DiscretizedDermanKaniDoubleBarrierOption.Value.presentValue())
    let _rollback                                  (To : ICell<double>)   
                                                   = triv (fun () -> _DiscretizedDermanKaniDoubleBarrierOption.Value.rollback(To.Value)
                                                                     _DiscretizedDermanKaniDoubleBarrierOption.Value)
    let _setTime                                   (t : ICell<double>)   
                                                   = triv (fun () -> _DiscretizedDermanKaniDoubleBarrierOption.Value.setTime(t.Value)
                                                                     _DiscretizedDermanKaniDoubleBarrierOption.Value)
    let _setValues                                 (v : ICell<Vector>)   
                                                   = triv (fun () -> _DiscretizedDermanKaniDoubleBarrierOption.Value.setValues(v.Value)
                                                                     _DiscretizedDermanKaniDoubleBarrierOption.Value)
    let _time                                      = triv (fun () -> _DiscretizedDermanKaniDoubleBarrierOption.Value.time())
    let _values                                    = triv (fun () -> _DiscretizedDermanKaniDoubleBarrierOption.Value.values())
    do this.Bind(_DiscretizedDermanKaniDoubleBarrierOption)
(* 
    casting 
*)
    internal new () = DiscretizedDermanKaniDoubleBarrierOptionModel(null,null,null)
    member internal this.Inject v = _DiscretizedDermanKaniDoubleBarrierOption.Value <- v
    static member Cast (p : ICell<DiscretizedDermanKaniDoubleBarrierOption>) = 
        if p :? DiscretizedDermanKaniDoubleBarrierOptionModel then 
            p :?> DiscretizedDermanKaniDoubleBarrierOptionModel
        else
            let o = new DiscretizedDermanKaniDoubleBarrierOptionModel ()
            o.Inject p.Value
            o
                            

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
