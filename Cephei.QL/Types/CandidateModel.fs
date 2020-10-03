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
type CandidateModel
    ( size                                         : ICell<int>
    ) as this =

    inherit Model<Candidate> ()
(*
    Parameters
*)
    let _size                                      = size
(*
    Functions
*)
    let _Candidate                                 = cell (fun () -> new Candidate (size.Value))
    let _Clone                                     = cell (fun () -> _Candidate.Value.Clone())
    let _cost                                      = cell (fun () -> _Candidate.Value.cost)
    let _values                                    = cell (fun () -> _Candidate.Value.values)
    do this.Bind(_Candidate)
(* 
    casting 
*)
    internal new () = CandidateModel(null)
    member internal this.Inject v = _Candidate.Value <- v
    static member Cast (p : ICell<Candidate>) = 
        if p :? CandidateModel then 
            p :?> CandidateModel
        else
            let o = new CandidateModel ()
            o.Inject p.Value
            o
                            
(* 
    casting 
*)
    internal new () = CandidateModel(null)
    static member Cast (p : ICell<Candidate>) = 
        if p :? CandidateModel then 
            p :?> CandidateModel
        else
            let o = new CandidateModel ()
            o.Value <- p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.size                               = _size 
    member this.Clone                              = _Clone
    member this.Cost                               = _cost
    member this.Values                             = _values
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type CandidateModel1
    () as this =
    inherit Model<Candidate> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _Candidate                                 = cell (fun () -> new Candidate ())
    let _Clone                                     = cell (fun () -> _Candidate.Value.Clone())
    let _cost                                      = cell (fun () -> _Candidate.Value.cost)
    let _values                                    = cell (fun () -> _Candidate.Value.values)
    do this.Bind(_Candidate)
(* 
    casting 
*)
    
    member internal this.Inject v = _Candidate.Value <- v
    static member Cast (p : ICell<Candidate>) = 
        if p :? CandidateModel1 then 
            p :?> CandidateModel1
        else
            let o = new CandidateModel1 ()
            o.Inject p.Value
            o
                            
(* 
    casting 
*)
    
    static member Cast (p : ICell<Candidate>) = 
        if p :? CandidateModel1 then 
            p :?> CandidateModel1
        else
            let o = new CandidateModel1 ()
            o.Value <- p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Clone                              = _Clone
    member this.Cost                               = _cost
    member this.Values                             = _values
