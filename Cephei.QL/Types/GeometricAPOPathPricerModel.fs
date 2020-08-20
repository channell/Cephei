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
type GeometricAPOPathPricerModel
    ( Type                                         : ICell<Option.Type>
    , strike                                       : ICell<double>
    , discount                                     : ICell<double>
    ) as this =

    inherit Model<GeometricAPOPathPricer> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _strike                                    = strike
    let _discount                                  = discount
(*
    Functions
*)
    let _GeometricAPOPathPricer                    = cell (fun () -> new GeometricAPOPathPricer (Type.Value, strike.Value, discount.Value))
    let _value                                     (path : ICell<Path>)   
                                                   = cell (fun () -> _GeometricAPOPathPricer.Value.value(path.Value))
    do this.Bind(_GeometricAPOPathPricer)

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.strike                             = _strike 
    member this.discount                           = _discount 
    member this.Value                              path   
                                                   = _value path 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type GeometricAPOPathPricerModel1
    ( Type                                         : ICell<Option.Type>
    , strike                                       : ICell<double>
    , discount                                     : ICell<double>
    , runningProduct                               : ICell<double>
    ) as this =

    inherit Model<GeometricAPOPathPricer> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _strike                                    = strike
    let _discount                                  = discount
    let _runningProduct                            = runningProduct
(*
    Functions
*)
    let _GeometricAPOPathPricer                    = cell (fun () -> new GeometricAPOPathPricer (Type.Value, strike.Value, discount.Value, runningProduct.Value))
    let _value                                     (path : ICell<Path>)   
                                                   = cell (fun () -> _GeometricAPOPathPricer.Value.value(path.Value))
    do this.Bind(_GeometricAPOPathPricer)

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.strike                             = _strike 
    member this.discount                           = _discount 
    member this.runningProduct                     = _runningProduct 
    member this.Value                              path   
                                                   = _value path 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type GeometricAPOPathPricerModel2
    ( Type                                         : ICell<Option.Type>
    , strike                                       : ICell<double>
    , discount                                     : ICell<double>
    , runningProduct                               : ICell<double>
    , pastFixings                                  : ICell<int>
    ) as this =

    inherit Model<GeometricAPOPathPricer> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _strike                                    = strike
    let _discount                                  = discount
    let _runningProduct                            = runningProduct
    let _pastFixings                               = pastFixings
(*
    Functions
*)
    let _GeometricAPOPathPricer                    = cell (fun () -> new GeometricAPOPathPricer (Type.Value, strike.Value, discount.Value, runningProduct.Value, pastFixings.Value))
    let _value                                     (path : ICell<Path>)   
                                                   = cell (fun () -> _GeometricAPOPathPricer.Value.value(path.Value))
    do this.Bind(_GeometricAPOPathPricer)

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.strike                             = _strike 
    member this.discount                           = _discount 
    member this.runningProduct                     = _runningProduct 
    member this.pastFixings                        = _pastFixings 
    member this.Value                              path   
                                                   = _value path 
