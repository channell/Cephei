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
  Drezner (1978) algorithm, six decimal places accuracy.  For this implementation see "Option pricing formulas", E.G. Haug, McGraw-Hill 1998  check accuracy of this algorithm and compare with: 1) Drezner, Z, (1978), Computation of the bivariate normal integral, Mathematics of Computation 32, pp. 277-279. 2) Drezner, Z. and Wesolowsky, G. O. (1990) `On the Computation of the Bivariate Normal Integral', Journal of Statistical Computation and Simulation 35, pp. 101-107. 3) Drezner, Z (1992) Computation of the Multivariate Normal Integral, ACM Transactions on Mathematics Software 18, pp. 450-460. 4) Drezner, Z (1994) Computation of the Trivariate Normal Integral, Mathematics of Computation 62, pp. 289-294. 5) Genz, A. (1992) `Numerical Computation of the Multivariate Normal Probabilities', J. Comput. Graph. Stat. 1, pp. 141-150.  the correctness of the returned value is tested by checking it against known good results.

  </summary> *)
[<AutoSerializable(true)>]
type BivariateCumulativeNormalDistributionDr78Model
    ( rho                                          : ICell<double>
    ) as this =

    inherit Model<BivariateCumulativeNormalDistributionDr78> ()
(*
    Parameters
*)
    let _rho                                       = rho
(*
    Functions
*)
    let _BivariateCumulativeNormalDistributionDr78 = cell (fun () -> new BivariateCumulativeNormalDistributionDr78 (rho.Value))
    let _value                                     (a : ICell<double>) (b : ICell<double>)   
                                                   = triv (fun () -> _BivariateCumulativeNormalDistributionDr78.Value.value(a.Value, b.Value))
    do this.Bind(_BivariateCumulativeNormalDistributionDr78)
(* 
    casting 
*)
    internal new () = BivariateCumulativeNormalDistributionDr78Model(null)
    member internal this.Inject v = _BivariateCumulativeNormalDistributionDr78.Value <- v
    static member Cast (p : ICell<BivariateCumulativeNormalDistributionDr78>) = 
        if p :? BivariateCumulativeNormalDistributionDr78Model then 
            p :?> BivariateCumulativeNormalDistributionDr78Model
        else
            let o = new BivariateCumulativeNormalDistributionDr78Model ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.rho                                = _rho 
    member this.Value                              a b   
                                                   = _value a b 
