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
type FdmAffineModelSwapInnerValueModel<'ModelType when 'ModelType :> ITermStructureConsistentModel and 'ModelType :> IAffineModel>
    ( disModel                                     : ICell<'ModelType>
    , fwdModel                                     : ICell<'ModelType>
    , swap                                         : ICell<VanillaSwap>
    , exerciseDates                                : ICell<Dictionary<double,Date>>
    , mesher                                       : ICell<FdmMesher>
    , direction                                    : ICell<int>
    ) as this =

    inherit Model<FdmAffineModelSwapInnerValue<'ModelType>> ()
(*
    Parameters
*)
    let _disModel                                  = disModel
    let _fwdModel                                  = fwdModel
    let _swap                                      = swap
    let _exerciseDates                             = exerciseDates
    let _mesher                                    = mesher
    let _direction                                 = direction
(*
    Functions
*)
    let _FdmAffineModelSwapInnerValue              = cell (fun () -> new FdmAffineModelSwapInnerValue<'ModelType> (disModel.Value, fwdModel.Value, swap.Value, exerciseDates.Value, mesher.Value, direction.Value))
    let _avgInnerValue                             (iter : ICell<FdmLinearOpIterator>) (t : ICell<double>)   
                                                   = triv (fun () -> _FdmAffineModelSwapInnerValue.Value.avgInnerValue(iter.Value, t.Value))
    let _getState                                  (model : ICell<'ModelType>) (t : ICell<double>) (iter : ICell<FdmLinearOpIterator>)   
                                                   = triv (fun () -> _FdmAffineModelSwapInnerValue.Value.getState(model.Value, t.Value, iter.Value))
    let _innerValue                                (iter : ICell<FdmLinearOpIterator>) (t : ICell<double>)   
                                                   = triv (fun () -> _FdmAffineModelSwapInnerValue.Value.innerValue(iter.Value, t.Value))
    do this.Bind(_FdmAffineModelSwapInnerValue)

(* 
    Externally visible/bindable properties
*)
    member this.disModel                           = _disModel 
    member this.fwdModel                           = _fwdModel 
    member this.swap                               = _swap 
    member this.exerciseDates                      = _exerciseDates 
    member this.mesher                             = _mesher 
    member this.direction                          = _direction 
    member this.AvgInnerValue                      iter t   
                                                   = _avgInnerValue iter t 
    member this.GetState                           model t iter   
                                                   = _getState model t iter 
    member this.InnerValue                         iter t   
                                                   = _innerValue iter t 
