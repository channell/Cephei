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
  barrierengines  This engine requires a the discretized option classes. By default uses a standard binomial implementation, but it can also work with DiscretizedDermanKaniDoubleBarrierOption to implement a Derman-Kani optimization.  the correctness of the returned values is tested by checking it against analytic results.
! \param maxTimeSteps is used to limit timeSteps when using Boyle-Lau optimization. If zero (the default) the maximum number of steps is calculated by an heuristic: anything when < 1000, otherwise no more than 5*timeSteps. If maxTimeSteps is equal to timeSteps Boyle-Lau is disabled. Likewise if the lattice is not CoxRossRubinstein Boyle-Lau is disabled and maxTimeSteps ignored.
  </summary> *)
[<AutoSerializable(true)>]
type BinomialDoubleBarrierEngineModel
    ( getTree                                      : ICell<BinomialDoubleBarrierEngine.GetTree>
    , getAsset                                     : ICell<BinomialDoubleBarrierEngine.GetAsset>
    , Process                                      : ICell<GeneralizedBlackScholesProcess>
    , timeSteps                                    : ICell<int>
    , maxTimeSteps                                 : ICell<int>
    ) as this =

    inherit Model<BinomialDoubleBarrierEngine> ()
(*
    Parameters
*)
    let _getTree                                   = getTree
    let _getAsset                                  = getAsset
    let _Process                                   = Process
    let _timeSteps                                 = timeSteps
    let _maxTimeSteps                              = maxTimeSteps
(*
    Functions
*)
    let _BinomialDoubleBarrierEngine               = cell (fun () -> new BinomialDoubleBarrierEngine (getTree.Value, getAsset.Value, Process.Value, timeSteps.Value, maxTimeSteps.Value))
    do this.Bind(_BinomialDoubleBarrierEngine)
(* 
    casting 
*)
    internal new () = new BinomialDoubleBarrierEngineModel(null,null,null,null,null)
    member internal this.Inject v = _BinomialDoubleBarrierEngine.Value <- v
    static member Cast (p : ICell<BinomialDoubleBarrierEngine>) = 
        if p :? BinomialDoubleBarrierEngineModel then 
            p :?> BinomialDoubleBarrierEngineModel
        else
            let o = new BinomialDoubleBarrierEngineModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.getTree                            = _getTree 
    member this.getAsset                           = _getAsset 
    member this.Process                            = _Process 
    member this.timeSteps                          = _timeSteps 
    member this.maxTimeSteps                       = _maxTimeSteps 
