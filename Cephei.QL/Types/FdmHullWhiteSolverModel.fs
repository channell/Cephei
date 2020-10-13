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
type FdmHullWhiteSolverModel
    ( model                                        : ICell<Handle<HullWhite>>
    , solverDesc                                   : ICell<FdmSolverDesc>
    , schemeDesc                                   : ICell<FdmSchemeDesc>
    ) as this =

    inherit Model<FdmHullWhiteSolver> ()
(*
    Parameters
*)
    let _model                                     = model
    let _solverDesc                                = solverDesc
    let _schemeDesc                                = schemeDesc
(*
    Functions
*)
    let _FdmHullWhiteSolver                        = cell (fun () -> new FdmHullWhiteSolver (model.Value, solverDesc.Value, schemeDesc.Value))
    let _deltaAt                                   (s : ICell<double>)   
                                                   = triv (fun () -> _FdmHullWhiteSolver.Value.deltaAt(s.Value))
    let _gammaAt                                   (s : ICell<double>)   
                                                   = triv (fun () -> _FdmHullWhiteSolver.Value.gammaAt(s.Value))
    let _thetaAt                                   (s : ICell<double>)   
                                                   = triv (fun () -> _FdmHullWhiteSolver.Value.thetaAt(s.Value))
    let _valueAt                                   (s : ICell<double>)   
                                                   = triv (fun () -> _FdmHullWhiteSolver.Value.valueAt(s.Value))
    do this.Bind(_FdmHullWhiteSolver)
(* 
    casting 
*)
    internal new () = new FdmHullWhiteSolverModel(null,null,null)
    member internal this.Inject v = _FdmHullWhiteSolver.Value <- v
    static member Cast (p : ICell<FdmHullWhiteSolver>) = 
        if p :? FdmHullWhiteSolverModel then 
            p :?> FdmHullWhiteSolverModel
        else
            let o = new FdmHullWhiteSolverModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.model                              = _model 
    member this.solverDesc                         = _solverDesc 
    member this.schemeDesc                         = _schemeDesc 
    member this.DeltaAt                            s   
                                                   = _deltaAt s 
    member this.GammaAt                            s   
                                                   = _gammaAt s 
    member this.ThetaAt                            s   
                                                   = _thetaAt s 
    member this.ValueAt                            s   
                                                   = _valueAt s 
