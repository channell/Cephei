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
  Recombining two-dimensional tree discretizing the state variable
! Plain tree build-up from short-rate dynamics
  </summary> *)
[<AutoSerializable(true)>]
type ShortRateTreeModel
    ( tree1                                        : ICell<TrinomialTree>
    , tree2                                        : ICell<TrinomialTree>
    , dynamics                                     : ICell<ShortRateDynamics.ShortRateDynamics>
    ) as this =

    inherit Model<ShortRateTree> ()
(*
    Parameters
*)
    let _tree1                                     = tree1
    let _tree2                                     = tree2
    let _dynamics                                  = dynamics
(*
    Functions
*)
    let _ShortRateTree                             = cell (fun () -> new ShortRateTree (tree1.Value, tree2.Value, dynamics.Value))
    let _discount                                  (i : ICell<int>) (index : ICell<int>)   
                                                   = cell (fun () -> _ShortRateTree.Value.discount(i.Value, index.Value))
    let _underlying                                (i : ICell<int>) (index : ICell<int>)   
                                                   = cell (fun () -> _ShortRateTree.Value.underlying(i.Value, index.Value))
    let _descendant                                (i : ICell<int>) (index : ICell<int>) (branch : ICell<int>)   
                                                   = cell (fun () -> _ShortRateTree.Value.descendant(i.Value, index.Value, branch.Value))
    let _grid                                      (t : ICell<double>)   
                                                   = cell (fun () -> _ShortRateTree.Value.grid(t.Value))
    let _probability                               (i : ICell<int>) (index : ICell<int>) (branch : ICell<int>)   
                                                   = cell (fun () -> _ShortRateTree.Value.probability(i.Value, index.Value, branch.Value))
    let _size                                      (i : ICell<int>)   
                                                   = cell (fun () -> _ShortRateTree.Value.size(i.Value))
    let _initialize                                (asset : ICell<DiscretizedAsset>) (t : ICell<double>)   
                                                   = cell (fun () -> _ShortRateTree.Value.initialize(asset.Value, t.Value)
                                                                     _ShortRateTree.Value)
    let _partialRollback                           (asset : ICell<DiscretizedAsset>) (To : ICell<double>)   
                                                   = cell (fun () -> _ShortRateTree.Value.partialRollback(asset.Value, To.Value)
                                                                     _ShortRateTree.Value)
    let _presentValue                              (asset : ICell<DiscretizedAsset>)   
                                                   = cell (fun () -> _ShortRateTree.Value.presentValue(asset.Value))
    let _rollback                                  (asset : ICell<DiscretizedAsset>) (To : ICell<double>)   
                                                   = cell (fun () -> _ShortRateTree.Value.rollback(asset.Value, To.Value)
                                                                     _ShortRateTree.Value)
    let _statePrices                               (i : ICell<int>)   
                                                   = cell (fun () -> _ShortRateTree.Value.statePrices(i.Value))
    let _stepback                                  (i : ICell<int>) (values : ICell<Vector>) (newValues : ICell<Vector>)   
                                                   = cell (fun () -> _ShortRateTree.Value.stepback(i.Value, values.Value, newValues.Value)
                                                                     _ShortRateTree.Value)
    let _timeGrid                                  = cell (fun () -> _ShortRateTree.Value.timeGrid())
    do this.Bind(_ShortRateTree)
(* 
    casting 
*)
    internal new () = ShortRateTreeModel(null,null,null)
    member internal this.Inject v = _ShortRateTree.Value <- v
    static member Cast (p : ICell<ShortRateTree>) = 
        if p :? ShortRateTreeModel then 
            p :?> ShortRateTreeModel
        else
            let o = new ShortRateTreeModel ()
            o.Inject p.Value
            o
                            
(* 
    casting 
*)
    internal new () = ShortRateTreeModel(null,null,null)
    static member Cast (p : ICell<ShortRateTree>) = 
        if p :? ShortRateTreeModel then 
            p :?> ShortRateTreeModel
        else
            let o = new ShortRateTreeModel ()
            o.Value <- p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.tree1                              = _tree1 
    member this.tree2                              = _tree2 
    member this.dynamics                           = _dynamics 
    member this.Discount                           i index   
                                                   = _discount i index 
    member this.Underlying                         i index   
                                                   = _underlying i index 
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
