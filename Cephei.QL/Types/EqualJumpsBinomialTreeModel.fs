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
  lattices

  </summary> *)
[<AutoSerializable(true)>]
type EqualJumpsBinomialTreeModel<'T>
    ( Process                                      : ICell<StochasticProcess1D>
    , End                                          : ICell<double>
    , steps                                        : ICell<int>
    ) as this =

    inherit Model<EqualJumpsBinomialTree<'T>> ()
(*
    Parameters
*)
    let _Process                                   = Process
    let _End                                       = End
    let _steps                                     = steps
(*
    Functions
*)
    let _EqualJumpsBinomialTree                    = cell (fun () -> new EqualJumpsBinomialTree<'T> (Process.Value, End.Value, steps.Value))
    let _probability                               (x : ICell<int>) (y : ICell<int>) (branch : ICell<int>)   
                                                   = cell (fun () -> _EqualJumpsBinomialTree.Value.probability(x.Value, y.Value, branch.Value))
    let _underlying                                (i : ICell<int>) (index : ICell<int>)   
                                                   = cell (fun () -> _EqualJumpsBinomialTree.Value.underlying(i.Value, index.Value))
    let _descendant                                (x : ICell<int>) (index : ICell<int>) (branch : ICell<int>)   
                                                   = cell (fun () -> _EqualJumpsBinomialTree.Value.descendant(x.Value, index.Value, branch.Value))
    let _size                                      (i : ICell<int>)   
                                                   = cell (fun () -> _EqualJumpsBinomialTree.Value.size(i.Value))
    let _columns                                   = cell (fun () -> _EqualJumpsBinomialTree.Value.columns())
    do this.Bind(_EqualJumpsBinomialTree)

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.End                                = _End 
    member this.steps                              = _steps 
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
  lattices
parameterless constructor is requried for generics
  </summary> *)
[<AutoSerializable(true)>]
type EqualJumpsBinomialTreeModel1<'T>
    () as this =
    inherit Model<EqualJumpsBinomialTree<'T>> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _EqualJumpsBinomialTree                    = cell (fun () -> new EqualJumpsBinomialTree<'T> ())
    let _probability                               (x : ICell<int>) (y : ICell<int>) (branch : ICell<int>)   
                                                   = cell (fun () -> _EqualJumpsBinomialTree.Value.probability(x.Value, y.Value, branch.Value))
    let _underlying                                (i : ICell<int>) (index : ICell<int>)   
                                                   = cell (fun () -> _EqualJumpsBinomialTree.Value.underlying(i.Value, index.Value))
    let _descendant                                (x : ICell<int>) (index : ICell<int>) (branch : ICell<int>)   
                                                   = cell (fun () -> _EqualJumpsBinomialTree.Value.descendant(x.Value, index.Value, branch.Value))
    let _size                                      (i : ICell<int>)   
                                                   = cell (fun () -> _EqualJumpsBinomialTree.Value.size(i.Value))
    let _columns                                   = cell (fun () -> _EqualJumpsBinomialTree.Value.columns())
    do this.Bind(_EqualJumpsBinomialTree)

(* 
    Externally visible/bindable properties
*)
    member this.Probability                        x y branch   
                                                   = _probability x y branch 
    member this.Underlying                         i index   
                                                   = _underlying i index 
    member this.Descendant                         x index branch   
                                                   = _descendant x index branch 
    member this.Size                               i   
                                                   = _size i 
    member this.Columns                            = _columns
