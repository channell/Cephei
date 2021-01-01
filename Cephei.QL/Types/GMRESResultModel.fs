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
  References: Saad, Yousef. 1996, Iterative methods for sparse linear systems, http://www-users.cs.umn.edu/~saad/books.html  Dongarra et al. 1994, Templates for the Solution of Linear Systems: Building Blocks for Iterative Methods, 2nd Edition, SIAM, Philadelphia http://www.netlib.org/templates/templates.pdf  Christian Kanzow Numerik linearer Gleichungssysteme (German) Chapter 6: GMRES und verwandte Verfahren http://bilder.buecher.de/zusatz/12/12950/12950560_lese_1.pdf

  </summary> *)
[<AutoSerializable(true)>]
type GMRESResultModel
    ( e                                            : ICell<Generic.List<double>>
    , xx                                           : ICell<Vector>
    ) as this =

    inherit Model<GMRESResult> ()
(*
    Parameters
*)
    let _e                                         = e
    let _xx                                        = xx
(*
    Functions
*)
    let mutable
        _GMRESResult                               = make (fun () -> new GMRESResult (e.Value, xx.Value))
    let _Errors                                    = triv _GMRESResult (fun () -> _GMRESResult.Value.Errors)
    let _X                                         = triv _GMRESResult (fun () -> _GMRESResult.Value.X)
    do this.Bind(_GMRESResult)
(* 
    casting 
*)
    internal new () = new GMRESResultModel(null,null)
    member internal this.Inject v = _GMRESResult <- v
    static member Cast (p : ICell<GMRESResult>) = 
        if p :? GMRESResultModel then 
            p :?> GMRESResultModel
        else
            let o = new GMRESResultModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.e                                  = _e 
    member this.xx                                 = _xx 
    member this.Errors                             = _Errors
    member this.X                                  = _X
