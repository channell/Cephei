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
type SobolBrownianGeneratorFactoryModel
    ( ordering                                     : ICell<SobolBrownianGenerator.Ordering>
    , seed                                         : ICell<uint64>
    , integers                                     : ICell<SobolRsg.DirectionIntegers>
    ) as this =

    inherit Model<SobolBrownianGeneratorFactory> ()
(*
    Parameters
*)
    let _ordering                                  = ordering
    let _seed                                      = seed
    let _integers                                  = integers
(*
    Functions
*)
    let mutable
        _SobolBrownianGeneratorFactory             = make (fun () -> new SobolBrownianGeneratorFactory (ordering.Value, seed.Value, integers.Value))
    let _create                                    (factors : ICell<int>) (steps : ICell<int>)   
                                                   = triv _SobolBrownianGeneratorFactory (fun () -> _SobolBrownianGeneratorFactory.Value.create(factors.Value, steps.Value))
    do this.Bind(_SobolBrownianGeneratorFactory)
(* 
    casting 
*)
    internal new () = new SobolBrownianGeneratorFactoryModel(null,null,null)
    member internal this.Inject v = _SobolBrownianGeneratorFactory <- v
    static member Cast (p : ICell<SobolBrownianGeneratorFactory>) = 
        if p :? SobolBrownianGeneratorFactoryModel then 
            p :?> SobolBrownianGeneratorFactoryModel
        else
            let o = new SobolBrownianGeneratorFactoryModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.ordering                           = _ordering 
    member this.seed                               = _seed 
    member this.integers                           = _integers 
    member this.Create                             factors steps   
                                                   = _create factors steps 
