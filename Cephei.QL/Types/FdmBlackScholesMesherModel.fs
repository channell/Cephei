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
type FdmBlackScholesMesherModel
    ( size                                         : ICell<int>
    , Process                                      : ICell<GeneralizedBlackScholesProcess>
    , maturity                                     : ICell<double>
    , strike                                       : ICell<double>
    , xMinConstraint                               : ICell<Nullable<double>>
    , xMaxConstraint                               : ICell<Nullable<double>>
    , eps                                          : ICell<double>
    , scaleFactor                                  : ICell<double>
    , cPoint                                       : ICell<Pair<Nullable<double>,Nullable<double>>>
    , dividendSchedule                             : ICell<DividendSchedule>
    , fdmQuantoHelper                              : ICell<FdmQuantoHelper>
    , spotAdjustment                               : ICell<double>
    ) as this =

    inherit Model<FdmBlackScholesMesher> ()
(*
    Parameters
*)
    let _size                                      = size
    let _Process                                   = Process
    let _maturity                                  = maturity
    let _strike                                    = strike
    let _xMinConstraint                            = xMinConstraint
    let _xMaxConstraint                            = xMaxConstraint
    let _eps                                       = eps
    let _scaleFactor                               = scaleFactor
    let _cPoint                                    = cPoint
    let _dividendSchedule                          = dividendSchedule
    let _fdmQuantoHelper                           = fdmQuantoHelper
    let _spotAdjustment                            = spotAdjustment
(*
    Functions
*)
    let mutable
        _FdmBlackScholesMesher                     = make (fun () -> new FdmBlackScholesMesher (size.Value, Process.Value, maturity.Value, strike.Value, xMinConstraint.Value, xMaxConstraint.Value, eps.Value, scaleFactor.Value, cPoint.Value, dividendSchedule.Value, fdmQuantoHelper.Value, spotAdjustment.Value))
    let _dminus                                    (index : ICell<int>)   
                                                   = triv _FdmBlackScholesMesher (fun () -> _FdmBlackScholesMesher.Value.dminus(index.Value))
    let _dplus                                     (index : ICell<int>)   
                                                   = triv _FdmBlackScholesMesher (fun () -> _FdmBlackScholesMesher.Value.dplus(index.Value))
    let _location                                  (index : ICell<int>)   
                                                   = triv _FdmBlackScholesMesher (fun () -> _FdmBlackScholesMesher.Value.location(index.Value))
    let _locations                                 = triv _FdmBlackScholesMesher (fun () -> _FdmBlackScholesMesher.Value.locations())
    let _size                                      = triv _FdmBlackScholesMesher (fun () -> _FdmBlackScholesMesher.Value.size())
    do this.Bind(_FdmBlackScholesMesher)
(* 
    casting 
*)
    internal new () = new FdmBlackScholesMesherModel(null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _FdmBlackScholesMesher <- v
    static member Cast (p : ICell<FdmBlackScholesMesher>) = 
        if p :? FdmBlackScholesMesherModel then 
            p :?> FdmBlackScholesMesherModel
        else
            let o = new FdmBlackScholesMesherModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.size                               = _size 
    member this.Process                            = _Process 
    member this.maturity                           = _maturity 
    member this.strike                             = _strike 
    member this.xMinConstraint                     = _xMinConstraint 
    member this.xMaxConstraint                     = _xMaxConstraint 
    member this.eps                                = _eps 
    member this.scaleFactor                        = _scaleFactor 
    member this.cPoint                             = _cPoint 
    member this.dividendSchedule                   = _dividendSchedule 
    member this.fdmQuantoHelper                    = _fdmQuantoHelper 
    member this.spotAdjustment                     = _spotAdjustment 
    member this.Dminus                             index   
                                                   = _dminus index 
    member this.Dplus                              index   
                                                   = _dplus index 
    member this.Location                           index   
                                                   = _location index 
    member this.Locations                          = _locations
    member this.Size                               = _size
