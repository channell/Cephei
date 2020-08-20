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
type Fdm1DimSolverModel
    ( solverDesc                                   : ICell<FdmSolverDesc>
    , schemeDesc                                   : ICell<FdmSchemeDesc>
    , op                                           : ICell<FdmLinearOpComposite>
    ) as this =

    inherit Model<Fdm1DimSolver> ()
(*
    Parameters
*)
    let _solverDesc                                = solverDesc
    let _schemeDesc                                = schemeDesc
    let _op                                        = op
(*
    Functions
*)
    let _Fdm1DimSolver                             = cell (fun () -> new Fdm1DimSolver (solverDesc.Value, schemeDesc.Value, op.Value))
    let _derivativeX                               (x : ICell<double>)   
                                                   = cell (fun () -> _Fdm1DimSolver.Value.derivativeX(x.Value))
    let _derivativeXX                              (x : ICell<double>)   
                                                   = cell (fun () -> _Fdm1DimSolver.Value.derivativeXX(x.Value))
    let _interpolateAt                             (x : ICell<double>)   
                                                   = cell (fun () -> _Fdm1DimSolver.Value.interpolateAt(x.Value))
    let _thetaAt                                   (x : ICell<double>)   
                                                   = cell (fun () -> _Fdm1DimSolver.Value.thetaAt(x.Value))
    do this.Bind(_Fdm1DimSolver)

(* 
    Externally visible/bindable properties
*)
    member this.solverDesc                         = _solverDesc 
    member this.schemeDesc                         = _schemeDesc 
    member this.op                                 = _op 
    member this.DerivativeX                        x   
                                                   = _derivativeX x 
    member this.DerivativeXX                       x   
                                                   = _derivativeXX x 
    member this.InterpolateAt                      x   
                                                   = _interpolateAt x 
    member this.ThetaAt                            x   
                                                   = _thetaAt x 
