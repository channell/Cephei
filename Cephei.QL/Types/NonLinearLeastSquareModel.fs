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
  Non-linear least-square method.   Using a given optimization algorithm (default is conjugate gradient),  min r(x) : x in R^n  where r(x) = |f(x)|^2 is the Euclidean norm of f(x) for some vector-valued function f from R^n to R^m f = (f_1, ..., f_m) with f_i(x) = b_i - where b is the vector of target data and phi is a scalar function.  Assuming the differentiability of f the gradient of r is defined by grad r(x) = f'(x)^t.f(x)
! Default constructor
  </summary> *)
[<AutoSerializable(true)>]
type NonLinearLeastSquareModel
    ( c                                            : ICell<Constraint>
    , accuracy                                     : ICell<double>
    , maxiter                                      : ICell<int>
    , om                                           : ICell<OptimizationMethod>
    ) as this =

    inherit Model<NonLinearLeastSquare> ()
(*
    Parameters
*)
    let _c                                         = c
    let _accuracy                                  = accuracy
    let _maxiter                                   = maxiter
    let _om                                        = om
(*
    Functions
*)
    let mutable
        _NonLinearLeastSquare                      = make (fun () -> new NonLinearLeastSquare (c.Value, accuracy.Value, maxiter.Value, om.Value))
    let _exitFlag                                  = triv _NonLinearLeastSquare (fun () -> _NonLinearLeastSquare.Value.exitFlag())
    let _lastValue                                 = triv _NonLinearLeastSquare (fun () -> _NonLinearLeastSquare.Value.lastValue())
    let _perform                                   (lsProblem : ICell<LeastSquareProblem>)   
                                                   = triv _NonLinearLeastSquare (fun () -> _NonLinearLeastSquare.Value.perform(ref lsProblem.Value))
    let _residualNorm                              = triv _NonLinearLeastSquare (fun () -> _NonLinearLeastSquare.Value.residualNorm())
    let _setInitialValue                           (initialValue : ICell<Vector>)   
                                                   = triv _NonLinearLeastSquare (fun () -> _NonLinearLeastSquare.Value.setInitialValue(initialValue.Value)
                                                                                           _NonLinearLeastSquare.Value)
    do this.Bind(_NonLinearLeastSquare)
(* 
    casting 
*)
    internal new () = new NonLinearLeastSquareModel(null,null,null,null)
    member internal this.Inject v = _NonLinearLeastSquare <- v
    static member Cast (p : ICell<NonLinearLeastSquare>) = 
        if p :? NonLinearLeastSquareModel then 
            p :?> NonLinearLeastSquareModel
        else
            let o = new NonLinearLeastSquareModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.c                                  = _c 
    member this.accuracy                           = _accuracy 
    member this.maxiter                            = _maxiter 
    member this.om                                 = _om 
    member this.ExitFlag                           = _exitFlag
    member this.LastValue                          = _lastValue
    member this.Perform                            lsProblem   
                                                   = _perform lsProblem 
    member this.ResidualNorm                       = _residualNorm
    member this.SetInitialValue                    initialValue   
                                                   = _setInitialValue initialValue 
(* <summary>
  Non-linear least-square method.   Using a given optimization algorithm (default is conjugate gradient),  min r(x) : x in R^n  where r(x) = |f(x)|^2 is the Euclidean norm of f(x) for some vector-valued function f from R^n to R^m f = (f_1, ..., f_m) with f_i(x) = b_i - where b is the vector of target data and phi is a scalar function.  Assuming the differentiability of f the gradient of r is defined by grad r(x) = f'(x)^t.f(x)
! Default constructor
  </summary> *)
[<AutoSerializable(true)>]
type NonLinearLeastSquareModel1
    ( c                                            : ICell<Constraint>
    , accuracy                                     : ICell<double>
    ) as this =

    inherit Model<NonLinearLeastSquare> ()
(*
    Parameters
*)
    let _c                                         = c
    let _accuracy                                  = accuracy
(*
    Functions
*)
    let mutable
        _NonLinearLeastSquare                      = make (fun () -> new NonLinearLeastSquare (c.Value, accuracy.Value))
    let _exitFlag                                  = triv _NonLinearLeastSquare (fun () -> _NonLinearLeastSquare.Value.exitFlag())
    let _lastValue                                 = triv _NonLinearLeastSquare (fun () -> _NonLinearLeastSquare.Value.lastValue())
    let _perform                                   (lsProblem : ICell<LeastSquareProblem>)   
                                                   = triv _NonLinearLeastSquare (fun () -> _NonLinearLeastSquare.Value.perform(ref lsProblem.Value))
    let _residualNorm                              = triv _NonLinearLeastSquare (fun () -> _NonLinearLeastSquare.Value.residualNorm())
    let _setInitialValue                           (initialValue : ICell<Vector>)   
                                                   = triv _NonLinearLeastSquare (fun () -> _NonLinearLeastSquare.Value.setInitialValue(initialValue.Value)
                                                                                           _NonLinearLeastSquare.Value)
    do this.Bind(_NonLinearLeastSquare)
(* 
    casting 
*)
    internal new () = new NonLinearLeastSquareModel1(null,null)
    member internal this.Inject v = _NonLinearLeastSquare <- v
    static member Cast (p : ICell<NonLinearLeastSquare>) = 
        if p :? NonLinearLeastSquareModel1 then 
            p :?> NonLinearLeastSquareModel1
        else
            let o = new NonLinearLeastSquareModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.c                                  = _c 
    member this.accuracy                           = _accuracy 
    member this.ExitFlag                           = _exitFlag
    member this.LastValue                          = _lastValue
    member this.Perform                            lsProblem   
                                                   = _perform lsProblem 
    member this.ResidualNorm                       = _residualNorm
    member this.SetInitialValue                    initialValue   
                                                   = _setInitialValue initialValue 
