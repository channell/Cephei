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
type ArithmeticAPOPathPricerModel
    ( Type                                         : ICell<Option.Type>
    , strike                                       : ICell<double>
    , discount                                     : ICell<double>
    ) as this =

    inherit Model<ArithmeticAPOPathPricer> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _strike                                    = strike
    let _discount                                  = discount
(*
    Functions
*)
    let _ArithmeticAPOPathPricer                   = cell (fun () -> new ArithmeticAPOPathPricer (Type.Value, strike.Value, discount.Value))
    let _value                                     (path : ICell<IPath>)   
                                                   = triv (fun () -> _ArithmeticAPOPathPricer.Value.value(path.Value))
    let _value1                                    (path : ICell<Path>)   
                                                   = triv (fun () -> _ArithmeticAPOPathPricer.Value.value(path.Value))
    do this.Bind(_ArithmeticAPOPathPricer)
(* 
    casting 
*)
    internal new () = ArithmeticAPOPathPricerModel(null,null,null)
    member internal this.Inject v = _ArithmeticAPOPathPricer.Value <- v
    static member Cast (p : ICell<ArithmeticAPOPathPricer>) = 
        if p :? ArithmeticAPOPathPricerModel then 
            p :?> ArithmeticAPOPathPricerModel
        else
            let o = new ArithmeticAPOPathPricerModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.strike                             = _strike 
    member this.discount                           = _discount 
    member this.Value                              path   
                                                   = _value path 
    member this.Value1                             path   
                                                   = _value1 path 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type ArithmeticAPOPathPricerModel1
    ( Type                                         : ICell<Option.Type>
    , strike                                       : ICell<double>
    , discount                                     : ICell<double>
    , runningSum                                   : ICell<double>
    ) as this =

    inherit Model<ArithmeticAPOPathPricer> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _strike                                    = strike
    let _discount                                  = discount
    let _runningSum                                = runningSum
(*
    Functions
*)
    let _ArithmeticAPOPathPricer                   = cell (fun () -> new ArithmeticAPOPathPricer (Type.Value, strike.Value, discount.Value, runningSum.Value))
    let _value                                     (path : ICell<IPath>)   
                                                   = triv (fun () -> _ArithmeticAPOPathPricer.Value.value(path.Value))
    let _value1                                    (path : ICell<Path>)   
                                                   = triv (fun () -> _ArithmeticAPOPathPricer.Value.value(path.Value))
    do this.Bind(_ArithmeticAPOPathPricer)
(* 
    casting 
*)
    internal new () = ArithmeticAPOPathPricerModel1(null,null,null,null)
    member internal this.Inject v = _ArithmeticAPOPathPricer.Value <- v
    static member Cast (p : ICell<ArithmeticAPOPathPricer>) = 
        if p :? ArithmeticAPOPathPricerModel1 then 
            p :?> ArithmeticAPOPathPricerModel1
        else
            let o = new ArithmeticAPOPathPricerModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.strike                             = _strike 
    member this.discount                           = _discount 
    member this.runningSum                         = _runningSum 
    member this.Value                              path   
                                                   = _value path 
    member this.Value1                             path   
                                                   = _value1 path 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type ArithmeticAPOPathPricerModel2
    ( Type                                         : ICell<Option.Type>
    , strike                                       : ICell<double>
    , discount                                     : ICell<double>
    , runningSum                                   : ICell<double>
    , pastFixings                                  : ICell<int>
    ) as this =

    inherit Model<ArithmeticAPOPathPricer> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _strike                                    = strike
    let _discount                                  = discount
    let _runningSum                                = runningSum
    let _pastFixings                               = pastFixings
(*
    Functions
*)
    let _ArithmeticAPOPathPricer                   = cell (fun () -> new ArithmeticAPOPathPricer (Type.Value, strike.Value, discount.Value, runningSum.Value, pastFixings.Value))
    let _value                                     (path : ICell<IPath>)   
                                                   = triv (fun () -> _ArithmeticAPOPathPricer.Value.value(path.Value))
    let _value1                                    (path : ICell<Path>)   
                                                   = triv (fun () -> _ArithmeticAPOPathPricer.Value.value(path.Value))
    do this.Bind(_ArithmeticAPOPathPricer)
(* 
    casting 
*)
    internal new () = ArithmeticAPOPathPricerModel2(null,null,null,null,null)
    member internal this.Inject v = _ArithmeticAPOPathPricer.Value <- v
    static member Cast (p : ICell<ArithmeticAPOPathPricer>) = 
        if p :? ArithmeticAPOPathPricerModel2 then 
            p :?> ArithmeticAPOPathPricerModel2
        else
            let o = new ArithmeticAPOPathPricerModel2 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.strike                             = _strike 
    member this.discount                           = _discount 
    member this.runningSum                         = _runningSum 
    member this.pastFixings                        = _pastFixings 
    member this.Value                              path   
                                                   = _value path 
    member this.Value1                             path   
                                                   = _value1 path 
