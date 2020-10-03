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
type TsiveriotisFernandesLatticeModel<'T when 'T :> ITree>
    ( tree                                         : ICell<'T>
    , riskFreeRate                                 : ICell<double>
    , End                                          : ICell<double>
    , steps                                        : ICell<int>
    , creditSpread                                 : ICell<double>
    , sigma                                        : ICell<double>
    , divYield                                     : ICell<double>
    ) as this =

    inherit Model<TsiveriotisFernandesLattice<'T>> ()
(*
    Parameters
*)
    let _tree                                      = tree
    let _riskFreeRate                              = riskFreeRate
    let _End                                       = End
    let _steps                                     = steps
    let _creditSpread                              = creditSpread
    let _sigma                                     = sigma
    let _divYield                                  = divYield
(*
    Functions
*)
    let _TsiveriotisFernandesLattice               = cell (fun () -> new TsiveriotisFernandesLattice<'T> (tree.Value, riskFreeRate.Value, End.Value, steps.Value, creditSpread.Value, sigma.Value, divYield.Value))
    let _partialRollback                           (asset : ICell<DiscretizedAsset>) (To : ICell<double>)   
                                                   = triv (fun () -> _TsiveriotisFernandesLattice.Value.partialRollback(asset.Value, To.Value)
                                                                     _TsiveriotisFernandesLattice.Value)
    let _rollback                                  (asset : ICell<DiscretizedAsset>) (To : ICell<double>)   
                                                   = triv (fun () -> _TsiveriotisFernandesLattice.Value.rollback(asset.Value, To.Value)
                                                                     _TsiveriotisFernandesLattice.Value)
    let _stepback                                  (i : ICell<int>) (values : ICell<Vector>) (conversionProbability : ICell<Vector>) (spreadAdjustedRate : ICell<Vector>) (newValues : ICell<Vector>) (newConversionProbability : ICell<Vector>) (newSpreadAdjustedRate : ICell<Vector>)   
                                                   = triv (fun () -> _TsiveriotisFernandesLattice.Value.stepback(i.Value, values.Value, conversionProbability.Value, spreadAdjustedRate.Value, newValues.Value, newConversionProbability.Value, newSpreadAdjustedRate.Value)
                                                                     _TsiveriotisFernandesLattice.Value)
    do this.Bind(_TsiveriotisFernandesLattice)

(* 
    Externally visible/bindable properties
*)
    member this.tree                               = _tree 
    member this.riskFreeRate                       = _riskFreeRate 
    member this.End                                = _End 
    member this.steps                              = _steps 
    member this.creditSpread                       = _creditSpread 
    member this.sigma                              = _sigma 
    member this.divYield                           = _divYield 
    member this.PartialRollback                    asset To   
                                                   = _partialRollback asset To 
    member this.Rollback                           asset To   
                                                   = _rollback asset To 
    member this.Stepback                           i values conversionProbability spreadAdjustedRate newValues newConversionProbability newSpreadAdjustedRate   
                                                   = _stepback i values conversionProbability spreadAdjustedRate newValues newConversionProbability newSpreadAdjustedRate 
