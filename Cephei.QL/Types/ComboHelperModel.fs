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
type ComboHelperModel
    ( quadraticHelper                              : ICell<ISectionHelper>
    , convMonoHelper                               : ICell<ISectionHelper>
    , quadraticity                                 : ICell<double>
    ) as this =

    inherit Model<ComboHelper> ()
(*
    Parameters
*)
    let _quadraticHelper                           = quadraticHelper
    let _convMonoHelper                            = convMonoHelper
    let _quadraticity                              = quadraticity
(*
    Functions
*)
    let mutable
        _ComboHelper                               = make (fun () -> new ComboHelper (quadraticHelper.Value, convMonoHelper.Value, quadraticity.Value))
    let _fNext                                     = triv _ComboHelper (fun () -> _ComboHelper.Value.fNext())
    let _primitive                                 (x : ICell<double>)   
                                                   = triv _ComboHelper (fun () -> _ComboHelper.Value.primitive(x.Value))
    let _value                                     (x : ICell<double>)   
                                                   = triv _ComboHelper (fun () -> _ComboHelper.Value.value(x.Value))
    do this.Bind(_ComboHelper)
(* 
    casting 
*)
    internal new () = new ComboHelperModel(null,null,null)
    member internal this.Inject v = _ComboHelper <- v
    static member Cast (p : ICell<ComboHelper>) = 
        if p :? ComboHelperModel then 
            p :?> ComboHelperModel
        else
            let o = new ComboHelperModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.quadraticHelper                    = _quadraticHelper 
    member this.convMonoHelper                     = _convMonoHelper 
    member this.quadraticity                       = _quadraticity 
    member this.FNext                              = _fNext
    member this.Primitive                          x   
                                                   = _primitive x 
    member this.Value                              x   
                                                   = _value x 
