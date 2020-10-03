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
type Joshi4Model
    ( Process                                      : ICell<StochasticProcess1D>
    , End                                          : ICell<double>
    , steps                                        : ICell<int>
    , strike                                       : ICell<double>
    ) as this =

    inherit Model<Joshi4> ()
(*
    Parameters
*)
    let _Process                                   = Process
    let _End                                       = End
    let _steps                                     = steps
    let _strike                                    = strike
(*
    Functions
*)
    let _Joshi4                                    = cell (fun () -> new Joshi4 (Process.Value, End.Value, steps.Value, strike.Value))
    let _factory                                   (Process : ICell<StochasticProcess1D>) (End : ICell<double>) (steps : ICell<int>) (strike : ICell<double>)   
                                                   = triv (fun () -> _Joshi4.Value.factory(Process.Value, End.Value, steps.Value, strike.Value))
    let _probability                               (x : ICell<int>) (y : ICell<int>) (branch : ICell<int>)   
                                                   = triv (fun () -> _Joshi4.Value.probability(x.Value, y.Value, branch.Value))
    let _underlying                                (i : ICell<int>) (index : ICell<int>)   
                                                   = triv (fun () -> _Joshi4.Value.underlying(i.Value, index.Value))
    let _descendant                                (x : ICell<int>) (index : ICell<int>) (branch : ICell<int>)   
                                                   = triv (fun () -> _Joshi4.Value.descendant(x.Value, index.Value, branch.Value))
    let _size                                      (i : ICell<int>)   
                                                   = triv (fun () -> _Joshi4.Value.size(i.Value))
    let _columns                                   = triv (fun () -> _Joshi4.Value.columns())
    do this.Bind(_Joshi4)
(* 
    casting 
*)
    internal new () = Joshi4Model(null,null,null,null)
    member internal this.Inject v = _Joshi4.Value <- v
    static member Cast (p : ICell<Joshi4>) = 
        if p :? Joshi4Model then 
            p :?> Joshi4Model
        else
            let o = new Joshi4Model ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.End                                = _End 
    member this.steps                              = _steps 
    member this.strike                             = _strike 
    member this.Factory                            Process End steps strike   
                                                   = _factory Process End steps strike 
    member this.Probability                        x y branch   
                                                   = _probability x y branch 
    member this.Underlying                         i index   
                                                   = _underlying i index 
    member this.Descendant                         x index branch   
                                                   = _descendant x index branch 
    member this.Size                               i   
                                                   = _size i 
    member this.Columns                            = _columns
(* <summary>

parameterless constructor is requried for generics
  </summary> *)
[<AutoSerializable(true)>]
type Joshi4Model1
    () as this =
    inherit Model<Joshi4> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _Joshi4                                    = cell (fun () -> new Joshi4 ())
    let _factory                                   (Process : ICell<StochasticProcess1D>) (End : ICell<double>) (steps : ICell<int>) (strike : ICell<double>)   
                                                   = triv (fun () -> _Joshi4.Value.factory(Process.Value, End.Value, steps.Value, strike.Value))
    let _probability                               (x : ICell<int>) (y : ICell<int>) (branch : ICell<int>)   
                                                   = triv (fun () -> _Joshi4.Value.probability(x.Value, y.Value, branch.Value))
    let _underlying                                (i : ICell<int>) (index : ICell<int>)   
                                                   = triv (fun () -> _Joshi4.Value.underlying(i.Value, index.Value))
    let _descendant                                (x : ICell<int>) (index : ICell<int>) (branch : ICell<int>)   
                                                   = triv (fun () -> _Joshi4.Value.descendant(x.Value, index.Value, branch.Value))
    let _size                                      (i : ICell<int>)   
                                                   = triv (fun () -> _Joshi4.Value.size(i.Value))
    let _columns                                   = triv (fun () -> _Joshi4.Value.columns())
    do this.Bind(_Joshi4)
(* 
    casting 
*)
    
    member internal this.Inject v = _Joshi4.Value <- v
    static member Cast (p : ICell<Joshi4>) = 
        if p :? Joshi4Model1 then 
            p :?> Joshi4Model1
        else
            let o = new Joshi4Model1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Factory                            Process End steps strike   
                                                   = _factory Process End steps strike 
    member this.Probability                        x y branch   
                                                   = _probability x y branch 
    member this.Underlying                         i index   
                                                   = _underlying i index 
    member this.Descendant                         x index branch   
                                                   = _descendant x index branch 
    member this.Size                               i   
                                                   = _size i 
    member this.Columns                            = _columns
