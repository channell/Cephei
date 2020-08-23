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
Armijo line search.  (see Polak, Algorithms and consistent approximations, Optimization, volume 124 of Applied Mathematical Sciences, Springer-Verlag, NY, 1997)

  </summary> *)
[<AutoSerializable(true)>]
type ArmijoLineSearchModel
    ( eps                                          : ICell<double>
    ) as this =

    inherit Model<ArmijoLineSearch> ()
(*
    Parameters
*)
    let _eps                                       = eps
(*
    Functions
*)
    let _ArmijoLineSearch                          = cell (fun () -> new ArmijoLineSearch (eps.Value))
    let _value                                     (P : ICell<Problem>) (ecType : ICell<EndCriteria.Type ref>) (endCriteria : ICell<EndCriteria>) (t_ini : ICell<double>)   
                                                   = triv (fun () -> _ArmijoLineSearch.Value.value(P.Value, ecType.Value, endCriteria.Value, t_ini.Value))
    let _lastFunctionValue                         = triv (fun () -> _ArmijoLineSearch.Value.lastFunctionValue())
    let _lastGradient                              = triv (fun () -> _ArmijoLineSearch.Value.lastGradient())
    let _lastGradientNorm2                         = triv (fun () -> _ArmijoLineSearch.Value.lastGradientNorm2())
    let _lastX                                     = triv (fun () -> _ArmijoLineSearch.Value.lastX())
    let _searchDirection                           = triv (fun () -> _ArmijoLineSearch.Value.searchDirection)
    let _succeed                                   = triv (fun () -> _ArmijoLineSearch.Value.succeed())
    let _update                                    (data : ICell<Vector ref>) (direction : ICell<Vector>) (beta : ICell<double>) (Constraint : ICell<Constraint>)   
                                                   = triv (fun () -> _ArmijoLineSearch.Value.update(data.Value, direction.Value, beta.Value, Constraint.Value))
    do this.Bind(_ArmijoLineSearch)

(* 
    Externally visible/bindable properties
*)
    member this.eps                                = _eps 
    member this.Value                              P ecType endCriteria t_ini   
                                                   = _value P ecType endCriteria t_ini 
    member this.LastFunctionValue                  = _lastFunctionValue
    member this.LastGradient                       = _lastGradient
    member this.LastGradientNorm2                  = _lastGradientNorm2
    member this.LastX                              = _lastX
    member this.SearchDirection                    = _searchDirection
    member this.Succeed                            = _succeed
    member this.Update                             data direction beta Constraint   
                                                   = _update data direction beta Constraint 
(* <summary>
Armijo line search.  (see Polak, Algorithms and consistent approximations, Optimization, volume 124 of Applied Mathematical Sciences, Springer-Verlag, NY, 1997)
! Default constructor
  </summary> *)
[<AutoSerializable(true)>]
type ArmijoLineSearchModel1
    ( eps                                          : ICell<double>
    , alpha                                        : ICell<double>
    ) as this =

    inherit Model<ArmijoLineSearch> ()
(*
    Parameters
*)
    let _eps                                       = eps
    let _alpha                                     = alpha
(*
    Functions
*)
    let _ArmijoLineSearch                          = cell (fun () -> new ArmijoLineSearch (eps.Value, alpha.Value))
    let _value                                     (P : ICell<Problem>) (ecType : ICell<EndCriteria.Type ref>) (endCriteria : ICell<EndCriteria>) (t_ini : ICell<double>)   
                                                   = triv (fun () -> _ArmijoLineSearch.Value.value(P.Value, ecType.Value, endCriteria.Value, t_ini.Value))
    let _lastFunctionValue                         = triv (fun () -> _ArmijoLineSearch.Value.lastFunctionValue())
    let _lastGradient                              = triv (fun () -> _ArmijoLineSearch.Value.lastGradient())
    let _lastGradientNorm2                         = triv (fun () -> _ArmijoLineSearch.Value.lastGradientNorm2())
    let _lastX                                     = triv (fun () -> _ArmijoLineSearch.Value.lastX())
    let _searchDirection                           = triv (fun () -> _ArmijoLineSearch.Value.searchDirection)
    let _succeed                                   = triv (fun () -> _ArmijoLineSearch.Value.succeed())
    let _update                                    (data : ICell<Vector>) (direction : ICell<Vector>) (beta : ICell<double>) (Constraint : ICell<Constraint>)   
                                                   = triv (fun () -> _ArmijoLineSearch.Value.update(ref data.Value, direction.Value, beta.Value, Constraint.Value))
    do this.Bind(_ArmijoLineSearch)

(* 
    Externally visible/bindable properties
*)
    member this.eps                                = _eps 
    member this.alpha                              = _alpha 
    member this.Value                              P ecType endCriteria t_ini   
                                                   = _value P ecType endCriteria t_ini 
    member this.LastFunctionValue                  = _lastFunctionValue
    member this.LastGradient                       = _lastGradient
    member this.LastGradientNorm2                  = _lastGradientNorm2
    member this.LastX                              = _lastX
    member this.SearchDirection                    = _searchDirection
    member this.Succeed                            = _succeed
    member this.Update                             data direction beta Constraint   
                                                   = _update data direction beta Constraint 
