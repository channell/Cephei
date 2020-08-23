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
type FdmBlackScholesSolverModel
    ( Process                                      : ICell<Handle<GeneralizedBlackScholesProcess>>
    , strike                                       : ICell<double>
    , solverDesc                                   : ICell<FdmSolverDesc>
    , schemeDesc                                   : ICell<FdmSchemeDesc>
    , localVol                                     : ICell<bool>
    , illegalLocalVolOverwrite                     : ICell<Nullable<double>>
    , quantoHelper                                 : ICell<Handle<FdmQuantoHelper>>
    ) as this =

    inherit Model<FdmBlackScholesSolver> ()
(*
    Parameters
*)
    let _Process                                   = Process
    let _strike                                    = strike
    let _solverDesc                                = solverDesc
    let _schemeDesc                                = schemeDesc
    let _localVol                                  = localVol
    let _illegalLocalVolOverwrite                  = illegalLocalVolOverwrite
    let _quantoHelper                              = quantoHelper
(*
    Functions
*)
    let _FdmBlackScholesSolver                     = cell (fun () -> new FdmBlackScholesSolver (Process.Value, strike.Value, solverDesc.Value, schemeDesc.Value, localVol.Value, illegalLocalVolOverwrite.Value, quantoHelper.Value))
    let _deltaAt                                   (s : ICell<double>)   
                                                   = triv (fun () -> _FdmBlackScholesSolver.Value.deltaAt(s.Value))
    let _gammaAt                                   (s : ICell<double>)   
                                                   = triv (fun () -> _FdmBlackScholesSolver.Value.gammaAt(s.Value))
    let _thetaAt                                   (s : ICell<double>)   
                                                   = triv (fun () -> _FdmBlackScholesSolver.Value.thetaAt(s.Value))
    let _valueAt                                   (s : ICell<double>)   
                                                   = triv (fun () -> _FdmBlackScholesSolver.Value.valueAt(s.Value))
    do this.Bind(_FdmBlackScholesSolver)

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.strike                             = _strike 
    member this.solverDesc                         = _solverDesc 
    member this.schemeDesc                         = _schemeDesc 
    member this.localVol                           = _localVol 
    member this.illegalLocalVolOverwrite           = _illegalLocalVolOverwrite 
    member this.quantoHelper                       = _quantoHelper 
    member this.DeltaAt                            s   
                                                   = _deltaAt s 
    member this.GammaAt                            s   
                                                   = _gammaAt s 
    member this.ThetaAt                            s   
                                                   = _thetaAt s 
    member this.ValueAt                            s   
                                                   = _valueAt s 
