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
  vanillaengines  the correctness of the returned values is tested by checking it against analytic results.  Greeks are not overly accurate. They could be improved by building a tree so that it has three points at the current time. The value would be fetched from the middle one, while the two side points would be used for estimating partial derivatives.

  </summary> *)
[<AutoSerializable(true)>]
type BinomialVanillaEngineModel<'T when 'T :> ITreeFactory<'T> and 'T :> ITree and 'T : (new : unit -> 'T)>
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , timeSteps                                    : ICell<int>
    ) as this =

    inherit Model<BinomialVanillaEngine<'T>> ()
(*
    Parameters
*)
    let _Process                                   = Process
    let _timeSteps                                 = timeSteps
(*
    Functions
*)
    let mutable
        _BinomialVanillaEngine                     = cell (fun () -> new BinomialVanillaEngine<'T> (Process.Value, timeSteps.Value))
    do this.Bind(_BinomialVanillaEngine)

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.timeSteps                          = _timeSteps 
