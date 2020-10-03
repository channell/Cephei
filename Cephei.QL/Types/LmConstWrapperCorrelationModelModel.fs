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
type LmConstWrapperCorrelationModelModel
    ( corrModel                                    : ICell<LmCorrelationModel>
    ) as this =

    inherit Model<LmConstWrapperCorrelationModel> ()
(*
    Parameters
*)
    let _corrModel                                 = corrModel
(*
    Functions
*)
    let _LmConstWrapperCorrelationModel            = cell (fun () -> new LmConstWrapperCorrelationModel (corrModel.Value))
    let _correlation                               (t : ICell<double>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _LmConstWrapperCorrelationModel.Value.correlation(t.Value, x.Value))
    let _correlation1                              (i : ICell<int>) (j : ICell<int>) (t : ICell<double>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _LmConstWrapperCorrelationModel.Value.correlation(i.Value, j.Value, t.Value, x.Value))
    let _factors                                   = triv (fun () -> _LmConstWrapperCorrelationModel.Value.factors())
    let _isTimeIndependent                         = triv (fun () -> _LmConstWrapperCorrelationModel.Value.isTimeIndependent())
    let _pseudoSqrt                                (t : ICell<double>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _LmConstWrapperCorrelationModel.Value.pseudoSqrt(t.Value, x.Value))
    let _parameters                                = triv (fun () -> _LmConstWrapperCorrelationModel.Value.parameters())
    let _setParams                                 (arguments : ICell<Generic.List<Parameter>>)   
                                                   = triv (fun () -> _LmConstWrapperCorrelationModel.Value.setParams(arguments.Value)
                                                                     _LmConstWrapperCorrelationModel.Value)
    let _size                                      = triv (fun () -> _LmConstWrapperCorrelationModel.Value.size())
    do this.Bind(_LmConstWrapperCorrelationModel)
(* 
    casting 
*)
    internal new () = LmConstWrapperCorrelationModelModel(null)
    member internal this.Inject v = _LmConstWrapperCorrelationModel.Value <- v
    static member Cast (p : ICell<LmConstWrapperCorrelationModel>) = 
        if p :? LmConstWrapperCorrelationModelModel then 
            p :?> LmConstWrapperCorrelationModelModel
        else
            let o = new LmConstWrapperCorrelationModelModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.corrModel                          = _corrModel 
    member this.Correlation                        t x   
                                                   = _correlation t x 
    member this.Correlation1                       i j t x   
                                                   = _correlation1 i j t x 
    member this.Factors                            = _factors
    member this.IsTimeIndependent                  = _isTimeIndependent
    member this.PseudoSqrt                         t x   
                                                   = _pseudoSqrt t x 
    member this.Parameters                         = _parameters
    member this.SetParams                          arguments   
                                                   = _setParams arguments 
    member this.Size                               = _size
