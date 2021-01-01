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
type CumulativeChiSquareDistributionModel
    ( df                                           : ICell<double>
    ) as this =

    inherit Model<CumulativeChiSquareDistribution> ()
(*
    Parameters
*)
    let _df                                        = df
(*
    Functions
*)
    let mutable
        _CumulativeChiSquareDistribution           = make (fun () -> new CumulativeChiSquareDistribution (df.Value))
    let _value                                     (x : ICell<double>)   
                                                   = triv _CumulativeChiSquareDistribution (fun () -> _CumulativeChiSquareDistribution.Value.value(x.Value))
    do this.Bind(_CumulativeChiSquareDistribution)
(* 
    casting 
*)
    internal new () = new CumulativeChiSquareDistributionModel(null)
    member internal this.Inject v = _CumulativeChiSquareDistribution <- v
    static member Cast (p : ICell<CumulativeChiSquareDistribution>) = 
        if p :? CumulativeChiSquareDistributionModel then 
            p :?> CumulativeChiSquareDistributionModel
        else
            let o = new CumulativeChiSquareDistributionModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.df                                 = _df 
    member this.Value                              x   
                                                   = _value x 
