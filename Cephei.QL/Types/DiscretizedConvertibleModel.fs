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
type DiscretizedConvertibleModel
    ( args                                         : ICell<ConvertibleBond.option.Arguments>
    , Process                                      : ICell<GeneralizedBlackScholesProcess>
    , grid                                         : ICell<TimeGrid>
    ) as this =

    inherit Model<DiscretizedConvertible> ()
(*
    Parameters
*)
    let _args                                      = args
    let _Process                                   = Process
    let _grid                                      = grid
(*
    Functions
*)
    let mutable
        _DiscretizedConvertible                    = make (fun () -> new DiscretizedConvertible (args.Value, Process.Value, grid.Value))
    let _addCoupon                                 (i : ICell<int>)   
                                                   = triv _DiscretizedConvertible (fun () -> _DiscretizedConvertible.Value.addCoupon(i.Value)
                                                                                             _DiscretizedConvertible.Value)
    let _adjustedGrid                              = triv _DiscretizedConvertible (fun () -> _DiscretizedConvertible.Value.adjustedGrid())
    let _applyCallability                          (i : ICell<int>) (convertible : ICell<bool>)   
                                                   = triv _DiscretizedConvertible (fun () -> _DiscretizedConvertible.Value.applyCallability(i.Value, convertible.Value)
                                                                                             _DiscretizedConvertible.Value)
    let _applyConvertibility                       = triv _DiscretizedConvertible (fun () -> _DiscretizedConvertible.Value.applyConvertibility()
                                                                                             _DiscretizedConvertible.Value)
    let _conversionProbability                     = triv _DiscretizedConvertible (fun () -> _DiscretizedConvertible.Value.conversionProbability())
    let _dividendValues                            = triv _DiscretizedConvertible (fun () -> _DiscretizedConvertible.Value.dividendValues())
    let _mandatoryTimes                            = triv _DiscretizedConvertible (fun () -> _DiscretizedConvertible.Value.mandatoryTimes())
    let _process                                   = triv _DiscretizedConvertible (fun () -> _DiscretizedConvertible.Value.PROCESS())
    let _reset                                     (size : ICell<int>)   
                                                   = triv _DiscretizedConvertible (fun () -> _DiscretizedConvertible.Value.reset(size.Value)
                                                                                             _DiscretizedConvertible.Value)
    let _spreadAdjustedRate                        = triv _DiscretizedConvertible (fun () -> _DiscretizedConvertible.Value.spreadAdjustedRate())
    let _adjustValues                              = triv _DiscretizedConvertible (fun () -> _DiscretizedConvertible.Value.adjustValues()
                                                                                             _DiscretizedConvertible.Value)
    let _initialize                                (Method : ICell<Lattice>) (t : ICell<double>)   
                                                   = triv _DiscretizedConvertible (fun () -> _DiscretizedConvertible.Value.initialize(Method.Value, t.Value)
                                                                                             _DiscretizedConvertible.Value)
    let _method                                    = triv _DiscretizedConvertible (fun () -> _DiscretizedConvertible.Value.METHOD())
    let _partialRollback                           (To : ICell<double>)   
                                                   = triv _DiscretizedConvertible (fun () -> _DiscretizedConvertible.Value.partialRollback(To.Value)
                                                                                             _DiscretizedConvertible.Value)
    let _postAdjustValues                          = triv _DiscretizedConvertible (fun () -> _DiscretizedConvertible.Value.postAdjustValues()
                                                                                             _DiscretizedConvertible.Value)
    let _preAdjustValues                           = triv _DiscretizedConvertible (fun () -> _DiscretizedConvertible.Value.preAdjustValues()
                                                                                             _DiscretizedConvertible.Value)
    let _presentValue                              = triv _DiscretizedConvertible (fun () -> _DiscretizedConvertible.Value.presentValue())
    let _rollback                                  (To : ICell<double>)   
                                                   = triv _DiscretizedConvertible (fun () -> _DiscretizedConvertible.Value.rollback(To.Value)
                                                                                             _DiscretizedConvertible.Value)
    let _setTime                                   (t : ICell<double>)   
                                                   = triv _DiscretizedConvertible (fun () -> _DiscretizedConvertible.Value.setTime(t.Value)
                                                                                             _DiscretizedConvertible.Value)
    let _setValues                                 (v : ICell<Vector>)   
                                                   = triv _DiscretizedConvertible (fun () -> _DiscretizedConvertible.Value.setValues(v.Value)
                                                                                             _DiscretizedConvertible.Value)
    let _time                                      = triv _DiscretizedConvertible (fun () -> _DiscretizedConvertible.Value.time())
    let _values                                    = triv _DiscretizedConvertible (fun () -> _DiscretizedConvertible.Value.values())
    do this.Bind(_DiscretizedConvertible)
(* 
    casting 
*)
    internal new () = new DiscretizedConvertibleModel(null,null,null)
    member internal this.Inject v = _DiscretizedConvertible <- v
    static member Cast (p : ICell<DiscretizedConvertible>) = 
        if p :? DiscretizedConvertibleModel then 
            p :?> DiscretizedConvertibleModel
        else
            let o = new DiscretizedConvertibleModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.args                               = _args 
    member this.Process                            = _Process 
    member this.grid                               = _grid 
    member this.AddCoupon                          i   
                                                   = _addCoupon i 
    member this.AdjustedGrid                       = _adjustedGrid
    member this.ApplyCallability                   i convertible   
                                                   = _applyCallability i convertible 
    member this.ApplyConvertibility                = _applyConvertibility
    member this.ConversionProbability              = _conversionProbability
    member this.DividendValues                     = _dividendValues
    member this.MandatoryTimes                     = _mandatoryTimes
    member this.Process1                           = _process
    member this.Reset                              size   
                                                   = _reset size 
    member this.SpreadAdjustedRate                 = _spreadAdjustedRate
    member this.AdjustValues                       = _adjustValues
    member this.Initialize                         Method t   
                                                   = _initialize Method t 
    member this.Method                             = _method
    member this.PartialRollback                    To   
                                                   = _partialRollback To 
    member this.PostAdjustValues                   = _postAdjustValues
    member this.PreAdjustValues                    = _preAdjustValues
    member this.PresentValue                       = _presentValue
    member this.Rollback                           To   
                                                   = _rollback To 
    member this.SetTime                            t   
                                                   = _setTime t 
    member this.SetValues                          v   
                                                   = _setValues v 
    member this.Time                               = _time
    member this.Values                             = _values
