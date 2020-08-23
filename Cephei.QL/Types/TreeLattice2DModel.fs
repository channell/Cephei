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
  This lattice is based on two trinomial trees and primarily used for the G2 short-rate model.  lattices
this is a workaround for CuriouslyRecurringTemplate of TreeLattice recheck it
  </summary> *)
[<AutoSerializable(true)>]
type TreeLattice2DModel<'T, 'Tl when 'T :> IGenericLattice and 'Tl :> TrinomialTree>
    ( tree1                                        : ICell<TrinomialTree>
    , tree2                                        : ICell<TrinomialTree>
    , correlation                                  : ICell<double>
    ) as this =

    inherit Model<TreeLattice2D<'T,'Tl>> ()
(*
    Parameters
*)
    let _tree1                                     = tree1
    let _tree2                                     = tree2
    let _correlation                               = correlation
(*
    Functions
*)
    let _TreeLattice2D                             = cell (fun () -> new TreeLattice2D<'T,'Tl> (tree1.Value, tree2.Value, correlation.Value))
    let _descendant                                (i : ICell<int>) (index : ICell<int>) (branch : ICell<int>)   
                                                   = triv (fun () -> _TreeLattice2D.Value.descendant(i.Value, index.Value, branch.Value))
    let _grid                                      (t : ICell<double>)   
                                                   = triv (fun () -> _TreeLattice2D.Value.grid(t.Value))
    let _probability                               (i : ICell<int>) (index : ICell<int>) (branch : ICell<int>)   
                                                   = triv (fun () -> _TreeLattice2D.Value.probability(i.Value, index.Value, branch.Value))
    let _size                                      (i : ICell<int>)   
                                                   = triv (fun () -> _TreeLattice2D.Value.size(i.Value))
    let _initialize                                (asset : ICell<DiscretizedAsset>) (t : ICell<double>)   
                                                   = triv (fun () -> _TreeLattice2D.Value.initialize(asset.Value, t.Value)
                                                                     _TreeLattice2D.Value)
    let _partialRollback                           (asset : ICell<DiscretizedAsset>) (To : ICell<double>)   
                                                   = triv (fun () -> _TreeLattice2D.Value.partialRollback(asset.Value, To.Value)
                                                                     _TreeLattice2D.Value)
    let _presentValue                              (asset : ICell<DiscretizedAsset>)   
                                                   = triv (fun () -> _TreeLattice2D.Value.presentValue(asset.Value))
    let _rollback                                  (asset : ICell<DiscretizedAsset>) (To : ICell<double>)   
                                                   = triv (fun () -> _TreeLattice2D.Value.rollback(asset.Value, To.Value)
                                                                     _TreeLattice2D.Value)
    let _statePrices                               (i : ICell<int>)   
                                                   = triv (fun () -> _TreeLattice2D.Value.statePrices(i.Value))
    let _stepback                                  (i : ICell<int>) (values : ICell<Vector>) (newValues : ICell<Vector>)   
                                                   = triv (fun () -> _TreeLattice2D.Value.stepback(i.Value, values.Value, newValues.Value)
                                                                     _TreeLattice2D.Value)
    let _timeGrid                                  = triv (fun () -> _TreeLattice2D.Value.timeGrid())
    do this.Bind(_TreeLattice2D)

(* 
    Externally visible/bindable properties
*)
    member this.tree1                              = _tree1 
    member this.tree2                              = _tree2 
    member this.correlation                        = _correlation 
    member this.Descendant                         i index branch   
                                                   = _descendant i index branch 
    member this.Grid                               t   
                                                   = _grid t 
    member this.Probability                        i index branch   
                                                   = _probability i index branch 
    member this.Size                               i   
                                                   = _size i 
    member this.Initialize                         asset t   
                                                   = _initialize asset t 
    member this.PartialRollback                    asset To   
                                                   = _partialRollback asset To 
    member this.PresentValue                       asset   
                                                   = _presentValue asset 
    member this.Rollback                           asset To   
                                                   = _rollback asset To 
    member this.StatePrices                        i   
                                                   = _statePrices i 
    member this.Stepback                           i values newValues   
                                                   = _stepback i values newValues 
    member this.TimeGrid                           = _timeGrid
