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
type InverseNonCentralChiSquareDistributionModel
    ( df                                           : ICell<double>
    , ncp                                          : ICell<double>
    ) as this =

    inherit Model<InverseNonCentralChiSquareDistribution> ()
(*
    Parameters
*)
    let _df                                        = df
    let _ncp                                       = ncp
(*
    Functions
*)
    let _InverseNonCentralChiSquareDistribution    = cell (fun () -> new InverseNonCentralChiSquareDistribution (df.Value, ncp.Value))
    let _value                                     (x : ICell<double>)   
                                                   = triv (fun () -> _InverseNonCentralChiSquareDistribution.Value.value(x.Value))
    do this.Bind(_InverseNonCentralChiSquareDistribution)
(* 
    casting 
*)
    internal new () = new InverseNonCentralChiSquareDistributionModel(null,null)
    member internal this.Inject v = _InverseNonCentralChiSquareDistribution.Value <- v
    static member Cast (p : ICell<InverseNonCentralChiSquareDistribution>) = 
        if p :? InverseNonCentralChiSquareDistributionModel then 
            p :?> InverseNonCentralChiSquareDistributionModel
        else
            let o = new InverseNonCentralChiSquareDistributionModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.df                                 = _df 
    member this.ncp                                = _ncp 
    member this.Value                              x   
                                                   = _value x 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type InverseNonCentralChiSquareDistributionModel1
    ( df                                           : ICell<double>
    , ncp                                          : ICell<double>
    , maxEvaluations                               : ICell<int>
    ) as this =

    inherit Model<InverseNonCentralChiSquareDistribution> ()
(*
    Parameters
*)
    let _df                                        = df
    let _ncp                                       = ncp
    let _maxEvaluations                            = maxEvaluations
(*
    Functions
*)
    let _InverseNonCentralChiSquareDistribution    = cell (fun () -> new InverseNonCentralChiSquareDistribution (df.Value, ncp.Value, maxEvaluations.Value))
    let _value                                     (x : ICell<double>)   
                                                   = triv (fun () -> _InverseNonCentralChiSquareDistribution.Value.value(x.Value))
    do this.Bind(_InverseNonCentralChiSquareDistribution)
(* 
    casting 
*)
    internal new () = new InverseNonCentralChiSquareDistributionModel1(null,null,null)
    member internal this.Inject v = _InverseNonCentralChiSquareDistribution.Value <- v
    static member Cast (p : ICell<InverseNonCentralChiSquareDistribution>) = 
        if p :? InverseNonCentralChiSquareDistributionModel1 then 
            p :?> InverseNonCentralChiSquareDistributionModel1
        else
            let o = new InverseNonCentralChiSquareDistributionModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.df                                 = _df 
    member this.ncp                                = _ncp 
    member this.maxEvaluations                     = _maxEvaluations 
    member this.Value                              x   
                                                   = _value x 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type InverseNonCentralChiSquareDistributionModel2
    ( df                                           : ICell<double>
    , ncp                                          : ICell<double>
    , maxEvaluations                               : ICell<int>
    , accuracy                                     : ICell<double>
    ) as this =

    inherit Model<InverseNonCentralChiSquareDistribution> ()
(*
    Parameters
*)
    let _df                                        = df
    let _ncp                                       = ncp
    let _maxEvaluations                            = maxEvaluations
    let _accuracy                                  = accuracy
(*
    Functions
*)
    let _InverseNonCentralChiSquareDistribution    = cell (fun () -> new InverseNonCentralChiSquareDistribution (df.Value, ncp.Value, maxEvaluations.Value, accuracy.Value))
    let _value                                     (x : ICell<double>)   
                                                   = triv (fun () -> _InverseNonCentralChiSquareDistribution.Value.value(x.Value))
    do this.Bind(_InverseNonCentralChiSquareDistribution)
(* 
    casting 
*)
    internal new () = new InverseNonCentralChiSquareDistributionModel2(null,null,null,null)
    member internal this.Inject v = _InverseNonCentralChiSquareDistribution.Value <- v
    static member Cast (p : ICell<InverseNonCentralChiSquareDistribution>) = 
        if p :? InverseNonCentralChiSquareDistributionModel2 then 
            p :?> InverseNonCentralChiSquareDistributionModel2
        else
            let o = new InverseNonCentralChiSquareDistributionModel2 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.df                                 = _df 
    member this.ncp                                = _ncp 
    member this.maxEvaluations                     = _maxEvaluations 
    member this.accuracy                           = _accuracy 
    member this.Value                              x   
                                                   = _value x 
