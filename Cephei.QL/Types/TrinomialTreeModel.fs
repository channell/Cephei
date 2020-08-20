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
type TrinomialTreeModel
    ( Process                                      : ICell<StochasticProcess1D>
    , timeGrid                                     : ICell<TimeGrid>
    ) as this =

    inherit Model<TrinomialTree> ()
(*
    Parameters
*)
    let _Process                                   = Process
    let _timeGrid                                  = timeGrid
(*
    Functions
*)
    let _TrinomialTree                             = cell (fun () -> new TrinomialTree (Process.Value, timeGrid.Value))
    let _descendant                                (i : ICell<int>) (index : ICell<int>) (branch : ICell<int>)   
                                                   = cell (fun () -> _TrinomialTree.Value.descendant(i.Value, index.Value, branch.Value))
    let _dx                                        (i : ICell<int>)   
                                                   = cell (fun () -> _TrinomialTree.Value.dx(i.Value))
    let _probability                               (i : ICell<int>) (index : ICell<int>) (branch : ICell<int>)   
                                                   = cell (fun () -> _TrinomialTree.Value.probability(i.Value, index.Value, branch.Value))
    let _size                                      (i : ICell<int>)   
                                                   = cell (fun () -> _TrinomialTree.Value.size(i.Value))
    let _timeGrid                                  = cell (fun () -> _TrinomialTree.Value.timeGrid())
    let _underlying                                (i : ICell<int>) (index : ICell<int>)   
                                                   = cell (fun () -> _TrinomialTree.Value.underlying(i.Value, index.Value))
    let _columns                                   = cell (fun () -> _TrinomialTree.Value.columns())
    do this.Bind(_TrinomialTree)

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.timeGrid                           = _timeGrid 
    member this.Descendant                         i index branch   
                                                   = _descendant i index branch 
    member this.Dx                                 i   
                                                   = _dx i 
    member this.Probability                        i index branch   
                                                   = _probability i index branch 
    member this.Size                               i   
                                                   = _size i 
    member this.TimeGrid                           = _timeGrid
    member this.Underlying                         i index   
                                                   = _underlying i index 
    member this.Columns                            = _columns
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type TrinomialTreeModel1
    ( Process                                      : ICell<StochasticProcess1D>
    , timeGrid                                     : ICell<TimeGrid>
    , isPositive                                   : ICell<bool>
    ) as this =

    inherit Model<TrinomialTree> ()
(*
    Parameters
*)
    let _Process                                   = Process
    let _timeGrid                                  = timeGrid
    let _isPositive                                = isPositive
(*
    Functions
*)
    let _TrinomialTree                             = cell (fun () -> new TrinomialTree (Process.Value, timeGrid.Value, isPositive.Value))
    let _descendant                                (i : ICell<int>) (index : ICell<int>) (branch : ICell<int>)   
                                                   = cell (fun () -> _TrinomialTree.Value.descendant(i.Value, index.Value, branch.Value))
    let _dx                                        (i : ICell<int>)   
                                                   = cell (fun () -> _TrinomialTree.Value.dx(i.Value))
    let _probability                               (i : ICell<int>) (index : ICell<int>) (branch : ICell<int>)   
                                                   = cell (fun () -> _TrinomialTree.Value.probability(i.Value, index.Value, branch.Value))
    let _size                                      (i : ICell<int>)   
                                                   = cell (fun () -> _TrinomialTree.Value.size(i.Value))
    let _timeGrid                                  = cell (fun () -> _TrinomialTree.Value.timeGrid())
    let _underlying                                (i : ICell<int>) (index : ICell<int>)   
                                                   = cell (fun () -> _TrinomialTree.Value.underlying(i.Value, index.Value))
    let _columns                                   = cell (fun () -> _TrinomialTree.Value.columns())
    do this.Bind(_TrinomialTree)

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.timeGrid                           = _timeGrid 
    member this.isPositive                         = _isPositive 
    member this.Descendant                         i index branch   
                                                   = _descendant i index branch 
    member this.Dx                                 i   
                                                   = _dx i 
    member this.Probability                        i index branch   
                                                   = _probability i index branch 
    member this.Size                               i   
                                                   = _size i 
    member this.TimeGrid                           = _timeGrid
    member this.Underlying                         i index   
                                                   = _underlying i index 
    member this.Columns                            = _columns
