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
  The implementation derives from the article "Better Approximations To Cumulative Normal Distibutions", Graeme West, Dec 2004 available at www.finmod.co.za. Also available in Wilmott Magazine, 2005, (May), 70-76, The main code is a port of the C++ code at www.finmod.co.za/cumfunctions.zip.  The algorithm is based on the near double-precision algorithm described in "Numerical Computation of Rectangular Bivariate an Trivariate Normal and t Probabilities", Genz (2004), Statistics and Computing 14, 151-160. (available at www.sci.wsu.edu/math/faculty/henz/homepage)  The QuantLib implementation mainly differs from the original code in two regards - The implementation of the cumulative normal distribution is QuantLib::CumulativeNormalDistribution - The arrays XX and W are zero-based  the correctness of the returned value is tested by checking it against known good results.

  </summary> *)
[<AutoSerializable(true)>]
type BivariateCumulativeNormalDistributionWe04DPModel
    ( rho                                          : ICell<double>
    ) as this =

    inherit Model<BivariateCumulativeNormalDistributionWe04DP> ()
(*
    Parameters
*)
    let _rho                                       = rho
(*
    Functions
*)
    let _BivariateCumulativeNormalDistributionWe04DP = cell (fun () -> new BivariateCumulativeNormalDistributionWe04DP (rho.Value))
    let _value                                     (x : ICell<double>) (y : ICell<double>)   
                                                   = triv (fun () -> _BivariateCumulativeNormalDistributionWe04DP.Value.value(x.Value, y.Value))
    do this.Bind(_BivariateCumulativeNormalDistributionWe04DP)
(* 
    casting 
*)
    internal new () = BivariateCumulativeNormalDistributionWe04DPModel(null)
    member internal this.Inject v = _BivariateCumulativeNormalDistributionWe04DP.Value <- v
    static member Cast (p : ICell<BivariateCumulativeNormalDistributionWe04DP>) = 
        if p :? BivariateCumulativeNormalDistributionWe04DPModel then 
            p :?> BivariateCumulativeNormalDistributionWe04DPModel
        else
            let o = new BivariateCumulativeNormalDistributionWe04DPModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.rho                                = _rho 
    member this.Value                              x y   
                                                   = _value x y 
