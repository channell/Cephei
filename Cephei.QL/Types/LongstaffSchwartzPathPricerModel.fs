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
  References:  Francis Longstaff, Eduardo Schwartz, 2001. Valuing American Options by Simulation: A Simple Least-Squares Approach, The Review of Financial Studies, Volume 14, No. 1, 113-147  mcarlo  the correctness of the returned value is tested by reproducing results available in web/literature

  </summary> *)
[<AutoSerializable(true)>]
type LongstaffSchwartzPathPricerModel<'PathType when 'PathType :> IPath>
    ( times                                        : ICell<TimeGrid>
    , pathPricer                                   : ICell<IEarlyExercisePathPricer<'PathType,double>>
    , termStructure                                : ICell<YieldTermStructure>
    ) as this =

    inherit Model<LongstaffSchwartzPathPricer<'PathType>> ()
(*
    Parameters
*)
    let _times                                     = times
    let _pathPricer                                = pathPricer
    let _termStructure                             = termStructure
(*
    Functions
*)
    let _LongstaffSchwartzPathPricer               = cell (fun () -> new LongstaffSchwartzPathPricer<'PathType> (times.Value, pathPricer.Value, termStructure.Value))
    let _calibrate                                 = triv (fun () -> _LongstaffSchwartzPathPricer.Value.calibrate()
                                                                     _LongstaffSchwartzPathPricer.Value)
    let _value                                     (path : ICell<'PathType>)   
                                                   = triv (fun () -> _LongstaffSchwartzPathPricer.Value.value(path.Value))
    do this.Bind(_LongstaffSchwartzPathPricer)

(* 
    Externally visible/bindable properties
*)
    member this.times                              = _times 
    member this.pathPricer                         = _pathPricer 
    member this.termStructure                      = _termStructure 
    member this.Calibrate                          = _calibrate
    member this.Value                              path   
                                                   = _value path 
