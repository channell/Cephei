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
  tabulated Gauss-Legendre quadratures

  </summary> *)
[<AutoSerializable(true)>]
type TabulatedGaussLegendreModel
    ( n                                            : ICell<int>
    ) as this =

    inherit Model<TabulatedGaussLegendre> ()
(*
    Parameters
*)
    let _n                                         = n
(*
    Functions
*)
    let mutable
        _TabulatedGaussLegendre                    = cell (fun () -> new TabulatedGaussLegendre (n.Value))
    let _order                                     = triv (fun () -> _TabulatedGaussLegendre.Value.order())
    let _order1                                    (order : ICell<int>)   
                                                   = triv (fun () -> _TabulatedGaussLegendre.Value.order(order.Value)
                                                                     _TabulatedGaussLegendre.Value)
    let _value                                     (f : ICell<Func<double,double>>)   
                                                   = triv (fun () -> _TabulatedGaussLegendre.Value.value(f.Value))
    do this.Bind(_TabulatedGaussLegendre)
(* 
    casting 
*)
    internal new () = new TabulatedGaussLegendreModel(null)
    member internal this.Inject v = _TabulatedGaussLegendre <- v
    static member Cast (p : ICell<TabulatedGaussLegendre>) = 
        if p :? TabulatedGaussLegendreModel then 
            p :?> TabulatedGaussLegendreModel
        else
            let o = new TabulatedGaussLegendreModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.n                                  = _n 
    member this.Order                              = _order
    member this.Order1                             order   
                                                   = _order1 order 
    member this.Value                              f   
                                                   = _value f 
