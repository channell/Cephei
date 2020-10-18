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
type XABRCoeffHolderModel<'Model when 'Model :> IModel and 'Model : (new : unit -> 'Model)>
    ( t                                            : ICell<double>
    , forward                                      : ICell<double>
    , _params                                      : ICell<List<Nullable<double>>>
    , paramIsFixed                                 : ICell<Generic.List<bool>>
    , addParams                                    : ICell<List<Nullable<double>>>
    ) as this =

    inherit Model<XABRCoeffHolder<'Model>> ()
(*
    Parameters
*)
    let _t                                         = t
    let _forward                                   = forward
    let __params                                   = _params
    let _paramIsFixed                              = paramIsFixed
    let _addParams                                 = addParams
(*
    Functions
*)
    let mutable
        _XABRCoeffHolder                           = cell (fun () -> new XABRCoeffHolder<'Model> (t.Value, forward.Value, _params.Value, paramIsFixed.Value, addParams.Value))
    let _addParams_                                = triv (fun () -> _XABRCoeffHolder.Value.addParams_)
    let _error_                                    = triv (fun () -> _XABRCoeffHolder.Value.error_)
    let _forward_                                  = triv (fun () -> _XABRCoeffHolder.Value.forward_)
    let _maxError_                                 = triv (fun () -> _XABRCoeffHolder.Value.maxError_)
    let _model_                                    = triv (fun () -> _XABRCoeffHolder.Value.model_)
    let _modelInstance_                            = triv (fun () -> _XABRCoeffHolder.Value.modelInstance_)
    let _paramIsFixed_                             = triv (fun () -> _XABRCoeffHolder.Value.paramIsFixed_)
    let _params_                                   = triv (fun () -> _XABRCoeffHolder.Value.params_)
    let _t_                                        = triv (fun () -> _XABRCoeffHolder.Value.t_)
    let _updateModelInstance                       = triv (fun () -> _XABRCoeffHolder.Value.updateModelInstance()
                                                                     _XABRCoeffHolder.Value)
    let _weights_                                  = triv (fun () -> _XABRCoeffHolder.Value.weights_)
    let _XABREndCriteria_                          = triv (fun () -> _XABRCoeffHolder.Value.XABREndCriteria_)
    do this.Bind(_XABRCoeffHolder)

(* 
    Externally visible/bindable properties
*)
    member this.t                                  = _t 
    member this.forward                            = _forward 
    member this._params                            = __params 
    member this.paramIsFixed                       = _paramIsFixed 
    member this.addParams                          = _addParams 
    member this.AddParams_                         = _addParams_
    member this.Error_                             = _error_
    member this.Forward_                           = _forward_
    member this.MaxError_                          = _maxError_
    member this.Model_                             = _model_
    member this.ModelInstance_                     = _modelInstance_
    member this.ParamIsFixed_                      = _paramIsFixed_
    member this.Params_                            = _params_
    member this.T_                                 = _t_
    member this.UpdateModelInstance                = _updateModelInstance
    member this.Weights_                           = _weights_
    member this.XABREndCriteria_                   = _XABREndCriteria_
