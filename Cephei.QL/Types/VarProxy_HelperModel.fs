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
type VarProxy_HelperModel
    ( proxy                                        : ICell<LfmCovarianceProxy>
    , i                                            : ICell<int>
    , j                                            : ICell<int>
    ) as this =

    inherit Model<VarProxy_Helper> ()
(*
    Parameters
*)
    let _proxy                                     = proxy
    let _i                                         = i
    let _j                                         = j
(*
    Functions
*)
    let _VarProxy_Helper                           = cell (fun () -> new VarProxy_Helper (proxy.Value, i.Value, j.Value))
    let _corrModel_                                = triv (fun () -> _VarProxy_Helper.Value.corrModel_)
    let _value                                     (t : ICell<double>)   
                                                   = triv (fun () -> _VarProxy_Helper.Value.value(t.Value))
    let _volaModel_                                = triv (fun () -> _VarProxy_Helper.Value.volaModel_)
    do this.Bind(_VarProxy_Helper)
(* 
    casting 
*)
    internal new () = VarProxy_HelperModel(null,null,null)
    member internal this.Inject v = _VarProxy_Helper.Value <- v
    static member Cast (p : ICell<VarProxy_Helper>) = 
        if p :? VarProxy_HelperModel then 
            p :?> VarProxy_HelperModel
        else
            let o = new VarProxy_HelperModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.proxy                              = _proxy 
    member this.i                                  = _i 
    member this.j                                  = _j 
    member this.CorrModel_                         = _corrModel_
    member this.Value                              t   
                                                   = _value t 
    member this.VolaModel_                         = _volaModel_
