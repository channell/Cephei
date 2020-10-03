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
type OdeSolverModel
    ( func                                         : ICell<OdeIntegrationFct.OdeIntegrationFct>
    , y0                                           : ICell<double>
    , x0                                           : ICell<double>
    , x1                                           : ICell<double>
    , End                                          : ICell<double>
    ) as this =

    inherit Model<OdeSolver> ()
(*
    Parameters
*)
    let _func                                      = func
    let _y0                                        = y0
    let _x0                                        = x0
    let _x1                                        = x1
    let _End                                       = End
(*
    Functions
*)
    let _OdeSolver                                 = cell (fun () -> new OdeSolver (func.Value, y0.Value, x0.Value, x1.Value, End.Value))
    let _value                                     (v : ICell<double>)   
                                                   = cell (fun () -> _OdeSolver.Value.value(v.Value))
    let _derivative                                (x : ICell<double>)   
                                                   = cell (fun () -> _OdeSolver.Value.derivative(x.Value))
    do this.Bind(_OdeSolver)
(* 
    casting 
*)
    internal new () = OdeSolverModel(null,null,null,null,null)
    member internal this.Inject v = _OdeSolver.Value <- v
    static member Cast (p : ICell<OdeSolver>) = 
        if p :? OdeSolverModel then 
            p :?> OdeSolverModel
        else
            let o = new OdeSolverModel ()
            o.Inject p.Value
            o
                            
(* 
    casting 
*)
    internal new () = OdeSolverModel(null,null,null,null,null)
    static member Cast (p : ICell<OdeSolver>) = 
        if p :? OdeSolverModel then 
            p :?> OdeSolverModel
        else
            let o = new OdeSolverModel ()
            o.Value <- p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.func                               = _func 
    member this.y0                                 = _y0 
    member this.x0                                 = _x0 
    member this.x1                                 = _x1 
    member this.End                                = _End 
    member this.Value                              v   
                                                   = _value v 
    member this.Derivative                         x   
                                                   = _derivative x 
