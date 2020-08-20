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
  This algorithm enables a localised fitting for non-local interpolation methods.  As in the similar class (IterativeBootstrap) the input term structure is solved on a number of market instruments which are passed as a vector of handles to BootstrapHelper instances. Their maturities mark the boundaries of the interpolated segments.  Unlike the IterativeBootstrap class, the solution for each interpolated segment is derived using a local approximation. This restricts the risk profile s.t.  the risk is localised. Therefore, we obtain a local IR risk profile whilst using a smoother interpolation method. Particularly good for the convex-monotone spline method.

  </summary> *)
[<AutoSerializable(true)>]
type LocalBootstrapModel<'T, 'U when 'T :> Curve<'U> and 'T : (new : unit -> 'T) and 'U :> TermStructure>
    ( localisation                                 : ICell<int>
    , forcePositive                                : ICell<bool>
    ) as this =

    inherit Model<LocalBootstrap<'T,'U>> ()
(*
    Parameters
*)
    let _localisation                              = localisation
    let _forcePositive                             = forcePositive
(*
    Functions
*)
    let _LocalBootstrap                            = cell (fun () -> new LocalBootstrap<'T,'U> (localisation.Value, forcePositive.Value))
    let _calculate                                 = cell (fun () -> _LocalBootstrap.Value.calculate()
                                                                     _LocalBootstrap.Value)
    let _setup                                     (ts : ICell<'T>)   
                                                   = cell (fun () -> _LocalBootstrap.Value.setup(ts.Value)
                                                                     _LocalBootstrap.Value)
    do this.Bind(_LocalBootstrap)

(* 
    Externally visible/bindable properties
*)
    member this.localisation                       = _localisation 
    member this.forcePositive                      = _forcePositive 
    member this.Calculate                          = _calculate
    member this.Setup                              ts   
                                                   = _setup ts 
(* <summary>
  This algorithm enables a localised fitting for non-local interpolation methods.  As in the similar class (IterativeBootstrap) the input term structure is solved on a number of market instruments which are passed as a vector of handles to BootstrapHelper instances. Their maturities mark the boundaries of the interpolated segments.  Unlike the IterativeBootstrap class, the solution for each interpolated segment is derived using a local approximation. This restricts the risk profile s.t.  the risk is localised. Therefore, we obtain a local IR risk profile whilst using a smoother interpolation method. Particularly good for the convex-monotone spline method.

  </summary> *)
[<AutoSerializable(true)>]
type LocalBootstrapModel1<'T, 'U when 'T :> Curve<'U> and 'T : (new : unit -> 'T) and 'U :> TermStructure>
    () as this =
    inherit Model<LocalBootstrap<'T,'U>> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _LocalBootstrap                            = cell (fun () -> new LocalBootstrap<'T,'U> ())
    let _calculate                                 = cell (fun () -> _LocalBootstrap.Value.calculate()
                                                                     _LocalBootstrap.Value)
    let _setup                                     (ts : ICell<'T>)   
                                                   = cell (fun () -> _LocalBootstrap.Value.setup(ts.Value)
                                                                     _LocalBootstrap.Value)
    do this.Bind(_LocalBootstrap)

(* 
    Externally visible/bindable properties
*)
    member this.Calculate                          = _calculate
    member this.Setup                              ts   
                                                   = _setup ts 
