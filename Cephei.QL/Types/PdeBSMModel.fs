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
type PdeBSMModel
    () as this =
    inherit Model<PdeBSM> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _PdeBSM                                    = cell (fun () -> new PdeBSM ())
    let _diffusion                                 (t : ICell<double>) (x : ICell<double>)   
                                                   = triv (fun () -> _PdeBSM.Value.diffusion(t.Value, x.Value))
    let _discount                                  (t : ICell<double>) (x : ICell<double>)   
                                                   = triv (fun () -> _PdeBSM.Value.discount(t.Value, x.Value))
    let _drift                                     (t : ICell<double>) (x : ICell<double>)   
                                                   = triv (fun () -> _PdeBSM.Value.drift(t.Value, x.Value))
    let _factory                                   (Process : ICell<GeneralizedBlackScholesProcess>)   
                                                   = triv (fun () -> _PdeBSM.Value.factory(Process.Value))
    let _generateOperator                          (t : ICell<double>) (tg : ICell<TransformedGrid>) (L : ICell<TridiagonalOperator>)   
                                                   = triv (fun () -> _PdeBSM.Value.generateOperator(t.Value, tg.Value, L.Value)
                                                                     _PdeBSM.Value)
    do this.Bind(_PdeBSM)
(* 
    casting 
*)
    
    member internal this.Inject v = _PdeBSM <- v
    static member Cast (p : ICell<PdeBSM>) = 
        if p :? PdeBSMModel then 
            p :?> PdeBSMModel
        else
            let o = new PdeBSMModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Diffusion                          t x   
                                                   = _diffusion t x 
    member this.Discount                           t x   
                                                   = _discount t x 
    member this.Drift                              t x   
                                                   = _drift t x 
    member this.Factory                            Process   
                                                   = _factory Process 
    member this.GenerateOperator                   t tg L   
                                                   = _generateOperator t tg L 
(* <summary>

required for generics
  </summary> *)
[<AutoSerializable(true)>]
type PdeBSMModel1
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    ) as this =

    inherit Model<PdeBSM> ()
(*
    Parameters
*)
    let _Process                                   = Process
(*
    Functions
*)
    let mutable
        _PdeBSM                                    = cell (fun () -> new PdeBSM (Process.Value))
    let _diffusion                                 (t : ICell<double>) (x : ICell<double>)   
                                                   = triv (fun () -> _PdeBSM.Value.diffusion(t.Value, x.Value))
    let _discount                                  (t : ICell<double>) (x : ICell<double>)   
                                                   = triv (fun () -> _PdeBSM.Value.discount(t.Value, x.Value))
    let _drift                                     (t : ICell<double>) (x : ICell<double>)   
                                                   = triv (fun () -> _PdeBSM.Value.drift(t.Value, x.Value))
    let _factory                                   (Process : ICell<GeneralizedBlackScholesProcess>)   
                                                   = triv (fun () -> _PdeBSM.Value.factory(Process.Value))
    let _generateOperator                          (t : ICell<double>) (tg : ICell<TransformedGrid>) (L : ICell<TridiagonalOperator>)   
                                                   = triv (fun () -> _PdeBSM.Value.generateOperator(t.Value, tg.Value, L.Value)
                                                                     _PdeBSM.Value)
    do this.Bind(_PdeBSM)
(* 
    casting 
*)
    internal new () = new PdeBSMModel1(null)
    member internal this.Inject v = _PdeBSM <- v
    static member Cast (p : ICell<PdeBSM>) = 
        if p :? PdeBSMModel1 then 
            p :?> PdeBSMModel1
        else
            let o = new PdeBSMModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.Diffusion                          t x   
                                                   = _diffusion t x 
    member this.Discount                           t x   
                                                   = _discount t x 
    member this.Drift                              t x   
                                                   = _drift t x 
    member this.Factory                            Process   
                                                   = _factory Process 
    member this.GenerateOperator                   t tg L   
                                                   = _generateOperator t tg L 
