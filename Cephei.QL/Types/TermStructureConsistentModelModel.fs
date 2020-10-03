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
TermStructureConsistentModel used in analyticcapfloorengine.cs

  </summary> *)
[<AutoSerializable(true)>]
type TermStructureConsistentModelModel
    ( termStructure                                : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<TermStructureConsistentModel> ()
(*
    Parameters
*)
    let _termStructure                             = termStructure
(*
    Functions
*)
    let _TermStructureConsistentModel              = cell (fun () -> new TermStructureConsistentModel (termStructure.Value))
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _TermStructureConsistentModel.Value.registerWith(handler.Value)
                                                                     _TermStructureConsistentModel.Value)
    let _termStructure                             = triv (fun () -> _TermStructureConsistentModel.Value.termStructure())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _TermStructureConsistentModel.Value.unregisterWith(handler.Value)
                                                                     _TermStructureConsistentModel.Value)
    do this.Bind(_TermStructureConsistentModel)
(* 
    casting 
*)
    internal new () = TermStructureConsistentModelModel(null)
    member internal this.Inject v = _TermStructureConsistentModel.Value <- v
    static member Cast (p : ICell<TermStructureConsistentModel>) = 
        if p :? TermStructureConsistentModelModel then 
            p :?> TermStructureConsistentModelModel
        else
            let o = new TermStructureConsistentModelModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.termStructure                      = _termStructure 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.TermStructure                      = _termStructure
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