(* <summary>
Armijo line search.  (see Polak, Algorithms and consistent approximations, Optimization, volume 124 of Applied Mathematical Sciences, Springer-Verlag, NY, 1997)

  </summary> *)
[<AutoSerializable(true)>]
type ArmijoLineSearchModel2
    ( eps                                          : ICell<double>
    , alpha                                        : ICell<double>
    , beta                                         : ICell<double>
    ) as this =

    inherit Model<ArmijoLineSearch> ()
(*
    Parameters
*)
    let _eps                                       = eps
    let _alpha                                     = alpha
    let _beta                                      = beta
(*
    Functions
*)
    let _ArmijoLineSearch                          = cell (fun () -> new ArmijoLineSearch (eps.Value, alpha.Value, beta.Value))
    let _value                                     (P : ICell<Problem>) (ecType : ICell<EndCriteria.Type>) (endCriteria : ICell<EndCriteria>) (t_ini : ICell<double>)   
                                                   = triv (fun () -> _ArmijoLineSearch.Value.value(P.Value, ref ecType.Value, endCriteria.Value, t_ini.Value))
    let _lastFunctionValue                         = triv (fun () -> _ArmijoLineSearch.Value.lastFunctionValue())
    let _lastGradient                              = triv (fun () -> _ArmijoLineSearch.Value.lastGradient())
    let _lastGradientNorm2                         = triv (fun () -> _ArmijoLineSearch.Value.lastGradientNorm2())
    let _lastX                                     = triv (fun () -> _ArmijoLineSearch.Value.lastX())
    let _searchDirection                           = triv (fun () -> _ArmijoLineSearch.Value.searchDirection)
    let _succeed                                   = triv (fun () -> _ArmijoLineSearch.Value.succeed())
    let _update                                    (data : ICell<Vector ref>) (direction : ICell<Vector>) (beta : ICell<double>) (Constraint : ICell<Constraint>)   
                                                   = triv (fun () -> _ArmijoLineSearch.Value.update(data.Value, direction.Value, beta.Value, Constraint.Value))
    do this.Bind(_ArmijoLineSearch)

(* 
    Externally visible/bindable properties
*)
    member this.eps                                = _eps 
    member this.alpha                              = _alpha 
    member this.beta                               = _beta 
    member this.Value                              P ecType endCriteria t_ini   
                                                   = _value P ecType endCriteria t_ini 
    member this.LastFunctionValue                  = _lastFunctionValue
    member this.LastGradient                       = _lastGradient
    member this.LastGradientNorm2                  = _lastGradientNorm2
    member this.LastX                              = _lastX
    member this.SearchDirection                    = _searchDirection
    member this.Succeed                            = _succeed
    member this.Update                             data direction beta Constraint   
                                                   = _update data direction beta Constraint 
(* <summary>
Armijo line search.  (see Polak, Algorithms and consistent approximations, Optimization, volume 124 of Applied Mathematical Sciences, Springer-Verlag, NY, 1997)

  </summary> *)
[<AutoSerializable(true)>]
type ArmijoLineSearchModel3
    () as this =
    inherit Model<ArmijoLineSearch> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _ArmijoLineSearch                          = cell (fun () -> new ArmijoLineSearch ())
    let _value                                     (P : ICell<Problem>) (ecType : ICell<EndCriteria.Type ref>) (endCriteria : ICell<EndCriteria>) (t_ini : ICell<double>)   
                                                   = triv (fun () -> _ArmijoLineSearch.Value.value(P.Value, ecType.Value, endCriteria.Value, t_ini.Value))
    let _lastFunctionValue                         = triv (fun () -> _ArmijoLineSearch.Value.lastFunctionValue())
    let _lastGradient                              = triv (fun () -> _ArmijoLineSearch.Value.lastGradient())
    let _lastGradientNorm2                         = triv (fun () -> _ArmijoLineSearch.Value.lastGradientNorm2())
    let _lastX                                     = triv (fun () -> _ArmijoLineSearch.Value.lastX())
    let _searchDirection                           = triv (fun () -> _ArmijoLineSearch.Value.searchDirection)
    let _succeed                                   = triv (fun () -> _ArmijoLineSearch.Value.succeed())
    let _update                                    (data : ICell<Vector ref>) (direction : ICell<Vector>) (beta : ICell<double>) (Constraint : ICell<Constraint>)   
                                                   = triv (fun () -> _ArmijoLineSearch.Value.update(data.Value, direction.Value, beta.Value, Constraint.Value))
    do this.Bind(_ArmijoLineSearch)

(* 
    Externally visible/bindable properties
*)
    member this.Value                              P ecType endCriteria t_ini   
                                                   = _value P ecType endCriteria t_ini 
    member this.LastFunctionValue                  = _lastFunctionValue
    member this.LastGradient                       = _lastGradient
    member this.LastGradientNorm2                  = _lastGradientNorm2
    member this.LastX                              = _lastX
    member this.SearchDirection                    = _searchDirection
    member this.Succeed                            = _succeed
    member this.Update                             data direction beta Constraint   
                                                   = _update data direction beta Constraint 