(* <summary>
  Non-linear least-square method.   Using a given optimization algorithm (default is conjugate gradient),  min r(x) : x in R^n  where r(x) = |f(x)|^2 is the Euclidean norm of f(x) for some vector-valued function f from R^n to R^m f = (f_1, ..., f_m) with f_i(x) = b_i - where b is the vector of target data and phi is a scalar function.  Assuming the differentiability of f the gradient of r is defined by grad r(x) = f'(x)^t.f(x)

  </summary> *)
[<AutoSerializable(true)>]
type NonLinearLeastSquareModel2
    ( c                                            : ICell<Constraint>
    , accuracy                                     : ICell<double>
    , maxiter                                      : ICell<int>
    ) as this =

    inherit Model<NonLinearLeastSquare> ()
(*
    Parameters
*)
    let _c                                         = c
    let _accuracy                                  = accuracy
    let _maxiter                                   = maxiter
(*
    Functions
*)
    let mutable
        _NonLinearLeastSquare                      = make (fun () -> new NonLinearLeastSquare (c.Value, accuracy.Value, maxiter.Value))
    let _exitFlag                                  = triv _NonLinearLeastSquare (fun () -> _NonLinearLeastSquare.Value.exitFlag())
    let _lastValue                                 = triv _NonLinearLeastSquare (fun () -> _NonLinearLeastSquare.Value.lastValue())
    let _perform                                   (lsProblem : ICell<LeastSquareProblem>)   
                                                   = triv _NonLinearLeastSquare (fun () -> _NonLinearLeastSquare.Value.perform(ref lsProblem.Value))
    let _residualNorm                              = triv _NonLinearLeastSquare (fun () -> _NonLinearLeastSquare.Value.residualNorm())
    let _setInitialValue                           (initialValue : ICell<Vector>)   
                                                   = triv _NonLinearLeastSquare (fun () -> _NonLinearLeastSquare.Value.setInitialValue(initialValue.Value)
                                                                                           _NonLinearLeastSquare.Value)
    do this.Bind(_NonLinearLeastSquare)
(* 
    casting 
*)
    internal new () = new NonLinearLeastSquareModel2(null,null,null)
    member internal this.Inject v = _NonLinearLeastSquare <- v
    static member Cast (p : ICell<NonLinearLeastSquare>) = 
        if p :? NonLinearLeastSquareModel2 then 
            p :?> NonLinearLeastSquareModel2
        else
            let o = new NonLinearLeastSquareModel2 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.c                                  = _c 
    member this.accuracy                           = _accuracy 
    member this.maxiter                            = _maxiter 
    member this.ExitFlag                           = _exitFlag
    member this.LastValue                          = _lastValue
    member this.Perform                            lsProblem   
                                                   = _perform lsProblem 
    member this.ResidualNorm                       = _residualNorm
    member this.SetInitialValue                    initialValue   
                                                   = _setInitialValue initialValue 
(* <summary>
  Non-linear least-square method.   Using a given optimization algorithm (default is conjugate gradient),  min r(x) : x in R^n  where r(x) = |f(x)|^2 is the Euclidean norm of f(x) for some vector-valued function f from R^n to R^m f = (f_1, ..., f_m) with f_i(x) = b_i - where b is the vector of target data and phi is a scalar function.  Assuming the differentiability of f the gradient of r is defined by grad r(x) = f'(x)^t.f(x)

  </summary> *)
[<AutoSerializable(true)>]
type NonLinearLeastSquareModel3
    ( c                                            : ICell<Constraint>
    ) as this =

    inherit Model<NonLinearLeastSquare> ()
(*
    Parameters
*)
    let _c                                         = c
(*
    Functions
*)
    let mutable
        _NonLinearLeastSquare                      = make (fun () -> new NonLinearLeastSquare (c.Value))
    let _exitFlag                                  = triv _NonLinearLeastSquare (fun () -> _NonLinearLeastSquare.Value.exitFlag())
    let _lastValue                                 = triv _NonLinearLeastSquare (fun () -> _NonLinearLeastSquare.Value.lastValue())
    let _perform                                   (lsProblem : ICell<LeastSquareProblem>)   
                                                   = triv _NonLinearLeastSquare (fun () -> _NonLinearLeastSquare.Value.perform(ref lsProblem.Value))
    let _residualNorm                              = triv _NonLinearLeastSquare (fun () -> _NonLinearLeastSquare.Value.residualNorm())
    let _setInitialValue                           (initialValue : ICell<Vector>)   
                                                   = triv _NonLinearLeastSquare (fun () -> _NonLinearLeastSquare.Value.setInitialValue(initialValue.Value)
                                                                                           _NonLinearLeastSquare.Value)
    do this.Bind(_NonLinearLeastSquare)
(* 
    casting 
*)
    internal new () = new NonLinearLeastSquareModel3(null)
    member internal this.Inject v = _NonLinearLeastSquare <- v
    static member Cast (p : ICell<NonLinearLeastSquare>) = 
        if p :? NonLinearLeastSquareModel3 then 
            p :?> NonLinearLeastSquareModel3
        else
            let o = new NonLinearLeastSquareModel3 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.c                                  = _c 
    member this.ExitFlag                           = _exitFlag
    member this.LastValue                          = _lastValue
    member this.Perform                            lsProblem   
                                                   = _perform lsProblem 
    member this.ResidualNorm                       = _residualNorm
    member this.SetInitialValue                    initialValue   
                                                   = _setInitialValue initialValue 
