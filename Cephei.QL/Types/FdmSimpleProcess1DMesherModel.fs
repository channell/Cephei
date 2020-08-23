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
type FdmSimpleProcess1DMesherModel
    ( size                                         : ICell<int>
    , Process                                      : ICell<StochasticProcess1D>
    , maturity                                     : ICell<double>
    , tAvgSteps                                    : ICell<int>
    , epsilon                                      : ICell<double>
    , mandatoryPoint                               : ICell<Nullable<double>>
    ) as this =

    inherit Model<FdmSimpleProcess1DMesher> ()
(*
    Parameters
*)
    let _size                                      = size
    let _Process                                   = Process
    let _maturity                                  = maturity
    let _tAvgSteps                                 = tAvgSteps
    let _epsilon                                   = epsilon
    let _mandatoryPoint                            = mandatoryPoint
(*
    Functions
*)
    let _FdmSimpleProcess1DMesher                  = cell (fun () -> new FdmSimpleProcess1DMesher (size.Value, Process.Value, maturity.Value, tAvgSteps.Value, epsilon.Value, mandatoryPoint.Value))
    let _dminus                                    (index : ICell<int>)   
                                                   = triv (fun () -> _FdmSimpleProcess1DMesher.Value.dminus(index.Value))
    let _dplus                                     (index : ICell<int>)   
                                                   = triv (fun () -> _FdmSimpleProcess1DMesher.Value.dplus(index.Value))
    let _location                                  (index : ICell<int>)   
                                                   = triv (fun () -> _FdmSimpleProcess1DMesher.Value.location(index.Value))
    let _locations                                 = triv (fun () -> _FdmSimpleProcess1DMesher.Value.locations())
    let _size                                      = triv (fun () -> _FdmSimpleProcess1DMesher.Value.size())
    do this.Bind(_FdmSimpleProcess1DMesher)

(* 
    Externally visible/bindable properties
*)
    member this.size                               = _size 
    member this.Process                            = _Process 
    member this.maturity                           = _maturity 
    member this.tAvgSteps                          = _tAvgSteps 
    member this.epsilon                            = _epsilon 
    member this.mandatoryPoint                     = _mandatoryPoint 
    member this.Dminus                             index   
                                                   = _dminus index 
    member this.Dplus                              index   
                                                   = _dplus index 
    member this.Location                           index   
                                                   = _location index 
    member this.Locations                          = _locations
    member this.Size                               = _size
