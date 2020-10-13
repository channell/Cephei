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
  formula here ... Given an integer k it returns its probability in a Binomial distribution with parameters p and n.

  </summary> *)
[<AutoSerializable(true)>]
type BinomialDistributionModel
    ( p                                            : ICell<double>
    , n                                            : ICell<int>
    ) as this =

    inherit Model<BinomialDistribution> ()
(*
    Parameters
*)
    let _p                                         = p
    let _n                                         = n
(*
    Functions
*)
    let _BinomialDistribution                      = cell (fun () -> new BinomialDistribution (p.Value, n.Value))
    let _value                                     (k : ICell<int>)   
                                                   = triv (fun () -> _BinomialDistribution.Value.value(k.Value))
    do this.Bind(_BinomialDistribution)
(* 
    casting 
*)
    internal new () = new BinomialDistributionModel(null,null)
    member internal this.Inject v = _BinomialDistribution.Value <- v
    static member Cast (p : ICell<BinomialDistribution>) = 
        if p :? BinomialDistributionModel then 
            p :?> BinomialDistributionModel
        else
            let o = new BinomialDistributionModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.p                                  = _p 
    member this.n                                  = _n 
    member this.Value                              k   
                                                   = _value k 
