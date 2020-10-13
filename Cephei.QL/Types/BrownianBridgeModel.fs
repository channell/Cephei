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
  This class generates normalized (i.e., unit-variance) paths as sequences of variations. In order to obtain the actual path of the underlying, the returned variations must be multiplied by the integrated variance (including time) over the corresponding time step.  mcarlo
! generic times
  </summary> *)
[<AutoSerializable(true)>]
type BrownianBridgeModel
    ( timeGrid                                     : ICell<TimeGrid>
    ) as this =

    inherit Model<BrownianBridge> ()
(*
    Parameters
*)
    let _timeGrid                                  = timeGrid
(*
    Functions
*)
    let _BrownianBridge                            = cell (fun () -> new BrownianBridge (timeGrid.Value))
    let _size                                      = triv (fun () -> _BrownianBridge.Value.size())
    let _times                                     = triv (fun () -> _BrownianBridge.Value.times())
    let _transform                                 (Begin : ICell<Generic.List<double>>) (output : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _BrownianBridge.Value.transform(Begin.Value, output.Value)
                                                                     _BrownianBridge.Value)
    do this.Bind(_BrownianBridge)
(* 
    casting 
*)
    internal new () = new BrownianBridgeModel(null)
    member internal this.Inject v = _BrownianBridge.Value <- v
    static member Cast (p : ICell<BrownianBridge>) = 
        if p :? BrownianBridgeModel then 
            p :?> BrownianBridgeModel
        else
            let o = new BrownianBridgeModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.timeGrid                           = _timeGrid 
    member this.Size                               = _size
    member this.Times                              = _times
    member this.Transform                          Begin output   
                                                   = _transform Begin output 
(* <summary>
  This class generates normalized (i.e., unit-variance) paths as sequences of variations. In order to obtain the actual path of the underlying, the returned variations must be multiplied by the integrated variance (including time) over the corresponding time step.  mcarlo
! \note the starting time of the path is assumed to be 0 and must not be included
  </summary> *)
[<AutoSerializable(true)>]
type BrownianBridgeModel1
    ( times                                        : ICell<Generic.List<double>>
    ) as this =

    inherit Model<BrownianBridge> ()
(*
    Parameters
*)
    let _times                                     = times
(*
    Functions
*)
    let _BrownianBridge                            = cell (fun () -> new BrownianBridge (times.Value))
    let _size                                      = triv (fun () -> _BrownianBridge.Value.size())
    let _times                                     = triv (fun () -> _BrownianBridge.Value.times())
    let _transform                                 (Begin : ICell<Generic.List<double>>) (output : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _BrownianBridge.Value.transform(Begin.Value, output.Value)
                                                                     _BrownianBridge.Value)
    do this.Bind(_BrownianBridge)
(* 
    casting 
*)
    internal new () = new BrownianBridgeModel1(null)
    member internal this.Inject v = _BrownianBridge.Value <- v
    static member Cast (p : ICell<BrownianBridge>) = 
        if p :? BrownianBridgeModel1 then 
            p :?> BrownianBridgeModel1
        else
            let o = new BrownianBridgeModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.times                              = _times 
    member this.Size                               = _size
    member this.Times                              = _times
    member this.Transform                          Begin output   
                                                   = _transform Begin output 
(* <summary>
  This class generates normalized (i.e., unit-variance) paths as sequences of variations. In order to obtain the actual path of the underlying, the returned variations must be multiplied by the integrated variance (including time) over the corresponding time step.  mcarlo
! unit-time path
  </summary> *)
[<AutoSerializable(true)>]
type BrownianBridgeModel2
    ( steps                                        : ICell<int>
    ) as this =

    inherit Model<BrownianBridge> ()
(*
    Parameters
*)
    let _steps                                     = steps
(*
    Functions
*)
    let _BrownianBridge                            = cell (fun () -> new BrownianBridge (steps.Value))
    let _size                                      = triv (fun () -> _BrownianBridge.Value.size())
    let _times                                     = triv (fun () -> _BrownianBridge.Value.times())
    let _transform                                 (Begin : ICell<Generic.List<double>>) (output : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _BrownianBridge.Value.transform(Begin.Value, output.Value)
                                                                     _BrownianBridge.Value)
    do this.Bind(_BrownianBridge)
(* 
    casting 
*)
    internal new () = new BrownianBridgeModel2(null)
    member internal this.Inject v = _BrownianBridge.Value <- v
    static member Cast (p : ICell<BrownianBridge>) = 
        if p :? BrownianBridgeModel2 then 
            p :?> BrownianBridgeModel2
        else
            let o = new BrownianBridgeModel2 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.steps                              = _steps 
    member this.Size                               = _size
    member this.Times                              = _times
    member this.Transform                          Begin output   
                                                   = _transform Begin output 
